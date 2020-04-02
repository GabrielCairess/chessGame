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

        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece p = Board.removePiece(origin);
            p.incrementMoviments();
            Piece capturedPiece = Board.removePiece(destiny);
            Board.putPiece(p, destiny);

            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
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

        public void putNewPiece(char column, int line, Piece piece)
        {
            Board.putPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        public HashSet<Piece> onlycapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(onlycapturedPieces(color));
            return aux;
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Tower(Board, Color.White));
            putNewPiece('c', 2, new Tower(Board, Color.White));
            putNewPiece('e', 2, new Tower(Board, Color.White));
            putNewPiece('e', 1, new Tower(Board, Color.White));
            putNewPiece('d', 1, new Tower(Board, Color.White));

            putNewPiece('c', 7, new Tower(Board, Color.Black));
            putNewPiece('c', 8, new Tower(Board, Color.Black));
            putNewPiece('d', 7, new Tower(Board, Color.Black));
            putNewPiece('e', 7, new Tower(Board, Color.Black));
            putNewPiece('e', 8, new Tower(Board, Color.Black));
        }
    }
}
