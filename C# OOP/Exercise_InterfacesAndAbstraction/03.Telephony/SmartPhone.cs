using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class SmartPhone : ICallble, IBroweable
    {
        public void Browsing(string url)
        {
            if (url.Any(char.IsNumber))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {url}!");

        }

        public void Calling(string phoneNumber)
        {
            if (phoneNumber.Any(char.IsLetter))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
