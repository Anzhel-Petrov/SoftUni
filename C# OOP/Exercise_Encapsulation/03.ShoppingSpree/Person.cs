using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string _name;
        private decimal _money;
        private readonly List<Product> _products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            _products = new List<Product>();
        }

        public string Name 
        {
            get => _name; 
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }
        public decimal Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                _money = value;
            }
        }
        public IReadOnlyCollection<Product> Products { get { return _products.AsReadOnly(); } }

        public bool CanBuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                _products.Add(product);
                return true;
            }

            return false;
        }
    }
}
