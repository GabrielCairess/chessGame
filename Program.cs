using System;
using ChessGame.board;
using ChessGame.Chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Screen.printBoard(match.Board);
                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition();

                    match.executeMoviment(origin, destiny);
                }                
            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
