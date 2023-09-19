using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a game to play:");
            Console.WriteLine("1. Guess the Number");
            Console.WriteLine("2. Tic-Tac-Toe");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayGuessTheNumber();
                    break;
                case "2":
                    PlayTicTacToe();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    static void PlayGuessTheNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101);
        int attempts = 0;
        int guess = 0;

        Console.WriteLine("Welcome to Guess the Number!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        while (guess != randomNumber)
        {
            Console.Write("Enter your guess: ");
            if (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            attempts++;

            if (guess < randomNumber)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine($"Congratulations! You guessed the number {randomNumber} in {attempts} attempts.");
            }
        }

        Console.WriteLine("Thanks for playing Guess the Number!");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void PlayTicTacToe()
    {
        char[,] board = new char[3, 3];
        char currentPlayer = 'X';
        bool isGameFinished = false;

        InitializeBoard(board);

        do
        {
            Console.Clear();
            PrintBoard(board);
            GetPlayerMove(board, currentPlayer);
            CheckForWin(board, currentPlayer);
            SwitchPlayer(ref currentPlayer);
        } while (!isGameFinished);

        Console.Clear();
        PrintBoard(board);
        if (isGameFinished)
        {
            Console.WriteLine("Game over! Player " + currentPlayer + " wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }

        Console.WriteLine("Thanks for playing Tic-Tac-Toe!");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void InitializeBoard(char[,] board)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    static void PrintBoard(char[,] board)
    {
        Console.WriteLine("  1 2 3");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row + 1);
            for (int col = 0; col < 3; col++)
            {
                Console.Write("|" + board[row, col]);
            }
            Console.WriteLine("|");
        }
    }

    static void GetPlayerMove(char[,] board, char currentPlayer)
    {
        int row, col;
        do
        {
            Console.Write("Player " + currentPlayer + ", enter your move (row[1-3] column[1-3]): ");
            string[] input = Console.ReadLine().Split(' ');
            row = int.Parse(input[0]) - 1;
            col = int.Parse(input[1]) - 1;
        } while (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ');

        board[row, col] = currentPlayer;
    }

    static void CheckForWin(char[,] board, char currentPlayer)
    {
        // Check for a win or draw here (same code as before)
        // ...
    }

    static void SwitchPlayer(ref char currentPlayer)
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }
}