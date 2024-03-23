using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighwayToPeak_.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private readonly List<IClimber> _climbers;
        public ClimberRepository()
        {
            _climbers = new List<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All => _climbers.AsReadOnly();

        public void Add(IClimber model)
        {
            _climbers.Add(model);
        }

        public IClimber Get(string name)
        {
            return _climbers.FirstOrDefault(x => x.Name == name);
        }
    }
}
