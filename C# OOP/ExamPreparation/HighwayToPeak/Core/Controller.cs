using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Enums;
using HighwayToPeak.Repositories;
using System;
using System.Linq;
using System.Text;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> _peakRepository;
        private IRepository<IClimber> _climberRepository;
        private IBaseCamp _baseCamp;
        public Controller()
        {
            this._peakRepository = new PeakRepository();
            this._climberRepository = new ClimberRepository();
            this._baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (_peakRepository.Get(name) is not null)
            {
                throw new ArgumentException($"{name} is already added as a valid mountain destination.");
            }

            if (!Enum.TryParse(difficultyLevel, out DifficultyLevel _))
            {
                throw new ArgumentException($"{difficultyLevel} peaks are not allowed for international climbers.");
            }

            IPeak peak = new Peak(name, elevation, difficultyLevel);

            _peakRepository.Add(peak);

            return $"{name} is allowed for international climbing. See details in {_peakRepository.GetType().Name}.";
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = _climberRepository.Get(climberName);
            IPeak peak = _peakRepository.Get(peakName);

            if (peak is null)
            {
                throw new ArgumentException($"{peakName} is not allowed for international climbing.");
            }

            if (climber is null)
            {
                throw new ArgumentException($"Climber - {climberName}, has not arrived at the BaseCamp yet.");
            }

            if (!_baseCamp.Residents.Contains(climberName))
            {
                throw new ArgumentException($"{climberName} not found for gearing and instructions. The attack of {peakName} will be postponed.");
            }

            Enum.TryParse(peak.DifficultyLevel, out DifficultyLevel difficultyLevel);
            if (difficultyLevel == DifficultyLevel.Extreme && climber.GetType().Name == "NaturalClimber")
            {
                throw new ArgumentException($"{climberName} does not cover the requirements for climbing {peakName}.");
            }

            _baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return $"{climberName} did not return to BaseCamp.";
            }
            else
            {
                _baseCamp.ArriveAtCamp(climber.Name);
                return $"{climberName} successfully conquered {peakName} and returned to BaseCamp.";
            }

        }

        public string BaseCampReport()
        {
            if (_baseCamp.Residents.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BaseCamp residents:");

                foreach (IClimber climber in _climberRepository.All.Where(x => _baseCamp.Residents.Contains(x.Name)).OrderBy(x => x.Name))
                {
                    sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return "BaseCamp is currently empty.";
            }
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            IClimber climber = _climberRepository.Get(climberName);

            if (!_baseCamp.Residents.Contains(climberName))
            {
                return $"{climberName} not found at the BaseCamp.";
            }

            if (climber.Stamina < 10)
            {
                climber.Rest(daysToRecover);
                return $"{climberName} has been recovering for {daysToRecover} days and is ready to attack the mountain.";
            }
            else
            {
                return $"{climberName} has no need of recovery.";
            }
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (_climberRepository.Get(name) is not null)
            {
                throw new ArgumentException($"{name} is a participant in {_climberRepository.GetType().Name} and cannot be duplicated.");
            }

            IClimber climber = isOxygenUsed ? new OxygenClimber(name) : new NaturalClimber(name);

            _climberRepository.Add(climber);
            _baseCamp.ArriveAtCamp(name);

            return $"{name} has arrived at the BaseCamp and will wait for the best conditions.";
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");
            foreach (IClimber climber in _climberRepository.All.OrderByDescending(x => x.ConqueredPeaks.Count).ThenBy(x => x.Name))
            {
                sb.AppendLine(climber.ToString());
                foreach (IPeak peak in _peakRepository.All.Where(x => climber.ConqueredPeaks.Contains(x.Name)))
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
