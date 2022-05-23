using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Programming.Model;
using Programming.Model.Enums;
using Programming.Model.Movie;

namespace Programming.View.Controls
{
    /// <summary>
    /// Предоставляет реализацию по представлению фильмов.
    /// </summary>
    public partial class MoviesControl : UserControl
    {
        /// <summary>
        /// Количество элементов.
        /// </summary>
        private const int CountElements = 5;

        /// <summary>
        /// Выбранный фильм.
        /// </summary>
        private Movie _currentMovie;

        /// <summary>
        /// Коллекция фильмов.
        /// </summary>
        private List<Movie> _movies;  

        /// <summary>
        /// Создаёт экземпляр класса <see cref="MoviesControl"/>.
        /// </summary>
        public MoviesControl()
        {
            InitializeComponent();

            _movies = CreateMovies();
            MovieListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Инициализирует коллекцию фильмов.
        /// </summary>
        /// <returns>Возвращает коллекцию фильмов.</returns>
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

        /// <summary>
        /// Находит фильм, чей рейтинг больше остальных.
        /// </summary>
        /// <param name="films">Коллекция фильмов.</param>
        /// <returns>Возвращает индекс элемента коллекции, чей рейтинг больше остальных.</returns>
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
            if (MovieListBox.SelectedIndex == -1) return;

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
            if (MovieListBox.SelectedIndex == -1) return;

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
            if (MovieListBox.SelectedIndex == -1) return;

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
