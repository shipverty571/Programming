namespace Programming.Model.Geometry
{
    public class Rectangle
    {
        private int _height;

        private int _width;

        public Rectangle()
        {
            AllRectanglesCount++;
            Id = AllRectanglesCount;
        }

        public Rectangle(int height,
                         int width,
                         string color,
                         Point2D center)
        {
            Height = Height;
            Width = width;
            Color = color;
            Center = center;
            AllRectanglesCount++;
            Id = AllRectanglesCount;
        }

        public Point2D Center { get; set; }

        public string Color { get; set; }

        public int Id { get; }

        public static int AllRectanglesCount { get; private set; }

        public int Height
        {
            get => _height;
            set
            {
                Validator.AssertOnPositiveValue(nameof(Height), value);
                _height = value;
            }
        }

        public int Width
        {
            get => _width;
            set
            {
                Validator.AssertOnPositiveValue(nameof(Width), value);
                _width = value;
            }
        }
    }
}
