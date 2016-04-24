using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain
{
    public interface IChessPiece
    {
        void Move(int newX, int newY);
        void Capture(int newX, int newY);

        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        int LastMoveNumber { get; set; }
        IChessBoard ChessBoard { get; set; }
        // setter is private
        PieceColor PieceColor { get;  }
        bool JumpingAllowed { get; }
    }
}
