using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
		private string _type;
		private double _grams;
        private double _baseCaloriesPerGram = 2;

        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }

        public string Type
		{
			get { return _type; }
			private set 
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                _type = value; 
            }
		}
        public double Grams
        {
            get { return _grams; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                _grams = value; 
            }
        }

        public double CaloriesPerGram { get => CalculateCaloriesPerGram(); }

        private double CalculateCaloriesPerGram()
        {
            double typeModifier = 0;

            switch (Type.ToLower())
            {
                case "meat":
                    typeModifier = 1.2;
                    break;
                case "veggies":
                    typeModifier = 0.8;
                    break;
                case "cheese":
                    typeModifier = 1.1;
                    break;
                case "sauce":
                    typeModifier = 0.9;
                    break;
            }

            return (Grams * _baseCaloriesPerGram) * typeModifier;
        }
    }
}
