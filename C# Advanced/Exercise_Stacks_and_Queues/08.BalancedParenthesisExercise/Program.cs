namespace _08.BalancedParenthesisExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] sequince = Console.ReadLine().ToCharArray();

            if (sequince.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> stack = new Stack<char>();

            foreach (char c in sequince)
            {
                if ("({[".Contains(c))
                {
                    stack.Push(c);
                }
                else if (c == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else if (c == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else if (c == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            Console.WriteLine(stack.Any() ? "NO" : "YES");
        }
    }
}
