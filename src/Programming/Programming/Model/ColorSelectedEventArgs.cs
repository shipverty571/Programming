using System;
using System.Drawing;

namespace Programming.Model
{
    public class ColorSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="ColorSelectedEventArgs"/>.
        /// </summary>
        /// <param name="color">Цвет.</param>
        public ColorSelectedEventArgs(Color color)
        {
            Color = color;
        }

        /// <summary>
        /// Возвращает и задаёт цвет.
        /// </summary>
        public Color Color { get; set; }
    }
}
