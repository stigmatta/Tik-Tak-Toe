using PlayerClass;
using BotClass;
using BoardClass;
using System;

namespace Tik_Tak_Toe
{
    internal class Game
    {
        Random rnd = new Random();
        char playerSymb, botSymb;
        Player player;
        Bot bot;
        Board board = new Board();
        bool playerMove;

        public Game()
        {
            GiveSymbs();
        }

        public void GiveSymbs()
        {
            playerSymb = rnd.Next(0, 2) == 0 ? 'X' : 'O';
            playerMove = playerSymb == 'X';
            player = new Player(playerSymb);
            botSymb = playerSymb == 'X' ? 'O' : 'X';
            bot = new Bot(botSymb);
        }

        public bool IsTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.GetBoardChar(i, j) == ' ')
                        return false;
                }
            }
            return true;
        }

        private bool HorizontalWin()
        {
            for (int i = 0; i < 3; i++)
            {
                char temp = board.GetBoardChar(i, 0);
                if (temp != ' ' && board.GetBoardChar(i, 1) == temp && board.GetBoardChar(i, 2) == temp)
                    return true;
            }
            return false;
        }

        private bool VerticalWin()
        {
            for (int j = 0; j < 3; j++)
            {
                char temp = board.GetBoardChar(0, j);
                if (temp != ' ' && board.GetBoardChar(1, j) == temp && board.GetBoardChar(2, j) == temp)
                    return true;
            }
            return false;
        }

        private bool DiagonalWin()
        {
            char temp = board.GetBoardChar(0, 0);
            if (temp != ' ' && board.GetBoardChar(1, 1) == temp && board.GetBoardChar(2, 2) == temp)
                return true;

            temp = board.GetBoardChar(0, 2);
            if (temp != ' ' && board.GetBoardChar(1, 1) == temp && board.GetBoardChar(2, 0) == temp)
                return true;

            return false;
        }

        public bool CheckWin()
        {
            return HorizontalWin() || VerticalWin() || DiagonalWin();
        }

        public void MakeMove()
        {
            if (playerMove)
            {
                while (true)
                {
                    Console.Clear();
                    board.PrintBoard();
                    Console.WriteLine("Your turn. Enter row (0-2): ");
                    if (!int.TryParse(Console.ReadLine(), out int moveX) || moveX < 0 || moveX > 2)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                        continue;
                    }

                    Console.WriteLine("Your turn. Enter column (0-2): ");
                    if (!int.TryParse(Console.ReadLine(), out int moveY) || moveY < 0 || moveY > 2)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                        continue;
                    }

                    if (board.GetBoardChar(moveX, moveY) == ' ')
                    {
                        board.SetBoardChar(moveX, moveY, playerSymb);
                        playerMove = false; 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This cell is occupied. Try again.");
                    }
                }
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    board.PrintBoard();

                    int moveX, moveY;
                    do
                    {
                        moveX = rnd.Next(0, 3);
                        moveY = rnd.Next(0, 3);
                    } while (board.GetBoardChar(moveX, moveY) != ' ');

                    board.SetBoardChar(moveX, moveY, botSymb);
                    playerMove = true;
                    break;
                }
            }
        }

        public void PlayGame()
        {
            while (true)
            {
                MakeMove();
                if (CheckWin())
                {
                    board.PrintBoard();
                    Console.WriteLine($"Player '{(playerMove ? botSymb : playerSymb)}' wins!");
                    break;
                }
                if (IsTie())
                {
                    board.PrintBoard();
                    Console.WriteLine("It's a tie!");
                    break;
                }
            }
        }
    }
}
