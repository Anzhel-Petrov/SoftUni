using System;
using System.Linq;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var number in numbers)
            {
                ICallble phone;

                    if (number.Length > 7)
                    {
                        phone = new SmartPhone();
                    }
                    else
                    {
                        phone = new StationaryPhone();
                    }

                try
                {
                    phone.Calling(number);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var url in urls)
            {
                IBroweable smartPhone = new SmartPhone();
                try
                {
                    smartPhone.Browsing(url);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
