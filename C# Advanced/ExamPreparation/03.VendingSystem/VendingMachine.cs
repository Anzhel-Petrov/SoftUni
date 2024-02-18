using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int capacity)
        {
            ButtonCapacity = capacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount { get => Drinks.Count; }

        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            return Drinks.Remove(Drinks.Where(x => x.Name == name).FirstOrDefault());
        }

        public Drink GetLongest()
        {
            return Drinks.MaxBy(x => x.Volume);
        }

        public Drink GetCheapest()
        {
            return Drinks.MinBy(x => x.Price);
        }

        public string BuyDrink(string name)
        {
            return Drinks.Where(x => x.Name == name).FirstOrDefault().ToString();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");

            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
