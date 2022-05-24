namespace PlaylistOfSongs.Model
{
    /// <summary>
    /// Хранит данные о песне.
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Уникальный идентификатор для всех объектов данного класса.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Количество песен.
        /// </summary>
        private static int _allSongsCount;

        /// <summary>
        /// Название песни.
        /// </summary>
        private string _songName;

        /// <summary>
        /// Имя исполнителя.
        /// </summary>
        private string _artistName;

        /// <summary>
        /// Продолжительность песни в секундах.
        /// </summary>
        private int _durationSeconds;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Song"/>.
        /// </summary>
        public Song()
        {
            _allSongsCount++;
            _id = _allSongsCount;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Song"/>.
        /// </summary>
        /// <param name="songName">Название песни. Должно быть не более 55 символов.</param>
        /// <param name="artistName">Имя исполнителя. Должно быть не более 50 символов.</param>
        /// <param name="durationSeconds">Продолжительность в секундах. Должно быть не более 7200.</param>
        /// <param name="genre">Жанр песни.</param>
        public Song(string songName,
            string artistName,
            int durationSeconds,
            Genre genre)
        {
            SongName = songName;
            ArtistName = artistName;
            DurationSeconds = durationSeconds;
            Genre = genre;
            _allSongsCount++;
            _id = _allSongsCount;
        }

        public Song(string songName,
            string artistName,
            int durationSeconds,
            Genre genre,
            string imageBase64)
        {
            SongName = songName;
            ArtistName = artistName;
            DurationSeconds = durationSeconds;
            Genre = genre;
            ImageBase64 = imageBase64;
            _allSongsCount++;
            _id = _allSongsCount;
        }

        public string ImageBase64 { get; set; }

        public int Id => _id;

        public Genre Genre { get; set; }

        public int DurationSeconds
        {
            get => _durationSeconds;
            set
            {
                Validator.AssertValueInRange(nameof(DurationSeconds), 1, 7200, value);
                _durationSeconds = value;
            }
        }
        public string ArtistName
        {
            get => _artistName;
            set
            {
                Validator.AssertCountSymbolsInRange(nameof(ArtistName), 1, 50, value);
                _artistName = value;
            }
        }

        public string SongName
        {
            get => _songName;
            set
            {
                Validator.AssertCountSymbolsInRange(nameof(SongName), 1, 55, value);
                _songName = value;
            }
        }
    }
}
