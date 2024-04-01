using System;
using System.Text;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string _name;
        private string _team;
        private double _rating;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                _name = value;
            }
        }
        public double Rating { get => _rating; protected set => _rating = value; }
        public string Team { get => _team; private set => _team = value; }
        public void JoinTeam(string name)
        {
            Team = name;
        }

        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {this.Rating}");

            return sb.ToString().TrimEnd();

            //return $"{this.GetType().Name}: {Name}" + Environment.NewLine + $"--Rating: {Rating}";
        }
    }
}