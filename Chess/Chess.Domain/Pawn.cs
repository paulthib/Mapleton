using System;

namespace Chess.Domain
{
    public class Pawn : ChessPiece
    {
       
        public Pawn(PieceColor pieceColor) : base(pieceColor, false)
        {
        }

        private int MovementDirection()
        {
            return (PieceColor == PieceColor.Black ? -1 : 1);
        }
        private int HomeYCoordinate()
        {
            return (PieceColor == PieceColor.Black ? 6 : 1);
        }
        private bool IsAtHomeCoordinate()
        {
            return _yCoordinate == (PieceColor == PieceColor.Black ? 6 : 1);
        }


        public override void Move(int newX, int newY)
        {
            var yMovement = (newY - _yCoordinate) * MovementDirection();
            if (newX == _xCoordinate && yMovement > 0)
            {
                if (((IsAtHomeCoordinate() && (yMovement <= 2))
                    || (newY == _yCoordinate + MovementDirection())))
                {
                    _chessBoard.Move(this, _xCoordinate, newY);
                }
            }
        }

        public override void Capture(int newX, int newY)
        {
            if (newX == _xCoordinate + 1 && newY == _yCoordinate + (1 * MovementDirection()))
            {
                _chessBoard.Capture(this, newX, newY);
            }
        }
        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected override string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
