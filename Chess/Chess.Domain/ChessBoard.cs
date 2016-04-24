using System;

namespace Chess.Domain
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private Pawn[,] pieces;

        public ChessBoard ()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            pawn.XCoordinate = xCoordinate;
            pawn.YCoordinate = yCoordinate;

            pieces[xCoordinate, yCoordinate] = pawn;
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (xCoordinate >= 0 && xCoordinate <= MaxBoardWidth) && (yCoordinate >= 0 && yCoordinate <= MaxBoardHeight);
        }

    }
}
