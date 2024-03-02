namespace Shapes
{
    public class Rectangle : Shape
    {
        private double _height;
        private double _width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height 
        { 
            get => _height; 
            protected set
            {
                _height = value;
            }
        }
        public double Width 
        {
            get => _width;
            protected set
            {
                _width = value;
            }
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override string Draw()
        {
            return base.Draw();
        }
    }
}
