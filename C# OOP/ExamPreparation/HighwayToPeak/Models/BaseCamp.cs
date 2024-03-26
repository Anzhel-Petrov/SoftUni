using HighwayToPeak.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private readonly List<string> _residents = new List<string>();
        public IReadOnlyCollection<string> Residents => _residents.AsReadOnly().OrderBy(x => x).ToList();

        public void ArriveAtCamp(string climberName)
        {
            _residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            _residents.Remove(climberName);
        }
    }
}
