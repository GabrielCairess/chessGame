using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }

        public int QtdMovements { get; protected set; }
        public Board Board { get; set; }

        public Piece(Board board, Color color)
        {
            Board = board;
            Position = null;
            Color = color;
            QtdMovements = 0;
        }

        public void incrementMoviments()
        {
            QtdMovements++;
        }

        public bool existsPossibleMoviments()
        {
            bool[,] mat = possibleMoviments();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canPieceMove(Position destiny)
        {
            return possibleMoviments()[destiny.Line, destiny.Column];
        }

        public abstract bool[,] possibleMoviments();
    }
}
