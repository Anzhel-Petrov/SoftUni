namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int intelligenceValue = int.Parse(Console.ReadLine());

            int currentBarrel = barrelSize;

            int bulletsFired = 0;

            while (bullets.Any() && locks.Any())
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                currentBarrel--;
                bulletsFired++;

                if (currentBarrel == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    currentBarrel = barrelSize;
                }
            }

            int bulletsCostTotal = bulletsFired * pricePerBullet;

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - bulletsCostTotal}");
            }
        }
    }
}
