using System;

namespace Chess.Domain
{
    public abstract class ChessPiece : IChessPiece
    {
        protected IChessBoard _chessBoard;
        protected int _xCoordinate;
        protected int _yCoordinate;
        protected PieceColor _pieceColor;

        public int LastMoveNumber { get; set; }

        public IChessBoard ChessBoard
        {
            get { return _chessBoard; }
            set { _chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return _pieceColor; }
            private set { _pieceColor = value; }
        }

        public ChessPiece(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        public abstract void Move(MovementType movementType, int newX, int newY);

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected virtual string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
