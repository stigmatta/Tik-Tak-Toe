using System;

namespace BoardClass
{
    internal class Board
    {
        private char[,] board = new char[3, 3];
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    board[i, j] = ' ';
            }
        }

        public char GetBoardChar(int row,int col)
        {
            return board[row,col];
        }

        public void SetBoardChar(int row,int col, char ch)
        {
            board[row,col] = ch;
        }

        public void PrintBoard()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"  {board[i, j]}  |");
                    Console.ResetColor();
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("-------------------");
            }
            Console.WriteLine();
            Console.WriteLine();

        }

    }
}
