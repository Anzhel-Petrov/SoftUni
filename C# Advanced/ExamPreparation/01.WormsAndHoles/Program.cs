using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace _01.WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> worms = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> holes = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int matches = 0;
            int wormsCount = worms.Count;

            while (worms.Any() && holes.Any())
            {
                if (worms.Peek() == holes.Peek())
                {
                    worms.Pop();
                    holes.Dequeue();
                    matches++;
                }
                else
                {
                    holes.Dequeue();
                    if (worms.Peek() - 3 <= 0)
                    {
                        worms.Pop();
                    }
                    else
                    {
                        worms.Push(worms.Pop() - 3);
                    }
                }
            }

            if (matches == 0)
            {
                Console.WriteLine("There are no matches.");
            }
            else
            {
                Console.WriteLine($"Matches: {matches}");
            }

            if (worms.Count == 0 && matches == wormsCount)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else if (worms.Count == 0)
            {
                Console.WriteLine($"Worms left: none");
            }
            else
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }

            if (holes.Count == 0)
            {
                Console.WriteLine($"Holes left: none");
            }
            else
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }

            //if (worms.Count != 0)
            //{
            //    if (holes.Count != 0)
            //    {
            //        Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            //        Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            //        Console.WriteLine($"Holes left: none");
            //    }
            //}
            //else
            //{
            //    if (holes.Count != 0)
            //    {
            //        Console.WriteLine($"Worms left: none");
            //        Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            //    }
            //    else
            //    {
            //        if (wormsCount == matches)
            //        {
            //            Console.WriteLine($"Every worm found a suitable hole!");
            //            Console.WriteLine($"Holes left: none");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Worms left: none");
            //            Console.WriteLine($"Holes left: none");
            //        }
            //    }
            //}
        }
    }
}
