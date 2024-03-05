using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int heroCount = int.Parse(Console.ReadLine());
            int raidPower = 0;
            List<IBaseHero> raidGroup = new List<IBaseHero>();

            for (int i = 0; i < heroCount; i++)
            {
                string playerName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    IBaseHero baseHero = BaseHeroFactory.GetBaseHero(heroType, playerName);
                    raidGroup.Add(baseHero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (IBaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                raidPower += hero.Power;
            }

            if (raidPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
