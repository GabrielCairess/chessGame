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
        public bool check { get; set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            pieces = new HashSet<Piece>();
            check = false;
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public Piece executeMoviment(Position origin, Position destiny)
        {
            Piece p = Board.removePiece(origin);
            p.incrementMoviments();
            Piece capturedPiece = Board.removePiece(destiny);
            Board.putPiece(p, destiny);

            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void remakeMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.removePiece(destiny);
            p.decrementMoviments();

            if (capturedPiece != null)
            {
                Board.putPiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            Board.putPiece(p, origin);
        }

        public void realizeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = executeMoviment(origin, destiny);


            if (isInCheck(currentPlayer))
            {
                remakeMove(origin, destiny, capturedPiece);
                throw new BoardException("Can't put in check yourself!");
            }

            check = isInCheck(getOpponent(currentPlayer)) ? true : false;

            if (isCheckMate(getOpponent(currentPlayer)))
            {
                Finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
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
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(onlycapturedPieces(color));
            return aux;
        }

        private Color getOpponent(Color color)
        {
            return color == Color.Black ? Color.White : Color.Black;
        }

        private Piece king(Color color)
        {
            foreach (Piece p in piecesInGame(color))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece r = king(color);
            if (r == null)
            {
                throw new BoardException("No King in the board!");
            }
            
            foreach (Piece p in piecesInGame(getOpponent(color)))
            {
                bool[,] mat = p.possibleMoviments();
                if (mat[r.Position.Line, r.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isCheckMate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }

            foreach (Piece p in piecesInGame(color))
            {
                bool[,] mat = p.possibleMoviments();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = p.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMoviment(origin, destiny);

                            bool checkTeste = isInCheck(color);
                            remakeMove(origin, destiny, capturedPiece);
                            if (!checkTeste)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Tower(Board, Color.White));
            putNewPiece('d', 1, new King(Board, Color.White));
            putNewPiece('h', 7, new Tower(Board, Color.White));

            putNewPiece('a', 8, new King(Board, Color.Black));
            putNewPiece('b', 8, new Tower(Board, Color.Black));
        }
    }
}
