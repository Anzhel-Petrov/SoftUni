namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0.0;

            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());

                area = side * side;
            }
            else if (figure == "rectangle")
            {
                double height = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());

                area = height * width;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());

                area = Math.PI * Math.Pow(radius, 2);
            }
            else if (figure == "triangle")
            {
                double tBase = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                area = tBase * height / 2;
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
