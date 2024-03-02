using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identities = new List<IIdentifiable>();

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age;
                string id;

                if (tokens.Length > 2)
                {
                    age = int.Parse(tokens[1]);
                    id = tokens[2];
                    identities.Add(new Citizen(id, name, age));
                }
                else
                {
                    id = tokens[1];
                    identities.Add(new Robot(id, name));
                }
            }

            string fakeID = Console.ReadLine();

            foreach (string id in identities.Select(x => x.Id).Where(i => i.EndsWith(fakeID)))
            {
                Console.WriteLine(id);
            }

            //foreach (IIdentifiable id in identities)
            //{
            //    if (id.Id.Substring(id.Id.Length - fakeID.Length) == fakeID)
            //    {
            //        Console.WriteLine(id.Id);
            //    }
            //}
        }
    }
}
