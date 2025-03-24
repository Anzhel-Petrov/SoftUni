namespace _01.CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chartString = Console.ReadLine().Replace(" ", "");
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in chartString)
            {
                if (charCount.Keys.Contains(c))
                {
                    charCount[c] += 1;
                }
                else
                {
                    //charCount.Add(c, 1);
                    charCount[c] = 1;
                }
            }

            Console.WriteLine(string.Join("\n", charCount.Select(x => $"{x.Key} -> {x.Value}")));

            //foreach (KeyValuePair<char, int> d in charCount)
            //    Console.WriteLine($"{d.Key} -> {d.Value}");
        }
    }
}
