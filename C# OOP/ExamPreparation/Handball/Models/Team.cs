using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string _name;
        private int _pointsEarned;
        private List<IPlayer> _players;

        public Team(string name)
        {
            Name = name;
            _players = new List<IPlayer>();
        }
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                _name = value;
            }
        }

        public int PointsEarned => _pointsEarned;
        public double OverallRating => this.Players.Count == 0 ? 0 : Math.Round(this._players.Average(p => p.Rating), 2);
        public IReadOnlyCollection<IPlayer> Players => _players.AsReadOnly();
        public void SignContract(IPlayer player)
        {
            _players.Add(player);
        }

        public void Win()
        {
            _pointsEarned += 3;
            foreach (IPlayer player in _players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (IPlayer player in _players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            _pointsEarned += 1;
            this.Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
            //foreach (IPlayer player in Players.Where(p => p.GetType().Name == nameof(Goalkeeper)))
            //{
            //    player.IncreaseRating();
            //}
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append("--Players: ");
            if (Players.Count > 0)
            {
                sb.Append(string.Join(", ", Players.Select(p => p.Name)));
            }
            else
            {
                sb.Append("none");
            }
            
            return sb.ToString().Trim();
        }
    }
}
