using System;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string _name;

        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }

        public string Name 
        { 
            get { return _name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                _name = value;
            }
        }
        public Stats Stats { get; private set; }
        public double SkillLevel { get { return Stats.GetSkillLevel; } }
    }
}
