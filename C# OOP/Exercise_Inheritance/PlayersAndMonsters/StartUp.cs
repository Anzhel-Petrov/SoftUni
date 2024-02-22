using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("The Blade Knight", 89);
            Console.WriteLine(bladeKnight);
        }
    }
}