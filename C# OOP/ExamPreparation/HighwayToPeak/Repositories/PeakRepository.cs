﻿using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HighwayToPeak_.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private readonly List<IPeak> _peaks;

        public IReadOnlyCollection<IPeak> All => _peaks.AsReadOnly();

        public void Add(IPeak model)
        {
            _peaks.Add(model);
        }

        public IPeak Get(string name)
        {
            return _peaks.FirstOrDefault(x => x.Name == name);
        }
    }
}
