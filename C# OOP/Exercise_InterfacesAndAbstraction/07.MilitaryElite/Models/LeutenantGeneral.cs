using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class LeutenantGeneral : Private, ILieutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, List<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (IPrivate priv in Privates)
            {
                sb.AppendLine(priv.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
