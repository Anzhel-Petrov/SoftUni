using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine()!.Trim().Trim('0');
            int singleDigit = int.Parse(Console.ReadLine()!);
            StringBuilder sb = new StringBuilder();
            int remainder = 0;


            if (singleDigit == 0 || bigNumber.All(c => c == '0'))
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int product = singleDigit * (bigNumber[i] - '0') + remainder;
                int result = product % 10;
                remainder = product / 10;
                sb.Insert(0, result);
            }

            if (remainder > 0)
            {
                sb.Insert(0, remainder);
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
