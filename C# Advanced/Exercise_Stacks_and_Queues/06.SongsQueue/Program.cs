using System.Data.SqlTypes;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songList = new Queue<string>(Console.ReadLine().Split(", ").ToArray());

            while (songList.Any())
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                string command = tokens[0];

                switch (command)
                {
                    case "Play":
                        songList.Dequeue();
                        break;
                    case "Add":
                        string songName = string.Join(" ", tokens.Skip(1));
                        if (songList.Contains(songName))
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        else
                        {
                            songList.Enqueue(songName);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songList));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
