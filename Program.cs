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
                    Screen.printBoard(match.Board);
                    Console.WriteLine();

                    
                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition();

                    bool[,] possiblePositions = match.Board.getPiece(origin).possibleMoviments();

                    Console.Clear();
                    Screen.printBoard(match.Board, possiblePositions);

                    
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
