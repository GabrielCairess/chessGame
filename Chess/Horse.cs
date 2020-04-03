using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.board;

namespace ChessGame.Chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            pos.defineValues(Position.Line - 1, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 2, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 2, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 1, Position.Column + 2);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column + 2);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 2, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column - 2);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            return mat;
        }

        private bool canMove(Position pos)
        {
            Piece p = Board.getPiece(pos);
            return p == null || p.Color != Color;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
