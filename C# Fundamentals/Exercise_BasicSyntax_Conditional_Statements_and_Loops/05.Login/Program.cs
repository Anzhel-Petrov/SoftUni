namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var password = Console.ReadLine();
            var attemots = 0;
            var reversePassword = "";

            for (int i = password.Length - 1; i >= 0; i--)
            {
                reversePassword += password[i];
            }

            while (true)
            {
                var input = Console.ReadLine();
                attemots++;

                if (input == reversePassword)
                {
                    Console.WriteLine($"User {password} logged in.");
                    break;
                }
                else if (attemots == 4)
                {
                    Console.WriteLine($"User {password} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
