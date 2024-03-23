using HighwayToPeak.Models.Contracts;
using System.Collections.Generic;

namespace HighwayToPeak_.Models
{
    public class BaseCamp : IBaseCamp
    {
        private readonly List<string> _residents = new List<string>();
        public IReadOnlyCollection<string> Residents => _residents.AsReadOnly();

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
