using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> commands = new Queue<string>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray());

            char[,] matrix = new char[n, n];

            int posRow = -1;
            int posCol = -1;

            int hazelnutCount = 0;
            bool isTrappedOrOutsideOfMap = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 's')
                    {
                        posRow = row;
                        posCol = col;
                        matrix[posRow, posCol] = '*';
                    }
                }
            }

            while(commands.Any())
            {
                if (OutsideOfBoard(n, posRow, posCol, commands.Peek()))
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    isTrappedOrOutsideOfMap = true;
                    break;
                }

                switch (commands.Dequeue())
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

                if (matrix[posRow, posCol] != '*')
                {
                    if (matrix[posRow, posCol] == 'h')
                    {
                        hazelnutCount++;
                        if (hazelnutCount == 3)
                        {
                            Console.WriteLine("Good job! You have collected all hazelnuts!");
                            break;
                        }
                        matrix[posRow, posCol] = '*';

                    }
                    else if (matrix[posRow, posCol] == 't')
                    {
                        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                        isTrappedOrOutsideOfMap = true;
                        break;
                    }
                }
            }

            if (!isTrappedOrOutsideOfMap && hazelnutCount !=3)
            {
                Console.WriteLine($"There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {hazelnutCount}");
        }

        private static bool OutsideOfBoard(int size, int posRow, int posCol, string input)
        {
            if (posRow == 0 && input == "up" ||
                posRow == size - 1 && input == "down" ||
                posCol == 0 && input == "left" ||
                posCol == size - 1 && input == "right")
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
