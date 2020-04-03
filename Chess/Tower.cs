using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.board;

namespace ChessGame.Chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
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
            while (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
            }

            pos.defineValues(Position.Line + 1, Position.Column);
            while (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
            }

            pos.defineValues(Position.Line, Position.Column - 1);
            while (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }

            pos.defineValues(Position.Line, Position.Column + 1);
            while (Board.validPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.getPiece(pos) != null && Board.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column += 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
