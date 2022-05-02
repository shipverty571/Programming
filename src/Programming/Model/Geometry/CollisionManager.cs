using System;

namespace Programming.Model
{
    public static class CollisionManager
    {
        public static bool IsCollision(Rectangle rectangle1, Rectangle rectangle2)
        {
            int dX = Math.Abs(rectangle1.Center.X - rectangle2.Center.X);
            int dY = Math.Abs(rectangle1.Center.Y - rectangle2.Center.Y);
            double widthDifference = Math.Abs(rectangle1.Width + rectangle2.Width) / 2.0;
            double lengthDifference = Math.Abs(rectangle1.Height + rectangle2.Height) / 2.0;

            //return (dX < widthDifference) && (dY < lengthDifference);
            return rectangle1.Center.X < rectangle2.Center.X + rectangle2.Width &&
                rectangle1.Center.X + rectangle1.Width > rectangle2.Center.X &&
                rectangle1.Center.Y < rectangle2.Center.Y + rectangle2.Height &&
                rectangle1.Height + rectangle1.Center.Y > rectangle2.Center.Y;
        }

        public static bool IsCollision(Ring ring1, Ring ring2)
        {
            int dX = Math.Abs(ring1.Center.X - ring2.Center.X);
            int dY = Math.Abs(ring1.Center.Y - ring2.Center.Y);
            double c = Math.Sqrt(dX*dX + dY*dY);

            return c < (ring1.OuterRadius + ring2.OuterRadius);
        }
    }
}
