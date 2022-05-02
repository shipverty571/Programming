using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Programming.Model;

namespace Programming.View.Controls
{
    public partial class MoviesControl : UserControl
    {
        const int CountElements = 5;

        private Movie _currentMovie;

        private List<Movie> _movies;  

        public MoviesControl()
        {
            InitializeComponent();

            _movies = CreateMovies();
            MovieListBox.SelectedIndex = 0;
        }

        private List<Movie> CreateMovies()
        {
            List<Movie> movies = new List<Movie>();
            var genres = Enum.GetValues(typeof(Genre));
            for (int i = 0; i < CountElements; i++)
            {
                _currentMovie = MovieFactory.Randomize();
                movies.Add(_currentMovie);
                MovieListBox.Items.Add($"Film {_currentMovie.Id}");
            }
            return movies;
        }

        private int FindFilmWithMaxRating(List<Movie> films)
        {
            int maxRatingIndex = 0;
            double maxValue = 0;
            for (int i = 0; i < CountElements; i++)
            {
                if (films[i].Rating > maxValue)
                {
                    maxValue = films[i].Rating;
                    maxRatingIndex = i;
                }
            }
            return maxRatingIndex;
        }

        private void MovieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndexFilm = MovieListBox.SelectedIndex;
            _currentMovie = _movies[selectedIndexFilm];
            NameMovieTextBox.Text = _currentMovie.Name;
            GenreMovieTextBox.Text = _currentMovie.Genre;
            YearReleaseMovieTextBox.Text = _currentMovie.ReleaseYear.ToString();
            DurationMinutesMovieTextBox.Text = _currentMovie.DurationMinutes.ToString();
            RatingMovieTextBox.Text = _currentMovie.Rating.ToString();
        }

        private void NameMovieTextBox_TextChanged(object sender, EventArgs e)
        {
            string nameFilmValue = NameMovieTextBox.Text;
            _currentMovie.Name = nameFilmValue;
        }

        private void GenreMovieTextBox_TextChanged(object sender, EventArgs e)
        {
            string genreFilmValue = GenreMovieTextBox.Text;
            _currentMovie.Genre = genreFilmValue;
        }

        private void YearReleaseMovieTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string currentYearRelease = YearReleaseMovieTextBox.Text;
                int yearReleaseFilmValue = int.Parse(currentYearRelease);
                _currentMovie.ReleaseYear = yearReleaseFilmValue;
            }
            catch
            {
                YearReleaseMovieTextBox.BackColor = AppColors.ErrorColor;
                return;
            }
            YearReleaseMovieTextBox.BackColor = AppColors.CorrectColor;
        }

        private void DurationMinutesMovieTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string currentDurationMinutes = DurationMinutesMovieTextBox.Text;
                int durationMinutesFilmValue = int.Parse(currentDurationMinutes);
                _currentMovie.DurationMinutes = durationMinutesFilmValue;
            }
            catch
            {
                DurationMinutesMovieTextBox.BackColor = AppColors.ErrorColor;
                return;
            }
            DurationMinutesMovieTextBox.BackColor = AppColors.CorrectColor;
        }

        private void RatingMovieTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string currentRating = RatingMovieTextBox.Text;
                double ratingMovieValue = double.Parse(currentRating);
                _currentMovie.Rating = ratingMovieValue;
            }
            catch
            {
                RatingMovieTextBox.BackColor = AppColors.ErrorColor;
                return;
            }
            RatingMovieTextBox.BackColor = AppColors.CorrectColor;
        }

        private void FindMovieButton_Click(object sender, EventArgs e)
        {
            int findMaxRatingIndex = FindFilmWithMaxRating(_movies);
            MovieListBox.SelectedIndex = findMaxRatingIndex;
        }
    }
}
