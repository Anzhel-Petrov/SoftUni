namespace _01.Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int elements = input[0];
            int popElements = input[1];
            int peekElement = input[2];
            bool exist = false;
            Stack<int> stack = new Stack<int>();

            int[] stackElements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < stackElements.Length; i++)
            {
                stack.Push(stackElements[i]);
            }

            for (int i = 0; i < popElements; i++)
            {
                stack.Pop();
            }

            foreach (int element in stack)
            {
                if (element == peekElement)
                {
                    exist = true;
                    break;
                }
            }


            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (exist)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
