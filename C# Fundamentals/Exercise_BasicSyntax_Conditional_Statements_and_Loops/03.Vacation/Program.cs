namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var groupType = Console.ReadLine();
            var weekDay = Console.ReadLine();
            double pricePerPerson = 0;

            switch (groupType)
            {
                case "Students":
                    if (weekDay == "Friday")
                    {
                        pricePerPerson = 8.45;
                    }
                    if (weekDay == "Saturday")
                    {
                        pricePerPerson = 9.8;
                    }
                    if (weekDay == "Sunday")
                    {
                        pricePerPerson = 10.46;
                    }
                    break;

                case "Business":
                    if (weekDay == "Friday")
                    {
                        pricePerPerson = 10.9;
                    }
                    if (weekDay == "Saturday")
                    {
                        pricePerPerson = 15.6;
                    }
                    if (weekDay == "Sunday")
                    {
                        pricePerPerson = 16;
                    }
                    break;

                case "Regular":
                    if (weekDay == "Friday")
                    {
                        pricePerPerson = 15;
                    }
                    if (weekDay == "Saturday")
                    {
                        pricePerPerson = 20;
                    }
                    if (weekDay == "Sunday")
                    {
                        pricePerPerson = 22.5;
                    }
                    break;
            }

            double totalPrice = pricePerPerson * peopleCount;

            if (groupType == "Students" && peopleCount >= 30)
            {
                totalPrice = totalPrice * 0.85;
            }
            else if (groupType == "Business" && peopleCount >= 100)
            {
                totalPrice = pricePerPerson * (peopleCount - 10);
            }
            else if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 10)
            {
                totalPrice = totalPrice * 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
