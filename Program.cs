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
                ChessPosition chessPos = new ChessPosition('c', 7);
                Console.Write(chessPos.ToPosition());
                
            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
