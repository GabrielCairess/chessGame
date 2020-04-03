using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.board;

namespace ChessGame.Chess
{
    class King : Piece
    {
        private ChessMatch Match;
        public King(Board board, Color color, ChessMatch match ) : base(board, color)
        {
            Match = match;
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.getPiece(pos);
            return p == null || p.Color != Color;

        }

        private bool testTowerRock(Position pos)
        {
            Piece p = Board.getPiece(pos);
            return p != null && p is Tower && p.Color == Color && p.QtdMovements == 0;
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

            // rock

            if (QtdMovements == 0 && !Match.check)
            {
                // small
                Position posT1 = new Position(Position.Line, Position.Column + 3);

                if (testTowerRock(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);

                    if (Board.getPiece(p1) == null && Board.getPiece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                
                // big
                Position posT2 = new Position(Position.Line, Position.Column - 4);

                if (testTowerRock(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);

                    if (Board.getPiece(p1) == null && Board.getPiece(p2) == null && Board.getPiece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
