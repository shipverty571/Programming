using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PlaylistOfSongs.Model;
using PlaylistOfSongs.Properties;

namespace PlaylistOfSongs.View
{
    /// <summary>
    /// Предоставляет реализацию по представлению дочернего окна.
    /// </summary>
    public partial class SongForm : Form
    {
        /// <summary>
        /// Фильтр для диалогового окна.
        /// </summary>
        private string _filter = "(*.jpg;*.png;*.jpeg)|*.JPG;*.PNG;*.JPEG";

        /// <summary>
        /// Песня.
        /// </summary>
        private Song _song;

        public SongForm()
        {
            InitializeComponent();

            var genre = Enum.GetValues(typeof(Genre));

            foreach (var value in genre)
                GenreComboBox.Items.Add(value);

            _song = new Song();
            _song.DurationSeconds = FormData.Song.DurationSeconds;
            _song.ArtistName = FormData.Song.ArtistName;
            _song.ImageBase64 = FormData.Song.ImageBase64;
            _song.SongName = FormData.Song.SongName;
            _song.Genre = FormData.Song.Genre;

            InsertInformationTextboxes(_song);
        }

        private void InsertInformationTextboxes(Song song)
        {
            SongNameTextBox.Text = song.SongName;
            ArtistNameTextBox.Text = song.ArtistName;
            DurationSecondsTextBox.Text = song.DurationSeconds.ToString();
            GenreComboBox.SelectedItem = song.Genre;

            if (song.ImageBase64 != null)
                ArtistPictureBox.Image = Image.FromStream(new MemoryStream(
                    Convert.FromBase64String(song.ImageBase64)));
            else
                ArtistPictureBox.Image = null;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CorrectTextManager.IsCorrection(SongNameTextBox,
                    ArtistNameTextBox,
                    DurationSecondsTextBox))
            {
                FormData.Song = _song;
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect values have been entered. Fix it and try again.", "Error");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = _filter;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                _song.ImageBase64 = Convert.ToBase64String(imageArray);
                ArtistPictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void DeleteImageButton_Click(object sender, EventArgs e)
        {
            if (_song.ImageBase64 == null) return;

            DialogResult dialogResult = MessageBox.Show("Do you really want to delete the image?",
                "Deleting an image",
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                _song.ImageBase64 = null;
                ArtistPictureBox.Image = null;
            }
        }

        private void SongNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string songNameText = SongNameTextBox.Text;
                _song.SongName = songNameText;
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
                string artistNameText = ArtistNameTextBox.Text;
                _song.ArtistName = artistNameText;
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
                string durationSecondsText = DurationSecondsTextBox.Text;
                int durationSecondsValue = int.Parse(durationSecondsText);
                _song.DurationSeconds = durationSecondsValue;
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
            _song.Genre = (Genre)GenreComboBox.SelectedItem;
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
