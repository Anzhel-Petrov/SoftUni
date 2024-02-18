using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> undo = new Stack<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (int.Parse(command[0]))
                {
                    case 1:
                        undo.Push(sb.ToString());
                        sb.Append(command[1]);
                        break;
                    case 2:
                        int count = int.Parse(command[1]);
                        undo.Push(sb.ToString());
                        sb.Remove(sb.Length - count, count);
                        break;
                    case 3:
                        int index = int.Parse(command[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;
                    case 4:
                        sb.Clear();
                        sb.Append(undo.Pop());
                        break;
                }
            }

        }
    }
}
