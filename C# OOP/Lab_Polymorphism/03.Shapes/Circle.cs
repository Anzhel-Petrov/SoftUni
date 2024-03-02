using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius 
        {
            get => _radius;
            protected set
            {
                _radius = value;
            }
        }

        public override double CalculateArea()
        {
            //return Math.PI * Radius * Radius;
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string Draw()
        {
            return base.Draw();
        }
    }
}
