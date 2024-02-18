using System;
using System.Linq;

namespace _02.DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int posRow = -1;
            int posCol = -1;

            int startRow = -1;
            int startCol = -1;

            char[,] neighborHood = new char[rows, cols];

            for (int row = 0; row < neighborHood.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < neighborHood.GetLength(1); col++)
                {
                    neighborHood[row, col] = line[col];

                    if (line[col] == 'B')
                    {
                        posRow = startRow = row;
                        posCol = startCol = col;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (OutsideOfBoard(rows, cols, posRow, posCol, input))
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    neighborHood[startRow, startRow] = ' ';
                    break;
                }
                else if (HitsAnObsticle(neighborHood, posRow, posCol, input, '*'))
                {
                    continue;
                }

                switch (input)
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

                if (neighborHood[posRow, posCol] == '-')
                {
                    neighborHood[posRow, posCol] = '.';
                }
                else if (neighborHood[posRow, posCol] == 'P')
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    neighborHood[posRow, posCol] = 'R';
                }
                else if (neighborHood[posRow, posCol] == 'A')
                {
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    neighborHood[posRow, posCol] = 'P';
                    break;
                }
            }

            PrintMatrix(neighborHood);
        }

        private static bool HitsAnObsticle(char[,] matrix, int posRow, int posCol, string input, char symbol)
        {
            if ((input == "left" && matrix[posRow, posCol - 1] == symbol) ||
                (input == "right" && matrix[posRow, posCol + 1] == symbol) ||
                (input == "up" && matrix[posRow - 1, posCol] == symbol) ||
                (input == "down" && matrix[posRow + 1, posCol] == symbol))
            {
                return true;
            }

            return false;
        }

        private static bool OutsideOfBoard(int rows, int cols, int posRow, int posCol, string input)
        {
            if (posRow == 0 && input == "up" ||
                posRow == rows - 1 && input == "down" ||
                posCol == 0 && input == "left" ||
                posCol == cols - 1 && input == "right")
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
