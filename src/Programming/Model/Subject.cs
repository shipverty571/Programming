namespace Programming.Model
{
    /// <summary>
    /// Хранит данные о дисциплине.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Оценка по дисциплине.
        /// </summary>
        private int _mark;

        /// <summary>
        /// Количество академических часов дисциплины.
        /// </summary>
        private int _amountHours;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Subject"/>.
        /// </summary>
        public Subject()
        {

        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Subject"/>.
        /// </summary>
        /// <param name="name">Название дисциплины.</param>
        /// <param name="amountHours">Количество академических часов дисциплины. Должно быть положительным числом.</param>
        /// <param name="mark">Оценка по дисциплине. Должно быть в диапазоне от 0 до 5 (включительно).</param>
        public Subject(string name,
                          int amountHours,
                          int mark)
        {
            Name = name;
            AmountHours = amountHours;
            Mark = mark;
        }

        /// <summary>
        /// Возвращает и задаёт название дисциплины.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает и задаёт количество академических часов дисциплины. Должно быть положительным числом.
        /// </summary>
        public int AmountHours
        {
            get => _amountHours;
            set
            {
                Validator.AssertOnPositiveValue(nameof(AmountHours), value);
                _amountHours = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт оценку по дисциплине. Должно быть в диапазоне от 0 до 5 (включительно).
        /// </summary>
        public int Mark
        {
            get => _mark;
            set
            {
                Validator.AssertValueInRange(nameof(Mark), value, 0, 6);
                _mark = value;
            }
        }
    }
}
