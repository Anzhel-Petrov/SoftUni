using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Models.Diver;
using NauticalCatchChallenge.Models.Fish;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge_BusinessLogic.Core
{
    public class Controller : IController
    {
        private IRepository<IFish> _fishRepository;
        private IRepository<IDiver> _diverRepository;

        public Controller(IRepository<IFish> fishRepository, IRepository<IDiver> diverRepository)
        {
            _fishRepository = fishRepository;
            _diverRepository = diverRepository;
        }

        public Controller() : this(new FishRepository(), new DiverRepository())
        {

        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = _diverRepository.GetModel(diverName);
            IFish fish = _fishRepository.GetModel(fishName);

            if (diver is null)
            {
                return string.Format(OutputMessages.DiverNotFound, _diverRepository.GetType().Name, diverName);
            }

            if (fish is null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel > fish.TimeToCatch)
            {
                diver.Hit(fish);
                DiverHealthCheck(diver);
                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }
            else
            {
                if (diver.OxygenLevel == fish.TimeToCatch && isLucky)
                {
                    diver.Hit(fish);
                    DiverHealthCheck(diver);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }

                diver.Miss(fish.TimeToCatch);
                DiverHealthCheck(diver);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (IDiver diver in _diverRepository.Models.OrderByDescending(p => p.CompetitionPoints).ThenByDescending(c => c.Catch.Count).ThenBy(n => n.Name).Where(h => !h.HasHealthIssues))
            {
                sb.AppendLine(diver.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != nameof(ScubaDiver) && diverType != nameof(FreeDiver))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (_diverRepository.GetModel(diverName) is not null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, _diverRepository.GetType().Name);
            }

            IDiver diver = diverType == nameof(FreeDiver) ? new FreeDiver(diverName) : new ScubaDiver(diverName); 
            _diverRepository.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, _diverRepository.GetType().Name);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            IDiver diver = _diverRepository.GetModel(diverName);
            sb.AppendLine(diver.ToString().Trim());
            sb.AppendLine("Catch Report:");

            foreach(string fishName in diver.Catch)
            {
                IFish fish = _fishRepository.GetModel(fishName);
                sb.AppendLine(fish.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            IEnumerable<IDiver> unhealthyDivers = _diverRepository.Models.Where(x => x.HasHealthIssues);
            int count = unhealthyDivers.Count();

            foreach (IDiver diver in unhealthyDivers)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return string.Format(OutputMessages.DiversRecovered, count);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != nameof(ReefFish) && fishType != nameof(DeepSeaFish) && fishType != nameof(PredatoryFish))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (_fishRepository.GetModel(fishName) is not null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, _fishRepository.GetType().Name);
            }

            IFish fish;
            if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }
            else if(fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else
            {
                fish = new PredatoryFish(fishName, points);
            }
            
            _fishRepository.AddModel(fish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }
        private static void DiverHealthCheck(IDiver diver)
        {
            if (diver.OxygenLevel == 0)
            {
                diver.UpdateHealthStatus();
            }
        }
    }
}
