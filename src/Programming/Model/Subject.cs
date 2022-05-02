namespace Programming.Model
{
    public class Subject
    {
        private int _mark;

        private int _amountHours;

        public Subject()
        {

        }

        public Subject(string name,
                          int amountHours,
                          int mark)
        {
            Name = name;
            AmountHours = amountHours;
            Mark = mark;
        }

        public string Name { get; set; }

        public int AmountHours
        {
            get
            {
                return _amountHours;
            }
            set
            {
                Validator.AssertOnPositiveValue(nameof(AmountHours), value);
                _amountHours = value;
            }
        }

        public int Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                Validator.AssertValueInRange(nameof(Mark), value, 0, 5);
                _mark = value;
            }
        }
    }
}
