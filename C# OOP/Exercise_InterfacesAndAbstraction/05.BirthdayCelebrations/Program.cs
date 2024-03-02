using _05.BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Xml.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> identities = new List<IBirthable>();

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                string name = tokens[1];
                int age;
                string id;
                string birthday;

                switch (type)
                {
                    case "Citizen":
                        age = int.Parse(tokens[2]);
                        id = tokens[3];
                        birthday = tokens[4];
                        identities.Add(new Citizen(id, name, age, birthday));
                        break;
                    case "Pet":
                        birthday = tokens[2];
                        identities.Add(new Pet(name, birthday));
                        break;
                    default:
                        break;
                }
            }

            string year = Console.ReadLine();

            foreach (string birthday in identities.Select(x => x.Birthday).Where(i => i.EndsWith(year)))
            {
                Console.WriteLine(birthday);
            }

            //foreach (var birthday in identities)
            //{
            //    string birthYear = birthday.Birthday.Split('/')[2];
            //    if (birthYear == year)
            //    {
            //        Console.WriteLine(birthday.Birthday.ToString());
            //    }
            //}
        }
    }
}
