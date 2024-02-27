using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance 
        { 
            get { return _endurance; }
            private set
            {
                IsValid(nameof(Endurance), value);
                _endurance = value;
            }
        }
        public int Sprint 
        {
            get { return _sprint; }
            private set
            {
                IsValid(nameof(Sprint), value);
                _sprint = value;
            }
        }
        public int Dribble 
        {
            get { return _dribble; }
            private set
            {
                IsValid(nameof(Dribble), value);
                _dribble = value;
            }
        }
        public int Passing 
        {
            get { return _passing; }
            private set
            {
                IsValid(nameof(Passing), value);
                _passing = value;
            }
        }
        public int Shooting 
        {
            get { return _shooting; }
            private set
            {
                IsValid(nameof(Shooting), value);
                _shooting = value;
            }
        }
        public double GetSkillLevel { get { return CalculateSkillLevel(); } }

        private double CalculateSkillLevel()
        {
           return new List<int>() {Endurance, Sprint, Dribble, Passing, Shooting}.Average();
        }

        private void IsValid(string propertyName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{propertyName} should be between 0 and 100.");
            }
        }
    }
}
