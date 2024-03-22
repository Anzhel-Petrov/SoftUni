using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak_.Models;
using HighwayToPeak_.Models.Enums;
using HighwayToPeak_.Repositories;
using System;

namespace HighwayToPeak_.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> _peakRepository;
        public Controller(IRepository<IPeak> peakRepository)
        {
            _peakRepository = peakRepository;
        }

        public Controller() : base()
        {
            
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (_peakRepository.Get(name) is not null)
            {
                throw new ArgumentException($"{name} is already added as a valid mountain destination.");
            }

            if (!Enum.TryParse(difficultyLevel, out DifficultyLevel validDifficultyLevel))
            {
                throw new ArgumentException($"{difficultyLevel} peaks are not allowed for international climbers.");
            }

            IPeak peak = new Peak(name, elevation, difficultyLevel);

            _peakRepository.Add(peak);

            return $"{name} is allowed for international climbing. See details in {_peakRepository.GetType().Name}.";
        }

        public string AttackPeak(string climberName, string peakName)
        {
            throw new System.NotImplementedException();
        }

        public string BaseCampReport()
        {
            throw new System.NotImplementedException();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            throw new System.NotImplementedException();
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            throw new System.NotImplementedException();
        }

        public string OverallStatistics()
        {
            throw new System.NotImplementedException();
        }
    }
}
