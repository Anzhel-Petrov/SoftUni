namespace _01.Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArray = Console.ReadLine().Split(", ");

            for (int i = 0; i < wordsArray.Length; i++)
            {
                if (wordsArray[i].Length >= 3 && wordsArray[i].Length <= 16)
                {
                    var foo = string.Join("", wordsArray[i].Where(x => !char.IsLetterOrDigit(x)));
                    if (foo.Count() == 0)
                    {
                        Console.WriteLine(wordsArray[i]);
                    }
                    else if (foo.Contains('_') || foo.Contains('-'))
                    {
                        Console.WriteLine(wordsArray[i]);
                    }
                }
            }
        }
    }
}
