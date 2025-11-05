namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            int nextExplosionIndex = default;

            var explosionsCount = sequence.Where(x => x == '>').Count();

            for (int i = 0; i < explosionsCount; i++)
            {
                var explosionIndex = sequence.IndexOf('>', nextExplosionIndex);

                var explosionPower = sequence[explosionIndex + 1] - '0';

                nextExplosionIndex = sequence.IndexOf('>', explosionIndex + 1);

                if (nextExplosionIndex == -1)
                {
                    sequence = sequence.Remove(explosionIndex + 1, explosionPower);
                    break;
                }

                var foo = sequence.Substring(explosionIndex, explosionPower).Length;
                var foo2 = foo + explosionIndex;

                if (sequence.Substring(explosionIndex, explosionPower).Length + explosionIndex < nextExplosionIndex)
                {
                    sequence = sequence.Remove(explosionIndex + 1, explosionPower);
                }

                nextExplosionIndex = sequence.IndexOf('>', explosionIndex + 1);
            }

            Console.WriteLine(sequence);

        }
    }
}
