using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Dough
    {
		private string _flour;
		private string _bakingTechnique;
		private double _grams;
		private const double _baseCaloriesPerGram = 2;

        public Dough(string flour, string bakingTechnique, double grams)
        {
            Flour = flour;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string Flour
		{
			get { return _flour; }
			private set 
			{
				if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
				{
                    throw new ArgumentException("Invalid type of dough.");
                }
				_flour = value; 
			}
		}		
		public string BakingTechnique
        {
			get { return _bakingTechnique; }
			private set 
			{
				if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
				{
					throw new ArgumentException("Invalid type of dough.");
				}
				_bakingTechnique = value; 
			}
		}

        public double Grams
        {
            get { return _grams; }
            private set 
			{
				if (value < 1 || value > 200)
				{
					throw new ArgumentException("Dough weight should be in the range [1..200].");
				}
				_grams = value; 
			}
        }

        public double CaloriesPerGram { get => CalculateCaloriesPerGram(); }

        private double CalculateCaloriesPerGram()
		{
			double flourModifier = 0;
			double bakingModifier = 0;

			switch (Flour.ToLower())
			{
				case "white":
                    flourModifier = 1.5;
					break;
                case "wholegrain":
                    flourModifier = 1.0;
                    break;
			}

			switch (BakingTechnique.ToLower())
			{
                case "crispy":
                    bakingModifier = 0.9;
                    break;
                case "chewy":
                    bakingModifier = 1.1;
                    break;
                case "homemade":
                    bakingModifier = 1.0;
                    break;
            }

			return (Grams * _baseCaloriesPerGram) * flourModifier * bakingModifier;
		}

    }
}
