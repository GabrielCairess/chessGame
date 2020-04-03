using ChessGame.board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Chess
{
    class Peon : Piece
    {
        private ChessMatch Match;
        public Peon(Board board, Color  color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.defineValues(Position.Line - 1, Position.Column);
                if (Board.validPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line - 2, Position.Column);
                if (Board.validPosition(pos) && CanMove(pos) && QtdMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line - 1, Position.Column - 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line - 1, Position.Column + 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //En Passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.validPosition(left) && existEnemy(left) && Board.getPiece(left) == Match.availableEmPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.validPosition(right) && existEnemy(right) && Board.getPiece(right) == Match.availableEmPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.defineValues(Position.Line + 1, Position.Column);
                if (Board.validPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line + 2, Position.Column);
                if (Board.validPosition(pos) && CanMove(pos) && QtdMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line + 1, Position.Column - 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line + 1, Position.Column + 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //En Passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.validPosition(left) && existEnemy(left) && Board.getPiece(left) == Match.availableEmPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.validPosition(right) && existEnemy(right) && Board.getPiece(right) == Match.availableEmPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }

        private bool existEnemy(Position pos)
        {
            Piece p = Board.getPiece(pos);
            return p != null && p.Color != Color;
        }

        private bool free(Position pos)
        {
            return Board.getPiece(pos) == null;
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.getPiece(pos);
            return p == null || p.Color != Color;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
