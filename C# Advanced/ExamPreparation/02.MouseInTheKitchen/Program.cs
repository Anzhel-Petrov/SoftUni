using System;
using System.Linq;

namespace _02.MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int posRow = -1;
            int posCol = -1;

            int lastPosRow = 0;
            int lastPosCol = 0;

            int cheeseCount = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 'M')
                    {
                        posRow = row;
                        posCol = col;
                    }

                    if (line[col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "danger") 
            {
                matrix[posRow, posCol] = '*';
                lastPosRow = posRow;
                lastPosCol = posCol;

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

                if (CheckIfOutsideMatrix(posRow, posCol, rows, cols))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    posRow = lastPosRow; 
                    posCol = lastPosCol;
                    matrix[posRow, posCol] = 'M';
                    PrintMatrix(matrix);
                    return;
                }

                if (matrix[posRow, posCol] != '*')
                {
                    if (matrix[posRow, posCol] == 'C')
                    {
                        cheeseCount--;
                        matrix[posRow, posCol] = '*';
                        if (cheeseCount == 0)
                        {
                            matrix[posRow, posCol] = 'M';
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[posRow, posCol] == '@')
                    {
                        posRow = lastPosRow; 
                        posCol = lastPosCol;
                    }
                    else
                    {
                        Console.WriteLine("Mouse is trapped!");
                        matrix[posRow, posCol] = 'M';
                        PrintMatrix(matrix);
                        return;
                    }
                }
                matrix[posRow, posCol] = 'M';
            }

            Console.WriteLine("Mouse will come back later!");
            PrintMatrix(matrix);

        }

        private static bool CheckIfOutsideMatrix(int posRow, int posCol, int rows, int cols)
        {
            if (posRow >= rows ||
                posRow < 0 ||
                posCol >= cols ||
                posCol < 0)
            {
                return true;
            }

            return false;
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
