using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        public List<IPrivate> Privates { get; set; }
    }
}
