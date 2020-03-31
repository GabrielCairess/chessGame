using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }

        public int QtdMovements { get; protected set; }
        public Board Brd { get; set; }

        public Piece(Board brd, Color color)
        {
            Brd = brd;
            Position = null;
            Color = color;
            QtdMovements = 0;
        }
    }
}
