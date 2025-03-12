using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmsIntroduction
{
    internal class RecursionFactorial
    {
        static void Main(string[] args)
        {
            int FactorialRecursive(int n)
            {
                //return n <= 1 ? 1 : n * FactorialRecursive(n - 1);
                if (n == 1)
                {
                    return 1;
                }

                int result = n * FactorialRecursive(n - 1);

                return result;
            }

            Console.WriteLine(FactorialRecursive(6));
        }
    }
}
