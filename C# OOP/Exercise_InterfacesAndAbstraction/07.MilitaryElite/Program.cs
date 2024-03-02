using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input = "";
            while ((input = Console.ReadLine()) != "End") 
            { 
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string soldierType = tokens[0];
                string id = tokens[1];
                string fistName = tokens[2];
                string lastName = tokens[3];

                

                switch (soldierType)
                {
                    case "Private":
                        {
                            decimal salary = decimal.Parse(tokens[4]);
                            Private soldier = new Private(id, fistName, lastName, salary);
                            soldiers.Add(soldier);
                            break;
                        }
                    case "LieutenantGeneral":
                        {
                            decimal salary = decimal.Parse(tokens[4]);
                            List<IPrivate> privates = new List<IPrivate>();
                            for (int i = 5; i < tokens.Length; i++)
                            {
                                privates.Add((IPrivate)soldiers.FirstOrDefault(x => x.Id == tokens[i]));
                            }
                            
                            LeutenantGeneral leutenantGeneral = new LeutenantGeneral(id, fistName, lastName, salary, privates);
                            soldiers.Add(leutenantGeneral);
                            break;
                        }
                    case "Commando":
                        {
                            decimal salary = decimal.Parse(tokens[4]);

                            break;
                        }
                    default:
                        break;
                }
            }

            foreach (ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
