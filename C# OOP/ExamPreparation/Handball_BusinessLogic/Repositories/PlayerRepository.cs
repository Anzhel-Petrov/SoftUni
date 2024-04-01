using System.Collections.Generic;
using System.Linq;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> _players;

        public PlayerRepository()
        {
            _players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => _players.AsReadOnly();
        public void AddModel(IPlayer model)
        {
            _players.Add(model);
        }

        public bool RemoveModel(string name)
        {
            return _players.Remove(_players.FirstOrDefault(p => p.Name == name));
        }

        public bool ExistsModel(string name)
        {
            return _players.Any(p => p.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return _players.FirstOrDefault(p => p.Name == name);
        }
    }
}
