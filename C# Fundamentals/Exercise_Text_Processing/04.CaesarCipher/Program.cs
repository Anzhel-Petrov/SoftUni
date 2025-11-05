using System.Text;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string plainText = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (char c in plainText)
            {
                int newChar = c + 3;
                sb.Append((char)newChar);
            }

            Console.WriteLine(sb);
        }
    }
}
