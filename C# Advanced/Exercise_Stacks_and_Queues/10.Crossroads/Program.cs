using System.Security;
using System.Threading.Channels;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());

            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> carQueue = new Queue<string>();

            string command;
            int counter = 0;


            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int currentGreenLightDuration = greenLightDuration;
                    int currentFreeWindowDuration = freeWindowDuration;

                    while (true)
                    {
                        if (carQueue.Any())
                        {
                            if (currentGreenLightDuration > carQueue.Peek().Length)
                            {
                                counter++;
                                currentGreenLightDuration -= carQueue.Dequeue().Length;
                            }
                            else
                            {
                                if (currentFreeWindowDuration >= carQueue.Peek().Length - currentGreenLightDuration)
                                {
                                    counter++;
                                    carQueue.Dequeue();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("A crash happened!");
                                    char charHit = carQueue.Peek().ToCharArray()[currentGreenLightDuration + currentFreeWindowDuration];
                                    Console.WriteLine($"{carQueue.Peek()} was hit at {charHit}.");
                                    return;
                                }
                            }    
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(command);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
