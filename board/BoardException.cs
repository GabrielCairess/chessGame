using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.board
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
    }
}
