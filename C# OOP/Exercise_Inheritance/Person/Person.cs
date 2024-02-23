using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private int _age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public virtual int Age 
        { 
            get => _age;
            set 
            {
                if (value < 0)
                    //_age = 0;
                    throw new ArgumentException("Age cannot be lower than 0.");
                else _age = value;
            }  
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }

    }
}
