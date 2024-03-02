using _07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, List<Repair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs");
            foreach (Repair repair in Repairs)
            {
                sb.AppendLine(base.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
