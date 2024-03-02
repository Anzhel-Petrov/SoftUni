using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public void BuyFood();
    }
}
