namespace _02.FromLeftToRight;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine() ?? string.Empty);

        for (int i = 0; i < n; i++)
        {
            var numbers = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var biggerNumber = numbers[0] > numbers[1] ? numbers[0] : numbers[1];

            long sum = 0;
            while (biggerNumber != 0)
            {
                sum += biggerNumber % 10;
                biggerNumber /= 10;
            }

            Console.WriteLine(Math.Abs(sum));
        }
    }
}