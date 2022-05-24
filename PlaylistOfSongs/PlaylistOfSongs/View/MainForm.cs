using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PlaylistOfSongs.Model;
using Newtonsoft.Json;
using System.IO;
using PlaylistOfSongs.Properties;

namespace PlaylistOfSongs.View
{
    public partial class MainForm : Form
    {
        private AddSongForm _songForm;

        private Song _currentSong;

        private List<Song> _songs;

        public MainForm()
        {
            InitializeComponent();

            var genre = Enum.GetValues(typeof(Genre));

            foreach (var value in genre)
                GenreComboBox.Items.Add(value);

            _songs = Deserialize();

            UpdateListBox(0);
        }

        private List<Song> Deserialize()
        {
            var songs = new List<Song>();

            using (StreamReader reader = new StreamReader(@"Serialize.json"))
            {
                songs = JsonConvert.DeserializeObject<List<Song>>(reader.ReadToEnd());
            }

            return songs;
        }

        private void Serialize()
        {
            using (StreamWriter writer = new StreamWriter(@"Serialize.json"))
            {
                writer.Write(JsonConvert.SerializeObject(_songs));
            }
        }

        private int FindingIndexItemById()
        {
            var orderedListSongs = from song in _songs
                orderby song.ArtistName, song.SongName
                select song;

            _songs = orderedListSongs.ToList();

            int currentSongId = _currentSong.Id;

            int index = -1;

            for (int i = 0; i < _songs.Count; i++)
            {
                if (_songs[i].Id == currentSongId)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private void UpdateListBox(int selectedIndex)
        {
            SongListBox.Items.Clear();

            var orderedListSongs = from song in _songs
                                                       orderby song.ArtistName, song.SongName
                                                       select song;

            _songs = orderedListSongs.ToList();

            foreach (Song song in _songs)
            {
                SongListBox.Items.Add($"{song.ArtistName} - {song.SongName}");
            }

            SongListBox.SelectedIndex = selectedIndex;
        }

        private void AddSongButton_Click(object sender, System.EventArgs e)
        {
            _songForm = new AddSongForm();
            _songForm.SongAdded += AddSongForm_SongAdded;
            _songForm.ShowDialog();
        }

        public void AddSongForm_SongAdded(object sender, SongAddedEventArgs args)
        {
            _songs.Add(args.Song);
            Serialize();
            UpdateListBox(0);
        }

        private void SongListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _currentSong = _songs[SongListBox.SelectedIndex];
            SongNameTextBox.Text = _currentSong.SongName;
            ArtistNameTextBox.Text = _currentSong.ArtistName;
            DurationSecondsTextBox.Text = _currentSong.DurationSeconds.ToString();
            GenreComboBox.SelectedIndex = (int) _currentSong.Genre;

            if (_currentSong.ImageBase64 != null)
                ArtistPictureBox.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(_currentSong.ImageBase64)));
            else
                ArtistPictureBox.Image = null;
        }

        private void SongNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SongListBox.SelectedIndex == -1) return;

                string songNameText = SongNameTextBox.Text;
                _currentSong.SongName = songNameText;
                int index = FindingIndexItemById();
                UpdateListBox(index);
                Serialize();
            }
            catch
            {
                SongNameTextBox.BackColor = AppColors.ErrorColor;
                return;
            }

            SongNameTextBox.BackColor = AppColors.CorrectColor;
        }

        private void ArtistNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SongListBox.SelectedIndex == -1) return;

                string artistNameText = ArtistNameTextBox.Text;
                _currentSong.ArtistName = artistNameText;
                int index = FindingIndexItemById();
                UpdateListBox(index);
                Serialize();
            }
            catch
            {
                ArtistNameTextBox.BackColor = AppColors.ErrorColor;
                return;
            }

            ArtistNameTextBox.BackColor = AppColors.CorrectColor;
        }

        private void DurationSecondsTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SongListBox.SelectedIndex == -1) return;

                string durationSecondsText = DurationSecondsTextBox.Text;
                int durationSecondsValue = int.Parse(durationSecondsText);
                _currentSong.DurationSeconds = durationSecondsValue;
                Serialize();
            }
            catch
            {
                DurationSecondsTextBox.BackColor = AppColors.ErrorColor;
                return;
            }

            DurationSecondsTextBox.BackColor = AppColors.CorrectColor;
        }

        private void GenreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SongListBox.SelectedIndex == -1) return;

            _currentSong.Genre = (Genre)GenreComboBox.SelectedItem;
            Serialize();
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "(*.jpg;*.png;*.jpeg)|*.JPG;*.PNG;*.JPEG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                _currentSong.ImageBase64 = Convert.ToBase64String(imageArray);

                ArtistPictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void DeleteSongButton_Click(object sender, EventArgs e)
        {
            int index = SongListBox.SelectedIndex;

            if (index == -1) return;

            _songs.RemoveAt(index);
            UpdateListBox(0);
        }

        private void AddSongButton_MouseEnter(object sender, EventArgs e)
        {
            AddSongButton.Image = Resources.add_24x24;
        }

        private void AddSongButton_MouseLeave(object sender, EventArgs e)
        {
            AddSongButton.Image = Resources.add_24x24_uncolor;
        }

        private void DeleteSongButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteSongButton.Image = Resources.remove_24x24;
        }

        private void DeleteSongButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteSongButton.Image = Resources.remove_24x24_uncolor;
        }
    }
}
