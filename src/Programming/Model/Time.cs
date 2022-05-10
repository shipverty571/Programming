namespace Programming.Model
{
    public class Time
    {
        private int _hours;

        private int _minutes;

        private int _seconds;

        public Time()
        {

        }

        public Time(int hours,
                    int minutes,
                    int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Hours
        {
            get => _hours;
            set
            {
                Validator.AssertValueInRange(nameof(Hours), value, 0, 23);
                _hours = value;
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                Validator.AssertValueInRange(nameof(Minutes), value, 0, 59);
                _minutes = value;
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                Validator.AssertValueInRange(nameof(Seconds), value, 0, 59);
                _seconds = value;
            }
        }
    }

}
