using System.Drawing;

namespace Programming.Model
{
    /// <summary>
    /// Хранит данные об используемых цветах.
    /// </summary>
    public static class AppColors
    {
        /// <summary>
        /// Цвет корректного значения.
        /// </summary>
        public static readonly Color CorrectColor = Color.FromArgb(255, 255, 255);

        /// <summary>
        /// Цвет некорректного значения.
        /// </summary>
        public static readonly Color ErrorColor = Color.FromArgb(255, 182, 193);

        /// <summary>
        /// Цвет пересечения фигур.
        /// </summary>
        public static readonly Color IsCollision = Color.FromArgb(127, 255, 127, 127);

        /// <summary>
        /// Цвет фигур, которые не пересекаются.
        /// </summary>
        public static readonly Color IsNotCollision = Color.FromArgb(127, 127, 255, 127);

        /// <summary>
        /// Цвет при выборе Spring из списка.
        /// </summary>
        public static readonly Color Spring = Color.FromArgb(226, 215, 69);

        /// <summary>
        /// Цвет при выборе Autumn из списка.
        /// </summary>
        public static readonly Color Autumn = Color.FromArgb(226, 156, 69);

        /// <summary>
        /// Цвет при выборе Winter из списка.
        /// </summary>
        public static readonly Color Winter = Color.FromArgb(69, 83, 226);

        /// <summary>
        /// Цвет при выборе Summer из списка.
        /// </summary>
        public static readonly Color Summer = Color.FromArgb(85, 156, 69);
    }
}