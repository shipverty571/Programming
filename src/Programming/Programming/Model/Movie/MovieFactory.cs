using System;
using Programming.Model.Enums;

namespace Programming.Model.Movie
{
    /// <summary>
    /// Предоставляет методы для создания фильмов.
    /// </summary>
    public static class MovieFactory
    {
        /// <summary>
        /// Случайные значения.
        /// </summary>
        private static Random _random;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="MovieFactory"/>.
        /// </summary>
        static MovieFactory()
        {
            _random = new Random();
        }

        /// <summary>
        /// Создаёт фильм со случайными значениями жанра, рейтинга, года релиза, названия и продолжительности в минутах.
        /// </summary>
        /// <returns>Возвращает объект Movie.</returns>
        public static Movie Randomize()
        {
            var genres = Enum.GetValues(typeof(Genre));
            Movie movie = new Movie();
            movie.Rating = _random.Next(101) / 10.0;
            movie.ReleaseYear = _random.Next(1900, 2023);
            movie.Genre = genres.GetValue(_random.Next(0, genres.Length)).ToString();
            movie.Name = $"Film {movie.Genre} {movie.ReleaseYear}";
            movie.DurationMinutes = _random.Next(1, 151);
            return movie;
        }
    }
}
