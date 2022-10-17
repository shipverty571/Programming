using System;

namespace PlaylistOfSongs.Model
{
    /// <summary>
    /// Предоставляет методы для проверки входных данных.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверяет, что количество символов в строке находится в нужном диапазоне.
        /// </summary>
        /// <param name="nameProperty">Имя свойства, откуда был вызван метод.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <param name="value">Строка.</param>
        /// <exception cref="ArgumentException">Выбрасывается, когда количество символов строки не входит в диапазон.</exception>
        public static void AssertCountSymbolsInRange(string nameProperty,
                                                int min,
                                                int max,
                                                string value)
        {
            if (!(value.Length >= min && value.Length <= max))
                throw new ArgumentException(
                    $"the number of characters of the {nameProperty} field must be in the range from {min} to {max} (inclusive)");
        }

        /// <summary>
        /// Проверяет, что число находится в нужном диапазоне.
        /// </summary>
        /// <param name="nameProperty">Имя свойства, откуда был вызван метод.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <param name="value">Число.</param>
        /// <exception cref="System.ArgumentException">Выбрасывается, когда число не входит в диапазон.</exception>
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
