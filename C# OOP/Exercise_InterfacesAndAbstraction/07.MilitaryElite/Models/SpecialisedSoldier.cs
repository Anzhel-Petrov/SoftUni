using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private
    {
        private Corps _corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps
        {
            get => _corps;
            set
            {
                if (value is not Corps.Marines or Corps.Airforces)
                {
                    throw new ArgumentException();
                }
                _corps = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            return sb.ToString().Trim();
        }
    }

    public enum Corps
    {
        Marines,
        Airforces
    }
}
