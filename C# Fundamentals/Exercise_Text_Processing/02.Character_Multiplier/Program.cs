namespace _02.Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string firstWord = input.Split(" ")[0];
            string secondWord = input.Split(" ")[1];
            int totalSum = default;

            if (firstWord.Length > secondWord.Length)
            {
                var equalWord = firstWord.Substring(0, secondWord.Length);
                totalSum = CharSum(equalWord, secondWord) + ExtraCharSum(firstWord, secondWord);
            }
            else
            {
                var equalWord = secondWord.Substring(0, firstWord.Length);
                totalSum = CharSum(equalWord, firstWord) + ExtraCharSum(secondWord, firstWord);
            }

            Console.WriteLine(totalSum);


            static int ExtraCharSum(string longWord, string shortWord)
            {
                int extraCharSum = default;
                string extraCharacters = longWord.Substring(shortWord.Length);

                foreach (char c in extraCharacters)
                {
                    extraCharSum += c;
                }

                return extraCharSum;
            }

            static int CharSum(string firstWord, string secondWord)
            {
                int charSum = default;
                for (int i = 0; i < firstWord.Length; i++)
                {
                    charSum += firstWord[i] * secondWord[i];
                }

                return charSum;
            }
        }
    }
}
