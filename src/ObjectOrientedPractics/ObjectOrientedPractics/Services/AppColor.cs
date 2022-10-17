using System.Drawing;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Хранит данные об используемых цветах.
    /// </summary>
    public static class AppColor
    {
        /// <summary>
        /// Цвет некорректного значения.
        /// </summary>
        public static readonly Color ErrorColor = Color.FromArgb(255, 182, 193);

        /// <summary>
        /// Цвет корректного значения.
        /// </summary>
        public static readonly Color CorrectColor = Color.FromArgb(255, 255, 255);
    }
}
