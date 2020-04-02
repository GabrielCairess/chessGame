using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.board;

namespace ChessGame.Chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            putPieces();
        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece p = Board.removePiece(origin);
            p.incrementMoviments();
            Piece capturedPiece = Board.removePiece(destiny);
            Board.putPiece(p, destiny);
        }

        private void putPieces()
        {
            Board.putPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.putPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.putPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.putPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.putPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.putPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.putPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.putPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.putPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.putPiece(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());

        }
    }
}
