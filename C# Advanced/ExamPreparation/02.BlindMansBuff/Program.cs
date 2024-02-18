using System;
using System.Linq;

namespace _02.BlindMansBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            int posRow = -1;
            int posCol = -1;
            int opponents = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'B')
                    {
                        posRow = row;
                        posCol = col;
                        matrix[row, col] = '-';
                    }

                    if (matrix[row, col] == 'P')
                    {
                        opponents++;
                    }
                }
            }

            string command = "";
            int touches = 0;
            int moves = 0;
            
            while ((command = Console.ReadLine()) != "Finish" && opponents != 0)
            {
                if (OutsideOfBoard(rows, cols, posRow, posCol, command) || HitsAnObsticle(matrix, posRow, posCol, command, 'O'))
                {
                    continue;
                }

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

                if (matrix[posRow, posCol] == '-')
                {
                    moves++;
                }
                else if (matrix[posRow, posCol] == 'P')
                {
                    moves++;
                    touches++;
                    opponents--;
                    matrix[posRow, posCol] = '-';
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touches} Moves made: {moves}");
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
    }
}
