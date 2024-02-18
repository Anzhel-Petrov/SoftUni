using System.Diagnostics.Metrics;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRoutes = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < numberOfRoutes; i++)
            {
                queue.Enqueue(Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray());
            }

            int startPosition = 0;
            
            while (true)
            {
                int fuel = 0;

                foreach (int[] pump in queue)
                {
                    fuel += pump[0] - pump[1];

                    if (fuel < 0)
                    {
                        //queue.Dequeue();
                        //queue.Enqueue(pump);
                        queue.Enqueue(queue.Dequeue());
                        startPosition++;
                        break;
                    }
                }

                if (fuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(startPosition);
        }
    }
}
