using System;
using System.Collections.Generic;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string input = "";
            while ((input = Console.ReadLine()) != "PARTY")
            {
                guests.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
            }

            Console.WriteLine(guests.Count);

            foreach (string VIP in guests)
            {
                if (char.IsDigit(VIP, 0))
                {
                    Console.WriteLine(VIP);
                }
            }

            foreach (string regular in guests)
            {
                if (!char.IsDigit(regular, 0))
                {
                    Console.WriteLine(regular);
                }
            }

            //foreach (var item in guests)
            //{
            //    char[] ch = item.ToCharArray();
            //    if (char.IsDigit(ch[0]))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //foreach (var item in guests)
            //{
            //    char[] ch = item.ToCharArray();
            //    if (char.IsLetter(ch[0]))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
        }
    }
}
