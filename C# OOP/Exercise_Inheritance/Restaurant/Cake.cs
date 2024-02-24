using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const int CakePrice = 5;
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;

        public Cake(string name) : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
    }
}
