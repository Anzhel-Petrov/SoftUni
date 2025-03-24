namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> listA = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            //List<int> listB = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> listA = ReadIntList();
            List<int> listB = ReadIntList();

            List<int> result = new List<int>();

            int biggerListCount = listA.Count >= listB.Count ? listA.Count : listB.Count;

            for (int i = 0; i < biggerListCount; i++)
            {
                if (i < listA.Count)
                {
                    result.Add(listA[i]);
                }

                if (i < listB.Count)
                {
                    result.Add(listB[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static List<int> ReadIntList()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
        }
    }
}
