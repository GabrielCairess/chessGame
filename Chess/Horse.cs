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

        public override string ToString()
        {
            return "H";
        }
    }
}
