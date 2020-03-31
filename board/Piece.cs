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

        public Piece(Position position, Color color, Board brd)
        {
            Position = position;
            Color = color;
            QtdMovements = 0;
            Brd = brd;
        }
    }
}
