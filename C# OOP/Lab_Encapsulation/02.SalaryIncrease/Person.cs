namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  int Age { get; set; }
        public decimal Salary { get; set; }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2;
            }

            Salary += Salary * (percentage / 100);

            //if (Age > 30)
            //{
            //    Salary += Salary * percentage / 100;
            //}
            //else
            //{
            //    Salary += Salary * percentage / 200;
            //}
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
