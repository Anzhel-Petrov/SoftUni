namespace _03.CountUppercaseWords;

class Program
{
    static void Main(string[] args)
    {
        Func<string, bool> wordIsUpperCase = s => s[0] == s.ToUpper()[0];
        
        string[] text = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(wordIsUpperCase)
            .ToArray();
        
        foreach (var word in text)
        {
            Console.WriteLine(word);
        }
    }
}