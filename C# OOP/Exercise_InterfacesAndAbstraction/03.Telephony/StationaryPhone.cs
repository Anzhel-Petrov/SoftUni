using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class StationaryPhone : ICallble
    {
        public void Calling(string number)
        {
            if (number.Any(char.IsLetter))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
