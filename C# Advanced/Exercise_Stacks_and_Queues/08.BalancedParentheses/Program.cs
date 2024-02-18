namespace _08.BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (char c in parentheses)
            {
                if (c == '[' || c == '{' || c == '(')
                {
                    stack.Push(c);
                }

                else if (c == ']')
                {
                    if (stack.Peek() != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    stack.Pop();
                }

                else if (c == '}')
                {
                    if (stack.Peek() != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    stack.Pop();
                }

                else if (c == ')')
                {
                    if (stack.Peek() != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    stack.Pop();
                }
            }
            Console.WriteLine("YES");
        }
    }
}
