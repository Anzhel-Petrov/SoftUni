using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string _name;
        private int _age;
        private string _gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name 
        { 
            get { return _name; } 
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid input!");
                _name = value;
            } 
        }
        public int Age
        {
            get { return _age; } 
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid input!");
                _age = value;
            } 
        }
        public string Gender 
        { 
            get { return _gender; } 
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid input!");
                _gender = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());
            return sb.ToString().Trim();
        }
        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
