using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string _name;
        private List<Topping> _toppings;
        private int _toppingsCapacity = 10;

        public Pizza(string name)
        {
            Name = name;
            _toppings = new List<Topping>();
        }

        public string Name 
        {
            get { return _name; } 
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                _name = value;
            }
        }
        public Dough Dough { get; set; }
        public double TotalCalories { get { return Dough.CaloriesPerGram + _toppings.Sum(x => x.CaloriesPerGram); } }
        public IReadOnlyCollection<Topping> Toppings 
        {
            get { return _toppings.AsReadOnly(); }
        }
        public void AddTopping(Topping topping) 
        {
            if (_toppings.Count > _toppingsCapacity)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            _toppings.Add(topping);
        }
    }
}
