using HighwayToPeak.Models.Contracts;
using HighwayToPeak_.Models.Enums;
using System;
using System.Collections.Generic;

namespace HighwayToPeak_.Models
{
    public abstract class Climber : IClimber
    {
        private readonly List<string> _conqueredPeaks;
        private string _name;
        private int _stamina;
        private const int maxStamina = 10;
        private const int minStamina = 0;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
        }

        public string Name 
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Climber's name cannot be null or whitespace.");
                }
                _name = value;
            }
        }

        public int Stamina 
        {
            get => _stamina;
            set
            {
                if (value < minStamina)
                {
                    _stamina = minStamina;
                }
                else if (value > maxStamina)
                {
                    _stamina = maxStamina;
                }
                else
                {
                    _stamina = value;
                }
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => _conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (!_conqueredPeaks.Contains(peak.Name))
            {
                _conqueredPeaks.Add(peak.Name);
            }

            Enum.TryParse(peak.DifficultyLevel, out DifficultyLevel difficultyLevel);
            switch (difficultyLevel)
            {
                case DifficultyLevel.Moderate:
                    Stamina -= 2;
                    break;
                case DifficultyLevel.Hard:
                    Stamina -= 4;
                    break;
                case DifficultyLevel.Extreme:
                    Stamina -= 6;
                    break;
            }
        }

        public abstract void Rest(int daysCount);
    }
}
