namespace _01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textile = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> medicaments = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> items = new Dictionary<string, int>()
            {
                { "Patch", 0 },
                { "Bandage", 0 },
                { "MedKit", 0 }
            };

            while (textile.Any() && medicaments.Any())
            {
                int sum = textile.Peek() + medicaments.Peek();
                if (sum < 101)
                {
                    if (sum == 30)
                    {
                        items["Patch"]++;
                    }
                    else if (sum == 40)
                    {
                        items["Bandage"]++;
                    }
                    else if (sum == 100)
                    {
                        items["MedKit"]++;
                    }
                    else
                    {
                        textile.Dequeue();
                        medicaments.Push(medicaments.Pop() + 10);
                        continue;
                    }

                    textile.Dequeue();
                    medicaments.Pop();
                }
                else
                {
                    items["MedKit"]++;
                    textile.Dequeue();
                    medicaments.Pop();
                    medicaments.Push(medicaments.Pop() + (sum - 100));
                }
            }

            if (textile.Any() || medicaments.Any())
            {
                if (!medicaments.Any())
                {
                    Console.WriteLine("Medicaments are empty.");
                }
                else if (!textile.Any())
                {
                    Console.WriteLine("Textiles are empty.");
                }
            }
            else
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            //foreach (KeyValuePair<string, int> item in items.Where(x => x.Value != 0).OrderBy(x => x.Key).OrderByDescending(x => x.Value))
            foreach (KeyValuePair<string, int> item in items.Where(x => x.Value != 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textile.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
            }
        }
    }
}
