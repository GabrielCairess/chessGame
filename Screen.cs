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
                    printPiece(board.getPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece p)
        {
            if (p == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }

        internal static void printBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    Console.BackgroundColor = possiblePositions[i, j] ? alteredBackground : originalBackground;
                    printPiece(board.getPiece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static Position readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line).ToPosition();
        }
        
        public static void printMatch(ChessMatch match)
        {
            Screen.printBoard(match.Board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);

            if (!match.Finished)
            {
                Console.WriteLine("Aguardando Jogada: " + match.currentPlayer);

                if (match.check)
                {
                    Console.WriteLine("CHEEECK!");
                }
            }
            else
            {
                Console.WriteLine("CHEEECK MAAATE!!");
                Console.WriteLine("Winner: " + match.currentPlayer + "!!");
            }
        }

        public static void printCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("Whites: ");
            printCollection(match.onlycapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Blacks: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            printCollection(match.onlycapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printCollection(HashSet<Piece> collection)
        {
            Console.Write("[ ");
            foreach (Piece p in collection)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }
    }
}
