using ChessGame.board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Chess
{
    class Peon : Piece
    {
        public Peon(Board board, Color  color) : base(board, color)
        {
        }

        public override bool[,] possibleMoviments()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
