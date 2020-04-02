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

        public abstract bool[,] possibleMoviments();
    }
}
