namespace _02.SumNumbers;

class Program
{
    static void Main(string[] args)
    {
        Func<string, int> parser = int.Parse;
        
        int[] array = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(parser)
            .ToArray();

        Console.WriteLine(array.Length);
        Console.WriteLine(array.Sum());
    }
}