using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlaylistOfSongs.Model;

namespace PlaylistOfSongs.View
{
    public partial class AddSongForm : Form
    {
        public event EventHandler<SongAddedEventArgs> SongAdded;

        private Song song;

        public AddSongForm()
        {
            InitializeComponent();

            song = new Song();

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
                song.SongName = songNameText;
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
                song.ArtistName = artistNameText;
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
                song.DurationSeconds = durationSecondsValue;
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
            song.Genre = (Genre)GenreComboBox.SelectedItem;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (CorrectTextManager.IsCorrection(SongNameTextBox,
                    ArtistNameTextBox,
                    DurationSecondsTextBox))
            {
                SongAdded?.Invoke(this, new SongAddedEventArgs(song));
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

            openFileDialog.Filter = "(*.jpg;*.png;*.jpeg)|*.JPG;*.PNG;*.JPEG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                song.ImageBase64 = Convert.ToBase64String(imageArray);

                ArtistPictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    }
}
