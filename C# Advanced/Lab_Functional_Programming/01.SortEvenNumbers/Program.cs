namespace _01.SortEvenNumbers;

class Program
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToArray();

        Console.WriteLine(string.Join(", ", array));

        // int[] numbers = Console.ReadLine()
        //     .Split(new string[] { ", " },
        //         StringSplitOptions.RemoveEmptyEntries)
        //     .Select(n => int.Parse(n))
        //     .Where(n => n % 2 == 0)
        //     .OrderBy(n => n)
        //     .ToArray();
        //
        // string result = string.Join(", ", numbers);
        // Console.WriteLine(result);

        // Console.WriteLine(
        //     string.Join(", ", Console.ReadLine()
        //         .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        //         .Select(int.Parse)
        //         .Where(n => n % 2 == 0)
        //         .OrderBy(n => n)
        //         .ToArray())
        //     );
    }
}