using System.Text;

namespace _01.Offroad_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> initialFuel = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Queue<int> consumptionIndexes = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            StringBuilder sb = new StringBuilder();

            int[] altitudes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < altitudes.Length; i++)
            {
                if (initialFuel.Pop() - consumptionIndexes.Dequeue() >= altitudes[i])
                {
                    Console.WriteLine($"John has reached: Altitude {i + 1}");
                    sb.Append($"Altitude {i + 1}, ");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {i + 1}");
                    Console.WriteLine($"John failed to reach the top.");

                    if (i == 0)
                    {
                        Console.WriteLine("John didn't reach any altitude.");
                    }
                    else
                    {
                        sb.Remove(sb.Length - 2, 2);
                        Console.WriteLine($"Reached altitudes: {sb.ToString().Trim()}");
                    }
                    return;
                }
            }

            Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
        }
    }
}
