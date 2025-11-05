namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(RemoveDuplicates(input));
        }

        public static string RemoveDuplicates(string duplicteString)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < duplicteString.Length; i++)
            {
                if (chars.Contains(duplicteString[i]))
                {
                    continue;
                }
                else
                {
                    chars.Add(duplicteString[i]);
                }
            }
            return string.Join("", chars);
        }
    }
}
