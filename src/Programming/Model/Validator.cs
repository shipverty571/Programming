namespace Programming.Model
{
    public static class Validator
    {
        public static void AssertOnPositiveValue(string nameProperty, int value)
        {
            if (value <= 0)
            {
                throw new System.ArgumentException(
                    $"the value of the {nameProperty} field must be positive");
            }
        }

        public static void AssertOnPositiveValue(string nameProperty, double value)
        {
            if (value <= 0)
            {
                throw new System.ArgumentException(
                    $"the value of the {nameProperty} field must be positive");
            }
        }

        public static void AssertValueInRange(string nameProperty, int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new System.ArgumentException(
                        $"the value of the {nameProperty} field should be between {min} and {max} (inclusive)");
            }
        }

        public static void AssertValueInRange(string nameProperty, double value, double min, double max)
        {
            if (value < min || value > max)
            {
                throw new System.ArgumentException(
                        $"the value of the {nameProperty} field should be between {min} and {max} (inclusive)");
            }
        }
    }
}
