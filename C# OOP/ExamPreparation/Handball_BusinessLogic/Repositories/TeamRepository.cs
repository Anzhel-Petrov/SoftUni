using System.Collections.Generic;
using System.Linq;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> _teams;

        public TeamRepository()
        {
            _teams = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => _teams.AsReadOnly();
        public void AddModel(ITeam model)
        {
            _teams.Add(model);
        }

        public bool RemoveModel(string name)
        {
            return _teams.Remove(_teams.FirstOrDefault(t => t.Name == name));
        }

        public bool ExistsModel(string name)
        {
            return _teams.Any(t => t.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return _teams.FirstOrDefault(t => t.Name == name);
        }
    }
}
