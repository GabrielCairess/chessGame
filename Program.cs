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
                Board board = new Board(8, 8);

                board.putPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.putPiece(new Tower(board, Color.Black), new Position(1, 3));
                board.putPiece(new King(board, Color.White), new Position(0, 2));
                board.putPiece(new King(board, Color.White), new Position(0, 9));

                Screen.printBoard(board);

                Console.WriteLine(board.Lines);
            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
