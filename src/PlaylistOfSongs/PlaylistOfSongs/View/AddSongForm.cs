using System;
using System.Drawing;
using System.Windows.Forms;
using PlaylistOfSongs.Model;
using PlaylistOfSongs.Properties;

namespace PlaylistOfSongs.View
{
    /// <summary>
    /// Предоставляет реализацию по представлению дочернего окна.
    /// </summary>
    public partial class AddSongForm : Form
    {
        /// <summary>
        /// Песня.
        /// </summary>
        private Song _song;

        /// <summary>
        /// Фильтр
        /// </summary>
        private string _filter = "(*.jpg;*.png;*.jpeg)|*.JPG;*.PNG;*.JPEG";

        /// <summary>
        /// Создаёт экземпляр класса <see cref="AddSongForm"/>.
        /// </summary>
        public AddSongForm()
        {
            InitializeComponent();

            _song = new Song();
            SongNameTextBox.Text = "Song name";
            ArtistNameTextBox.Text = "Artist name";
            DurationSecondsTextBox.Text = "100";
            var genre = Enum.GetValues(typeof(Genre));

            foreach (var value in genre)
                GenreComboBox.Items.Add(value);

            GenreComboBox.SelectedIndex = 0;
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

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CorrectTextManager.IsCorrection(SongNameTextBox,
                    ArtistNameTextBox,
                    DurationSecondsTextBox))
            {
                FormData.Song = _song;
                DialogResult = DialogResult.OK;
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
