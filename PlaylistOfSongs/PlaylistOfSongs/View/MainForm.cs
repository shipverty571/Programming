using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PlaylistOfSongs.Model;
using System.IO;
using PlaylistOfSongs.Properties;

namespace PlaylistOfSongs.View
{
    /// <summary>
    /// Предоставляет реализацию по представлению главного окна.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Путь до AppData
        /// </summary>
        private string AppdataPath = Application.UserAppDataPath;

        /// <summary>
        /// Дочернее окно добавления песни.
        /// </summary>
        private AddSongForm _songForm;

        /// <summary>
        /// Выбранная песня.
        /// </summary>
        private Song _currentSong;

        /// <summary>
        /// Коллекция песен.
        /// </summary>
        private List<Song> _songs;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            var genre = Enum.GetValues(typeof(Genre));

            foreach (var value in genre)
                GenreComboBox.Items.Add(value);

            _songs = Serializer.Deserialize(AppdataPath);

            UpdateListBox(-1);
        }

        /// <summary>
        /// Очищает поля для вывода информации.
        /// </summary>
        private void ClearFields()
        {
            SongNameTextBox.Clear();
            ArtistNameTextBox.Clear();
            DurationSecondsTextBox.Clear();
            ArtistPictureBox.Image = null;
            GenreComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Ищет индекс элемента по уникальному идентификатору.
        /// </summary>
        /// <returns>Возвращает индекс найденного элемента.</returns>
        private int FindIndexItemById()
        {
            var orderedListSongs = from song in _songs
                orderby song.ArtistName, song.SongName
                select song;
            _songs = orderedListSongs.ToList();
            int currentSongId = _currentSong.Id;
            int index = -1;

            for (int i = 0; i < _songs.Count; i++)
            {
                if (_songs[i].Id != currentSongId) continue;
                
                index = i;
                break;
            }

            return index;
        }

        /// <summary>
        /// Обновляет данные в списке ListBox.
        /// </summary>
        /// <param name="selectedIndex">Индекс выбранного элемента.</param>
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
            _songForm._songAdded += AddSongForm_SongAdded;
            _songForm.ShowDialog();
        }

        private void DeleteSongButton_Click(object sender, EventArgs e)
        {
            int index = SongListBox.SelectedIndex;

            if (index == -1) return;

            _songs.RemoveAt(index);

            UpdateListBox(-1);
            ClearFields();
            Serializer.Serialize(AppdataPath, _songs);
        }

        public void AddSongForm_SongAdded(object sender, SongAddedEventArgs args)
        {
            _songs.Add(args.Song);
            Serializer.Serialize(AppdataPath, _songs);
            UpdateListBox(0);
        }

        private void SongListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = SongListBox.SelectedIndex;

            if (index == -1) return;

            _currentSong = _songs[index];
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
            if (SongListBox.SelectedIndex == -1) return;

            try
            {
                string songNameText = SongNameTextBox.Text;
                _currentSong.SongName = songNameText;
                int index = FindIndexItemById();
                UpdateListBox(index);
                Serializer.Serialize(AppdataPath, _songs);
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
            if (SongListBox.SelectedIndex == -1) return;

            try
            {
                string artistNameText = ArtistNameTextBox.Text;
                _currentSong.ArtistName = artistNameText;
                int index = FindIndexItemById();
                UpdateListBox(index);
                Serializer.Serialize(AppdataPath, _songs);
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
            if (SongListBox.SelectedIndex == -1) return;

            try
            {
                string durationSecondsText = DurationSecondsTextBox.Text;
                int durationSecondsValue = int.Parse(durationSecondsText);
                _currentSong.DurationSeconds = durationSecondsValue;
                Serializer.Serialize(AppdataPath, _songs);
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
            Serializer.Serialize(AppdataPath, _songs);
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            if (SongListBox.SelectedIndex == -1) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg;*.png;*.jpeg)|*.JPG;*.PNG;*.JPEG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] imageArray = File.ReadAllBytes(openFileDialog.FileName);
                _currentSong.ImageBase64 = Convert.ToBase64String(imageArray);
                ArtistPictureBox.Image = new Bitmap(openFileDialog.FileName);

                Serializer.Serialize(AppdataPath, _songs);
            }
        }

        private void DeleteImageButton_Click(object sender, EventArgs e)
        {
            if (SongListBox.SelectedIndex == -1) return;

            if (_currentSong.ImageBase64 == null) return;

            DialogResult dialogResult = MessageBox.Show("Do you really want to delete the image?",
                "Deleting an image",
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                _currentSong.ImageBase64 = null;
                ArtistPictureBox.Image = null;

                Serializer.Serialize(AppdataPath, _songs);
            }
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

        private void EditSongButton_MouseEnter(object sender, EventArgs e)
        {
            EditSongButton.Image = Resources.edit_24x24;
        }

        private void EditSongButton_MouseLeave(object sender, EventArgs e)
        {
            EditSongButton.Image = Resources.edit_24x24_uncolor;
        }

        private void OpenImageButton_MouseEnter(object sender, EventArgs e)
        {
            OpenImageButton.Image = Resources.addImage_24x24;
        }

        private void OpenImageButton_MouseLeave(object sender, EventArgs e)
        {
            OpenImageButton.Image = Resources.addImage_24x24_uncolor;
        }

        private void DeleteImageButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteImageButton.Image = Resources.deleteImage_24x24;
        }

        private void DeleteImageButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteImageButton.Image = Resources.deleteImage_24x24_uncolor;
        }
    }
}
