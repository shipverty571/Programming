using System.Text.RegularExpressions;

namespace Programming.Model
{
    public class Contact
    {
        private string _number;

        private string _name;

        private string _surname;

        public Contact()
        {

        }

        public Contact(string name,
                       string surname,
                       string number)
        {
            Name = name;
            Surname = surname;
            Number = number;
        }

        public string Name
        {
            get => _name;
            set => _name = AssertStringContainsOnlyLetters(nameof(Name), value);
        }

        public string Surname
        {
            get => _surname;
            set => _surname = AssertStringContainsOnlyLetters(nameof(Surname), value);
        }

        public string Number
        {
            get => _number;
            set
            {
                if (!long.TryParse(value, out var num))
                {
                    throw new System.ArgumentException(
                        $"the value of the {nameof(Number)} field must consist of digits only");
                }

                if (value.Length != 11)
                {
                    throw new System.ArgumentException(
                        $"the value of the {nameof(Number)} field must consist of 11 digits");
                }

                _number = value;
            }
        }

        private string AssertStringContainsOnlyLetters(string nameProperty, string value)
        {
            if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
            {
                throw new System.ArgumentException(
                    $"the value of the {nameProperty} field should consist only of English letters.");
            }

            return value;
        }
    }
}
