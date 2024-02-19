namespace _02.ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] protectedAirspace = new char[n, n];

            int posRow = 0;
            int posCol = 0;
            int enemyCount = 0;
            int armor = 300;

            for (int row = 0; row < protectedAirspace.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < protectedAirspace.GetLength(1); col++)
                {
                    protectedAirspace[row, col] = line[col];

                    if (line[col] == 'J')
                    {
                        posRow = row;
                        posCol = col;
                        protectedAirspace[posRow, posCol] = '-';
                    }
                    if(line[col] == 'E')
                    {
                        enemyCount++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        posRow--;
                        break;

                    case "down":
                        posRow++;
                        break;

                    case "left":
                        posCol--;
                        break;

                    case "right":
                        posCol++;
                        break;
                }

                if (protectedAirspace[posRow, posCol] != '-')
                {
                    if (protectedAirspace[posRow, posCol] == 'E')
                    {
                        enemyCount--;
                        if (enemyCount == 0)
                        {
                            Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                            break;
                        }
                        else
                        {
                            armor -= 100;
                            if (armor == 0)
                            {
                                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{posRow}, {posCol}]!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        armor = 300;
                    }

                    protectedAirspace[posRow, posCol] = '-';
                }
            }

            protectedAirspace[posRow, posCol] = 'J';
            PrintMatrix(protectedAirspace);
        }

        private static void PrintMatrix<T>(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
