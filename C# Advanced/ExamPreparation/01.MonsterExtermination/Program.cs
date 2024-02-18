using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> monstersArmor = new Queue<int>(
                Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> soldiersStrike = new Stack<int>(
                Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int killedMonsters = 0;

            while (monstersArmor.Any() && soldiersStrike.Any())
            {
                if (monstersArmor.Peek() <= soldiersStrike.Peek())
                {
                    //soldiersStrike.Push((soldiersStrike.Pop() - monstersArmor.Dequeue()) + soldiersStrike.Pop());
                    int remainingStrike = soldiersStrike.Peek() - monstersArmor.Peek();
                    killedMonsters++;

                    if (remainingStrike == 0)
                    {
                        soldiersStrike.Pop();
                        monstersArmor.Dequeue();
                    }
                    else
                    {
                        monstersArmor.Dequeue();
                        if (soldiersStrike.Count == 1)
                        {
                            soldiersStrike.Pop();
                            soldiersStrike.Push(remainingStrike);
                            continue;
                        }
                        else
                        {
                            soldiersStrike.Pop();
                            int tempStrike = remainingStrike;
                            soldiersStrike.Push(soldiersStrike.Pop() + tempStrike);
                        }
                    }
                }
                else
                {
                    monstersArmor.Enqueue(monstersArmor.Dequeue() - soldiersStrike.Pop());
                }
            }

            if (!monstersArmor.Any())
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if (!soldiersStrike.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {killedMonsters}");

        }
    }
}
