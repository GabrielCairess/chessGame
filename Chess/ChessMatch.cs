using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.board;

namespace ChessGame.Chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            putPieces();
        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoviments();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
        }

        private void putPieces()
        {
            board.putPiece(new Tower(board, Color.White), new ChessPosition('c', 1).ToPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('c', 2).ToPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('e', 2).ToPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('e', 1).ToPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition('d', 1).ToPosition());

            board.putPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).ToPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).ToPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).ToPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).ToPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('e', 8).ToPosition());

        }
    }
}
