namespace _02.TheGambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] gameBoard = new char[n, n];
            int posRow = -1;
            int posCol = -1;
            int playerBalance = 100;

            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    gameBoard[row, col] = line[col];
                    if (line[col] == 'G')
                    {
                        posRow = row;
                        posCol = col;
                        gameBoard[posRow, posCol] = '-';
                        continue;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (posRow == 0 && command == "up" ||
                    posRow == n - 1 && command == "down" ||
                    posCol == 0 && command == "left" ||
                    posCol == n - 1 && command == "right")
                {
                    Console.WriteLine("Game over! You lost everything!");
                    return;
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

                if (gameBoard[posRow, posCol] == 'W')
                {
                    playerBalance += 100;
                }

                if (gameBoard[posRow, posCol] == 'P')
                {
                    playerBalance -= 200;
                    if (playerBalance <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }
                }

                if (gameBoard[posRow, posCol] == 'J')
                {
                    Console.WriteLine("You win the Jackpot!");
                    playerBalance += 100000;
                    break;
                }

                gameBoard[posRow, posCol] = '-';
            }

            gameBoard[posRow, posCol] = 'G';
            Console.WriteLine($"End of the game. Total amount: {playerBalance}$");
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    Console.Write(gameBoard[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
