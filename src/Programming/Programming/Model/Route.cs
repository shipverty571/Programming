namespace Programming.Model
{
    /// <summary>
    /// Хранит данные о рейсе.
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Время полёта в минутах.
        /// </summary>
        private int _flightTimeMinutes;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Route"/>.
        /// </summary>
        public Route()
        {

        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Route"/>.
        /// </summary>
        /// <param name="departurePoint">Место отправления.</param>
        /// <param name="destinationPoint">Место прибытия.</param>
        /// <param name="flightTimeMinutes">Время полёта в минутах. Должно быть положительным числом.</param>
        public Route(string departurePoint,
                     string destinationPoint,
                     int flightTimeMinutes)
        {
            DeparturePoint = departurePoint;
            DestinationPoint = destinationPoint;
            FlightTimeMinutes = flightTimeMinutes;
        }

        /// <summary>
        /// Возвращает и задаёт место отправления.
        /// </summary>
        public string DeparturePoint { get; set; }

        /// <summary>
        /// Возвращает и задаёт место прибытия.
        /// </summary>
        public string DestinationPoint { get; set; }

        /// <summary>
        /// Возвращает и задаёт время полёта в минутах. Должно быть положительным числом.
        /// </summary>
        public int FlightTimeMinutes
        {
            get => _flightTimeMinutes;
            set
            {
                Validator.AssertOnPositiveValue(nameof(FlightTimeMinutes), value);
                _flightTimeMinutes = value;
            }
        }
    }
}
