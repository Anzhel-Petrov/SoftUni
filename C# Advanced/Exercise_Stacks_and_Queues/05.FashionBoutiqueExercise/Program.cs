namespace _05.FashionBoutiqueExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> delivery = new(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            int rackCapacity = int.Parse(Console.ReadLine());

            int currentRackCapacity = rackCapacity;
            int rackNumbers = 0;

            if (delivery.Any())
            {
                rackNumbers++;
            }

            while (delivery.Any())
            {
                if (delivery.Peek() <= currentRackCapacity)
                {
                    currentRackCapacity -= delivery.Pop();
                }
                else
                {
                    rackNumbers++;
                    currentRackCapacity = rackCapacity;
                }
            }

            Console.WriteLine(rackNumbers);
        }
    }
}
