using System.Security.AccessControl;

namespace _01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> dailyPortion = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> dailyStamina = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> peaks = new Dictionary<string, int>
            {
                {"Vihren", 80},
                {"Kutelo", 90},
                {"Banski Suhodol", 100},
                {"Polezhan", 60},
                {"Kamenitza", 70}
            };

            List<string> conqueredPeaks = new List<string>();

            while (dailyPortion.Any() && dailyStamina.Any() && conqueredPeaks.Count != 5)
            {
                int sum = dailyPortion.Peek() + dailyStamina.Peek();

                if (sum >= peaks.Values.First())
                {
                    conqueredPeaks.Add(peaks.Keys.First());
                    peaks.Remove(peaks.Keys.First());
                }

                dailyPortion.Pop();
                dailyStamina.Dequeue();
            }

            if (conqueredPeaks.Count == 5)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Any())
            {
                Console.WriteLine("Conquered peaks:");
                foreach (string peak in conqueredPeaks)
                {
                    Console.WriteLine(peak);
                }
            }
        }
    }
}
