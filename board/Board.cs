﻿namespace ChessGame.board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        public Piece getPiece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece getPiece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public void putPiece(Piece p, Position pos)
        {
            if (!existsPiece(pos))
            {
                pieces[pos.Line, pos.Column] = p;
                p.Position = pos;
            }
            else
            {
                throw new BoardException("This position have a piece!");
            }
        }

        public Piece removePiece(Position pos)
        {
            if (getPiece(pos) == null)
            {
                return null;
            }

            Piece aux = getPiece(pos);
            aux.Position = null;
            pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool existsPiece(Position pos)
        {
            validatePosition(pos);
            return getPiece(pos) != null;
        }

        public bool validPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}