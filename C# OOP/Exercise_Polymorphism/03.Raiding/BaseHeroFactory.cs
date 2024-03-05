using System;

namespace _03.Raiding
{
    public class BaseHeroFactory
    {
        public static IBaseHero GetBaseHero(string type, string name)
        {
            IBaseHero heroType = null;
            if (type.ToLower().Equals("druid")) 
            {
                heroType = new Druid(name);
            }
            else if (type.ToLower().Equals("paladin"))
            {
                heroType = new Paladin(name);
            }
            else if (type.ToLower().Equals("warrior"))
            {
                heroType = new Warrior(name);
            }
            else if (type.ToLower().Equals("rogue"))
            {
                heroType = new Rogue(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return heroType;
        }
    }
}
