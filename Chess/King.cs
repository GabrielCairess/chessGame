using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.board;

namespace ChessGame.Chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.getPiece(pos);
            return p == null || p.Color != Color;

        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            pos.defineValues(Position.Line - 1, Position.Column);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 1, Position.Column - 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line, Position.Column - 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line, Position.Column + 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 1, Position.Column + 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column - 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column + 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
