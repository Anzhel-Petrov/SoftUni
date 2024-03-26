using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System.Collections.Generic;

namespace NauticalCatchChallenge.Repositories
{
    internal class FishRepository : IRepository<IFish>
    {
        private readonly List<IFish> _fishes;
        public FishRepository()
        {
            _fishes = new List<IFish>();
        }
        public IReadOnlyCollection<IFish> Models => _fishes.AsReadOnly();

        public void AddModel(IFish model)
        {
            _fishes.Add(model);
        }

        public IFish GetModel(string name)
        {
            return _fishes.Find(x => x.Name == name);
        }
    }
}
