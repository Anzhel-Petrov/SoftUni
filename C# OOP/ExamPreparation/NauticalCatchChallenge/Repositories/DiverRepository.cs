using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System.Collections.Generic;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private readonly List<IDiver> _divers;
        public IReadOnlyCollection<IDiver> Models => _divers.AsReadOnly();

        public void AddModel(IDiver model)
        {
            _divers.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return _divers.Find(x => x.Name == name);
        }
    }
}
