namespace _08.SoftUniParty_Alternative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regulars = new HashSet<string>();
            HashSet<string> VIPs = new HashSet<string>();

            string input = "";
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (Char.IsDigit(input, 0))
                {
                    VIPs.Add(input);
                }
                else
                {
                    regulars.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (VIPs.Contains(input))
                {
                    VIPs.Remove(input);
                }
                else if (regulars.Contains(input))
                {
                    regulars.Remove(input);
                }
            }

            Console.WriteLine(VIPs.Count + regulars.Count);

            foreach (string VIP in VIPs)
            {
                Console.WriteLine(VIP);
            }

            foreach (string regular in regulars)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
