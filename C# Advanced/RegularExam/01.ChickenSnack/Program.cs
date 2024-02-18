using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> money = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> price = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int foodEaten = 0;

            while (money.Any() && price.Any())
            {
                if (money.Peek() >= price.Peek())
                {
                    if (money.Peek() > price.Peek())
                    {
                        int change = money.Pop() - price.Dequeue();
                        if (money.Any())
                        {
                            money.Push(money.Pop() + change);
                        }
                        else
                        {
                            money.Push(change);
                        }
                    }
                    else
                    {
                        money.Pop();
                        price.Dequeue();
                    }

                    foodEaten++;
                    continue;
                }
                price.Dequeue();
                money.Pop();
            }

            if (foodEaten >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {foodEaten} foods.");
            }
            else if (foodEaten > 1)
            {
                Console.WriteLine($"Henry ate: {foodEaten} foods.");
            }
            else if (foodEaten == 1)
            {
                Console.WriteLine($"Henry ate: {foodEaten} food.");
            }
            else
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }

        }
    }
}
