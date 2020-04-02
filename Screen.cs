using ChessGame.board;
using ChessGame.Chess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(board.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece p)
        {
            if (p.Color == Color.White)
            {
                Console.Write(p);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(p);
                Console.ForegroundColor = aux;
            }
        }

        public static Position readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line).ToPosition();
        }
    }
}
