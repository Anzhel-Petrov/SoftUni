using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace NauticalCatchChallenge.Models.Diver
{
    public abstract class Diver : IDiver
    {
        private string _name;
        private int _oxygenLevel;
        private List<string> _coughtFish;
        private double _points;
        private bool _hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            _coughtFish = new List<string>();
            _points = 0;
            _hasHealthIssues = false;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DiversNameNull));
                }

                _name = value;
            }
        }

        public int OxygenLevel
        {
            get => _oxygenLevel;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => _coughtFish.AsReadOnly();

        public double CompetitionPoints => Math.Round(_points, 1);

        public bool HasHealthIssues => _hasHealthIssues;

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            _coughtFish.Add(fish.Name);
            _points += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            _hasHealthIssues = !_hasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {_coughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
