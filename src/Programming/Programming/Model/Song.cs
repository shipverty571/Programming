namespace Programming.Model
{
    /// <summary>
    /// Хранит данные о песне.
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Продолжительность песни в секундах.
        /// </summary>
        private int _durationSeconds;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Song"/>.
        /// </summary>
        public Song()
        {

        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Song"/>.
        /// </summary>
        /// <param name="musician">Имя (псевдоним) музыканта.</param>
        /// <param name="name">Название песни.</param>
        /// <param name="durationSeconds">Продолжительность песни в секундах. Должно быть положительным числом.</param>
        public Song(string musician,
                    string name,
                    int durationSeconds)
        {
            Musician = musician;
            Name = name;
            DurationSeconds = durationSeconds;
        }

        /// <summary>
        /// Возвращает и задаёт имя (псевдоним) музыканта.
        /// </summary>
        public string Musician { get; set; }

        /// <summary>
        /// Возвращает и задаёт название песни.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает и задаёт продолжительность песни в секундах. Должно быть положительным числом.
        /// </summary>
        public int DurationSeconds
        {
            get => _durationSeconds;
            set
            {
                Validator.AssertOnPositiveValue(nameof(DurationSeconds), value);
                _durationSeconds = value;
            }
        }
    }
}
