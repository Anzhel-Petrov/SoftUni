using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string _name;
        private List<Player> _players;

        public Team(string name)
        {
            Name = name;
            _players = new List<Player>();
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
        public int Rating { get { return CalculateRating(); } }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player player = _players.FirstOrDefault(x => x.Name == name);

            if (player is null)
            {
                throw new ArgumentException($"Player {name} is not in {Name} team.");
            }

            _players.Remove(player);
        }

        private int CalculateRating()
        {
            return (int)Math.Round(_players.Sum(x => x.SkillLevel));
        }
    }
}
