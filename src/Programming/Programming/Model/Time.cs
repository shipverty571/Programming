namespace Programming.Model
{
    /// <summary>
    /// Хранит данные о времени.
    /// </summary>
    public class Time
    {
        /// <summary>
        /// Количество часов.
        /// </summary>
        private int _hours;

        /// <summary>
        /// Количество минут.
        /// </summary>
        private int _minutes;

        /// <summary>
        /// Количество секунд.
        /// </summary>
        private int _seconds;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Time"/>.
        /// </summary>
        public Time()
        {

        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Time"/>.
        /// </summary>
        /// <param name="hours">Количество часов. Должно быть положительным числом.
        /// Должно быть в пределах от 0 до 23 (включительно).</param>
        /// <param name="minutes">Количество минут. Должно быть положительным числом.
        /// Должно быть в пределах от 0 до 59 (включительно).</param>
        /// <param name="seconds">Количество секунд. Должно быть положительным числом.
        /// Должно быть в пределах от 0 до 59 (включительно).</param>
        public Time(int hours,
                    int minutes,
                    int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        /// <summary>
        /// Возвращает и задаёт количество часов. Должно быть положительным числом.
        /// Должно быть в пределах от 0 до 23 (включительно).
        /// </summary>
        public int Hours
        {
            get => _hours;
            set
            {
                Validator.AssertOnPositiveValue(nameof(Hours), value);
                Validator.AssertValueInRange(nameof(Hours), value, -1, 24);
                _hours = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт количество минут. Должно быть положительным числом.
        /// Должно быть в пределах от 0 до 59 (включительно).
        /// </summary>
        public int Minutes
        {
            get => _minutes;
            set
            {
                Validator.AssertOnPositiveValue(nameof(Minutes), value);
                Validator.AssertValueInRange(nameof(Minutes), value, -1, 60);
                _minutes = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт количество секунд. Должно быть положительным числом.
        /// Должно быть в пределах от 0 до 59 (включительно).
        /// </summary>
        public int Seconds
        {
            get => _seconds;
            set
            {
                Validator.AssertOnPositiveValue(nameof(Seconds), value);
                Validator.AssertValueInRange(nameof(Seconds), value, -1, 60);
                _seconds = value;
            }
        }
    }

}
