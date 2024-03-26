using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;

namespace NauticalCatchChallenge.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string _name;
        private double _points;
        private readonly int _timeToCatch;

        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            _timeToCatch = timeToCatch;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FishNameNull));
                }

                _name = value;
            }
        }

        public double Points
        {
            get => _points;
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PointsNotInRange));
                }

                _points = value;
            }
        }

        public int TimeToCatch => _timeToCatch;

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
