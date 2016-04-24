using System;

namespace Chess.Domain
{
    public class ChessBoard : IChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private IChessPiece[,] pieces;
        private int moveCounter;

        public ChessBoard ()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
            moveCounter = 0;
        }

        public void Add(IChessPiece piece, int xCoordinate, int yCoordinate)
        {
            //removed argument pieceColor since the piece knows its coloe
            piece.XCoordinate = xCoordinate;
            piece.YCoordinate = yCoordinate;
            piece.ChessBoard = this;

            pieces[xCoordinate, yCoordinate] = piece;
        }

        public void Move(IChessPiece piece, int toXCoordinate, int toYCoordinate)
        {
            if (IsLegalBoardPosition(toXCoordinate, toYCoordinate))
            {
                Remove(piece);
                Add(piece, toXCoordinate, toYCoordinate);
                moveCounter++;
                piece.LastMoveNumber = moveCounter;
            }
        }

        public void Capture(IChessPiece piece, int toXCoordinate, int toYCoordinate)
        {
            if (IsLegalBoardPosition(toXCoordinate, toYCoordinate) )
            {
                var opponentPiece = pieces[toXCoordinate, toYCoordinate];

                //no opponent piece to capture
                if (opponentPiece == null || opponentPiece.PieceColor == piece.PieceColor)
                {
                    opponentPiece = TakingEnPassant(piece, toXCoordinate, toYCoordinate);
                }
                if (opponentPiece == null) return;
                //remove opponent piece
                Remove(opponentPiece);
                //move piece
                Remove(piece);
                Add(piece, toXCoordinate, toYCoordinate);
            }
        }

        private IChessPiece TakingEnPassant(IChessPiece piece, int toXCoordinate, int toYCoordinate)
        {
            if (piece.GetType() == typeof(Pawn))
            {
                var opponentPiece = pieces[toXCoordinate, piece.YCoordinate];
                if (opponentPiece.GetType() == typeof(Pawn) 
                    && opponentPiece.PieceColor != piece.PieceColor
                    && opponentPiece.LastMoveNumber == moveCounter)
                {
                    return opponentPiece;
                }
            }
            return null;
        }

        public void Remove(IChessPiece piece)
        {
            pieces[piece.XCoordinate, piece.YCoordinate] = null;
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (xCoordinate >= 0 && xCoordinate <= MaxBoardWidth) && (yCoordinate >= 0 && yCoordinate <= MaxBoardHeight);
        }

        public int PiecesOnBoard()
        {
            int pieceCount = 0;
            foreach (var piece in pieces)
            {
                if (piece != null) pieceCount++;
            }
            return pieceCount;
        }
    }
}
