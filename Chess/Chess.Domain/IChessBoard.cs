using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain
{
    public interface IChessBoard
    {
        void Add(IChessPiece piece, int xCoordinate, int yCoordinate);
        void Move(IChessPiece piece, int toXCoordinate, int toYCoordinate);
        void Capture(IChessPiece piece, int toXCoordinate, int toYCoordinate);
        void Remove(IChessPiece piece);
        bool IsLegalBoardPosition(int xCoordinate, int yCoordinate);
        int PiecesOnBoard();

    }
}
