namespace _02.FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrix(n, n);

            int posRow = 0;
            int posCol = 0;

            int fishInTons = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        posRow = row;
                        posCol = col;
                        break;
                    }
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                matrix[posRow, posCol] = '-';
                Direction direction = (Direction)Enum.Parse(typeof(Direction), command);

                switch (direction)
                {
                    case Direction.up:
                        posRow--;
                        if (posRow < 0)
                        {
                            posRow = n - 1;
                        }
                        break;
                    case Direction.down:
                        posRow++;
                        if (posRow > n - 1)
                        {
                            posRow = 0;
                        }
                        break;
                    case Direction.left:
                        posCol--;
                        if (posCol < 0)
                        {
                            posCol = n - 1;
                        }
                        break;
                    case Direction.right:
                        posCol++;
                        if (posCol > n - 1)
                        {
                            posCol = 0;
                        }
                        break;
                }

                if (char.IsDigit(matrix[posRow, posCol]))
                {
                    fishInTons += int.Parse(matrix[posRow, posCol].ToString());
                }
                else if (char.IsLetter(matrix[posRow, posCol]))
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{posRow},{posCol}]");
                    return;
                }

                matrix[posRow, posCol] = 'S';
            }

            if (fishInTons < 20)
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fishInTons} tons of fish more.");
            }
            else
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }

            if (fishInTons > 0)
            {
                Console.WriteLine($"Amount of fish caught: {fishInTons} tons.");
            }

            PrintMatrix(matrix);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowArray = Console.ReadLine()
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                    if (matrix[row, col] == 'S')
                    {

                    }
                }
            }

            return matrix;
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

        enum Direction
        {
            up,
            down,
            left,
            right
        }
    }
}
