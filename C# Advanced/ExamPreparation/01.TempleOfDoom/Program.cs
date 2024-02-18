using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Stack<int> substances = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            List<int> challenges = new List<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList());

            while (substances.Any() && tools.Any()) 
            {
                if (challenges.Contains(tools.Peek() * substances.Peek()))
                {
                    challenges.Remove(tools.Dequeue() * substances.Pop());
                }
                else
                {
                    tools.Enqueue(tools.Dequeue() + 1);
                    if (substances.Peek() - 1 == 0)
                    {
                        substances.Pop();
                    }
                    else
                    {
                        substances.Push(substances.Pop() - 1);
                    }
                }
            }

            if (challenges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}
