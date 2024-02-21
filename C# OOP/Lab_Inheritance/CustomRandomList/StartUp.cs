using System;
namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new()
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
            };

            Console.WriteLine(strings.Count);

            Console.WriteLine(strings.RandomString());

            Console.WriteLine(strings.Count);

        }
    }
}
