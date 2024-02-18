using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.RubberDuckDebuggers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> time = new Queue<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> task = new Stack<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int DartVaderDuck = 0;
            int ThorDuck = 0;
            int BigBlueRubberDucky = 0;
            int SmallYellowRubberDucky = 0;

            while (time.Any() || task.Any())
            {
                int result = time.Peek() * task.Peek();

                switch (result)
                {
                    case >=0 and <=60:
                        DartVaderDuck++;
                        time.Dequeue();
                        task.Pop();
                        break;

                    case >= 61 and <= 120:
                        ThorDuck++;
                        time.Dequeue();
                        task.Pop();
                        break;

                    case >= 121 and <= 180:
                        BigBlueRubberDucky++;
                        time.Dequeue();
                        task.Pop();
                        break;

                    case >= 181 and <= 240:
                        SmallYellowRubberDucky++;
                        time.Dequeue();
                        task.Pop();
                        break;

                    case >= 241:
                        time.Enqueue(time.Dequeue());
                        task.Push(task.Pop() - 2);
                        break;
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {DartVaderDuck}");
            Console.WriteLine($"Thor Ducky: {ThorDuck}");
            Console.WriteLine($"Big Blue Rubber Ducky: {BigBlueRubberDucky}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {SmallYellowRubberDucky}");
        }
    }
}
