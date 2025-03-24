namespace _01.SumAdjacentEqualNumbersAlternative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberListOne = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numberListTwo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            int edgeOfList = numberListOne.Count < numberListTwo.Count ? numberListOne.Count : numberListTwo.Count;

            for (int i = 0; i < edgeOfList; i++)
            {
                result.Add(numberListOne[i]);
                result.Add(numberListTwo[i]);
            }

            if (numberListOne.Count > numberListTwo.Count)
            {
                result.AddRange(numberListOne.TakeLast(numberListOne.Count - edgeOfList));
            }
            else if (numberListTwo.Count > numberListOne.Count)
            {
                result.AddRange(numberListTwo.TakeLast(numberListTwo.Count - edgeOfList));
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
