using System;

namespace PlaylistOfSongs.Model
{
    public static class Validator
    {
        public static void AssertCountSymbolsInRange(string nameProperty,
                                                int min,
                                                int max,
                                                string value)
        {
            if (!(value.Length >= min && value.Length <= max))
                throw new ArgumentException(
                    $"the number of characters of the {nameProperty} field must be in the range from {min} to {max} (inclusive)");
        }

        public static void AssertValueInRange(string nameProperty,
                                              int min,
                                              int max,
                                              int value)
        {
            if (!(value >= min && value <= max))
                throw new System.ArgumentException(
                    $"the value of the {nameProperty} field should be between {min} and {max} (inclusive)");
        }
    }
}
