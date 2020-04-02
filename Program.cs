using System;
using ChessGame.board;
using ChessGame.Chess;
using System.Collections.Generic;

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
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition();
                        match.validatePositionOrigin(origin);

                        bool[,] possiblePositions = match.Board.getPiece(origin).possibleMoviments();

                        Console.Clear();
                        Screen.printBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPosition();
                        match.validatePositionDestiny(origin, destiny);

                        match.realizeMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.printMatch(match);
                Console.ReadLine();
            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
