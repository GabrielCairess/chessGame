using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.board;

namespace ChessGame.Chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void realizeMove(Position origin, Position destiny)
        {
            executeMoviment(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validatePositionOrigin(Position origin)
        {
            if (Board.getPiece(origin) == null)
            {
                throw new BoardException("Don't exists piece on the choosed position!");
            }
            if (Board.getPiece(origin).Color != currentPlayer)
            {
                throw new BoardException("Can't move a piece of the another player!");
            }
            if (!Board.getPiece(origin).existsPossibleMoviments())
            {
                throw new BoardException("Don't have any possible moviments");
            }
        }

        public void validatePositionDestiny(Position origin, Position destiny)
        {
            if (!Board.getPiece(origin).canPieceMove(destiny))
            {
                throw new BoardException("Can't realize this moviment with this piece!");
            }
        }


        private void changePlayer()
        {
            currentPlayer = currentPlayer == Color.White ? Color.Black : Color.White;
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
