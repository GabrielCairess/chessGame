using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }

        public int QtdMovements { get; protected set; }
        public Board brd { get; set; }

        public Piece(Position position, Color color, Board brd)
        {
            this.position = position;
            this.color = color;
            QtdMovements = 0;
            this.brd = brd;
        }
    }
}
