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
        /// Путь до AppData.
        /// </summary>
        private string AppdataPath = Application.UserAppDataPath;

        /// <summary>
        /// Дочернее окно добавления песни.
        /// </summary>
        private AddSongForm _addSongForm;

        /// <summary>
        /// Дочернее окно редактирования.
        /// </summary>
        private SongForm _songForm;

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
            GenreTextBox.Clear();
            ArtistPictureBox.Image = null;
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

        private void AddSongButton_Click(object sender, EventArgs e)
        {
            _addSongForm = new AddSongForm();

            if (_addSongForm.ShowDialog() != DialogResult.OK) return;

            _songs.Add(FormData.Song);
            Serializer.Serialize(AppdataPath, _songs);
            UpdateListBox(0);
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

        private void SongListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = SongListBox.SelectedIndex;

            if (index == -1) return;

            _currentSong = _songs[index];
            SongNameTextBox.Text = _currentSong.SongName;
            ArtistNameTextBox.Text = _currentSong.ArtistName;
            DurationSecondsTextBox.Text = _currentSong.DurationSeconds.ToString();
            GenreTextBox.Text = _currentSong.Genre.ToString();

            if (_currentSong.ImageBase64 != null)
                ArtistPictureBox.Image = Image.FromStream(new MemoryStream(
                    Convert.FromBase64String(_currentSong.ImageBase64)));
            else
                ArtistPictureBox.Image = null;
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

        private void EditSongButton_Click(object sender, EventArgs e)
        {
            if (SongListBox.SelectedIndex == -1) return;

            FormData.Song = _currentSong;

            _songForm = new SongForm();

            //if (_songForm.ShowDialog() != DialogResult.OK) return;

            if (_songForm.ShowDialog() == DialogResult.Cancel) return;

            _currentSong = FormData.Song;

            int index = FindIndexItemById();
            UpdateListBox(index);
            Serializer.Serialize(AppdataPath, _songs);
        }
    }
}
