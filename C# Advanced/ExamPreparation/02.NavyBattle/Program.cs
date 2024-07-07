namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int posRow = 0;
            int posCol = 0;
            int hits = 3;
            int battleCruisers = 3;

            char[,] matrix = new char[rows, rows];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];

                    if (line[col] == 'S')
                    {
                        posRow = row;
                        posCol = col;
                        matrix[row, col] = '-';
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

                if (matrix[posRow, posCol] != '-')
                {
                    if (matrix[posRow, posCol] == '*')
                    {
                        hits--;
                        if (hits == 0)
                        {
                            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{posRow}, {posCol}]!");
                            break;
                        }
                    }
                    else if (matrix[posRow, posCol] == 'C')
                    {
                        battleCruisers--;
                        if (battleCruisers == 0)
                        {
                            Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                            break;
                        }
                    }

                    matrix[posRow, posCol] = '-';
                }
            }

            matrix[posRow, posCol] = 'S';
            PrintMatrix(matrix);
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
