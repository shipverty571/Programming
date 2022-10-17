using System;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Предоставляет методы для проверки входных данных.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Проверяет, что число находится в определённом диапазоне.
        /// </summary>
        /// <param name="propertyName">Имя свойства, откуда был вызван метод.</param>
        /// <param name="value">Число.</param>
        /// <param name="min">Левая граница диапазона.</param>
        /// <param name="max">Правая граница диапазона.</param>
        /// <exception cref="System.ArgumentException">Выбрасывается, если число находится вне диапазона.</exception>
        public static void AssertValueInRange(string propertyName, double value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new System.ArgumentException(
                    $"the value of the {propertyName} field should be between {min}" +
                    $" and {max} (inclusive).");
            }
        }

        /// <summary>
        /// Проверяет, что количество символов в строке не превышает предела.
        /// </summary>
        /// <param name="propertyName">Имя свойства, откуда был вызван метод.</param>
        /// <param name="maxLength">Максимальное значение.</param>
        /// <param name="value">Строка.</param>
        /// <exception cref="ArgumentException">Выбрасывается, когда количество символов строки превышает предел.</exception>
        public static void AssertStringOnLength(string propertyName, string value, int maxLength)
        {
            if (value.Length > maxLength)
                throw new ArgumentException(
                    $"number of characters in the field {propertyName}" +
                    $" must not exceed {maxLength}.");
        }

        /// <summary>
        /// Проверяет, что количество цифр в числе равно заданному.
        /// </summary>
        /// <param name="propertyName">Имя свойства, откуда был вызван метод.</param>
        /// <param name="length">Заданная длина.</param>
        /// <param name="value">Число.</param>
        /// <exception cref="ArgumentException">Выбрасывается, когда количество цифр числа не равно заданному.</exception>
        public static void AssertStringLength(string propertyName, int value, int length)
        {
            if (value.ToString().Length != length)
                throw new ArgumentException(
                    $"the number of characters in {propertyName} must be equal to {length}.");
        }
    }
}
