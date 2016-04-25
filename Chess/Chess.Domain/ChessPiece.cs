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

        public bool JumpingAllowed { get; private set; }

        public ChessPiece(PieceColor pieceColor, bool jumpingAllowed)
        {
            _pieceColor = pieceColor;
            JumpingAllowed = jumpingAllowed;
            LastMoveNumber = 0;
        }

        public abstract void Move(int newX, int newY);

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        //public virtual void Capture(int newX, int newY)
        //{
        //    //for most pieces, a move implicitly captures
        //    Move(newX, newY);
        //}

        protected virtual string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
