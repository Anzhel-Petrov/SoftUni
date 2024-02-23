using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    internal class Child : Person
    {
        private int _age;
        public Child(string name, int age) : base(name, age)
        {
        }

        override public int Age 
        { 
            get => _age;
            set
            {
                if (value > 15) 
                    throw new ArgumentException("A child cannot be above 15 years of age.");
                else
                    _age = value;
            } 
        }
    }
}
