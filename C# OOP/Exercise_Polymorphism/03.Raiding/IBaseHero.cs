using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public interface IBaseHero
    {
        public string Name { get; set; }
        public int Power { get; set; }
        string CastAbility();
    }
}
