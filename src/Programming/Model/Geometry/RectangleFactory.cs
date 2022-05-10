using System;
using Programming.Model.Enums;

namespace Programming.Model.Geometry
{
    public static class RectangleFactory
    {
        private const int Margin = 15;

        private static Random _random;
        
        static RectangleFactory()
        {
            _random = new Random();
        }

        public static Rectangle Randomize(int widthCanvas, int heightCanvas)
        {
            var colors = Enum.GetValues(typeof(Colors));
            Rectangle rectangle = new Rectangle();
            rectangle.Width = _random.Next(30, 100);
            rectangle.Height = _random.Next(30, 100);
            rectangle.Center = new Point2D(_random.Next(Margin, widthCanvas - rectangle.Width - Margin),
                                           _random.Next(Margin, heightCanvas - rectangle.Height - Margin));
            rectangle.Color = colors.GetValue(_random.Next(0, colors.Length)).ToString();
            return rectangle;
        }

        public static Rectangle Randomize()
        {
            var colors = Enum.GetValues(typeof(Colors));
            Rectangle rectangle = new Rectangle();
            rectangle.Center = new Point2D(_random.Next(1, 500), _random.Next(1, 500));
            rectangle.Width = _random.Next(30, 100);
            rectangle.Height = _random.Next(30, 100);
            rectangle.Color = colors.GetValue(_random.Next(0, colors.Length)).ToString();
            return rectangle;
        }
    }
}
