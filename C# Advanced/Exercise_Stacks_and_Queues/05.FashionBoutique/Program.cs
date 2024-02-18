using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stack<int> delivery = new(Console.ReadLine()
            //    .Split(' ')
            //    .Select(int.Parse)
            //    .ToArray());

            int[] delivery = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < delivery.Length; i++)
            {
                stack.Push(delivery[i]);
            }

            int rackCapacity = int.Parse(Console.ReadLine());

            int rackSum = 0;
            int rackNumbers = 0;

            while (stack.Count != 0)
            {
                if (rackSum + stack.Peek() <= rackCapacity)
                {
                    rackSum += stack.Pop();
                }
                else
                {
                    rackNumbers++;
                    rackSum = 0;
                }
            }

            if (rackSum > 0)
            {
                rackNumbers++;
            }

            Console.WriteLine(rackNumbers);
        }
    }
}