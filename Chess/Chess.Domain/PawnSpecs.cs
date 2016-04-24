using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Chess.Domain
{
    [TestFixture]
    public class When_creating_a_chess_board
    {
        private IChessBoard _chessBoard;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
        }

        [Test]
        public void _001_the_playing_board_should_have_a_Max_Board_Width_of_7()
        {
            Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(7));
        }

        [Test]
        public void _002_the_playing_board_should_have_a_Max_Board_Height_of_7()
        {
            Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(7));
        }

        [Test]
        public void _005_the_playing_board_should_know_that_X_equals_0_and_Y_equals_0_is_a_valid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 0);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void _006_the_playing_board_should_know_that_X_equals_5_and_Y_equals_5_is_a_valid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(5, 5);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void _010_the_playing_board_should_know_that_X_equals_11_and_Y_equals_5_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 5);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void _011_the_playing_board_should_know_that_X_equals_0_and_Y_equals_8_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 9);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void _011_the_playing_board_should_know_that_X_equals_11_and_Y_equals_0_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 0);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void _012_the_playing_board_should_know_that_X_equals_minus_1_and_Y_equals_5_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(-1, 5);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void _012_the_playing_board_should_know_that_X_equals_5_and_Y_equals_minus_1_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(5, -1);
            Assert.That(isValidPosition, Is.False);
        }
    }

    [TestFixture]
    public class When_using_a_black_pawn_and
    {
        private IChessBoard _chessBoard;
        private IChessPiece _pawn;
        private IChessPiece _opponent;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _pawn = new Pawn(PieceColor.Black);
            _opponent = new Pawn(PieceColor.White);
        }

        [Test]
        public void _01_placing_the_black_pawn_on_X_equals_6_and_Y_equals_3_should_place_the_black_pawn_on_that_place_on_the_board()
        {
            _chessBoard.Add(_pawn, 6, 3);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void _10_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_7_and_Y_eqauls_3_should_not_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 3);
            _pawn.Move(7, 3);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void _11_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_4_and_Y_eqauls_3_should_not_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 3);
            _pawn.Move(4, 3);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void _20_making_a_legal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_6_and_Y_eqauls_2_should_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 3);
            _pawn.Move(6, 2);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void _31_legal_move_1_space()
        {
            _chessBoard.Add(_pawn, 6, 6);
            _pawn.Move(6, 5);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(5));
        }

        [Test]
        public void _31_legal_move_2_spaces()
        {
            _chessBoard.Add(_pawn, 6, 6);
            _pawn.Move(6, 4);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void _31_illegal_pawn_move_too_far()
        {
            _chessBoard.Add(_pawn, 6, 6);
            _pawn.Move(6, 3);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(6));
        }

        [Test]
        public void _31_pawn_move_blocked_by_opponent()
        {
            _chessBoard.Add(_pawn, 6, 6);
            _chessBoard.Add(_opponent, 6, 4);
            _pawn.Move(6, 4);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(6));
        }

    }

    [TestFixture]
    public class When_using_a_white_pawn_and
    {
        private IChessBoard _chessBoard;
        private IChessPiece _pawn;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _pawn = new Pawn(PieceColor.White);
        }

        [Test]
        public void _01_placing_the_white_pawn_on_X_equals_6_and_Y_equals_1_should_place_the_white_pawn_on_that_place_on_the_board()
        {
            _chessBoard.Add(_pawn, 6, 1);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void _10_making_an_illegal_move_by_placing_the_white_pawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_7_and_Y_eqauls_2_should_not_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 1);
            _pawn.Move(7, 2);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void _11_making_an_illegal_move_by_placing_the_white_pawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_6_and_Y_eqauls_4_should_not_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 1);
            _pawn.Move(6, 4);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void _12_making_an_illegal_move_by_placing_the_white_pawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_6_and_Y_eqauls_0_should_not_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 1);
            _pawn.Move(6, 0);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void _20_making_a_legal_move_by_placing_the_white_pawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_6_and_Y_eqauls_2_should_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 1);
            _pawn.Move(6, 2);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void _21_making_a_legal_move_by_placing_the_white_pawn_on_X_equals_6_and_Y_eqauls_1_and_moving_to_X_equals_6_and_Y_eqauls_3_should_move_the_pawn()
        {
            _chessBoard.Add(_pawn, 6, 1);
            _pawn.Move(6, 3);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
        }


    }

    [TestFixture]
    public class When_a_black_pawn_vs_white_pawn
    {
        private IChessBoard _chessBoard;
        private IChessPiece _pawn;
        private IChessPiece _opponent;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _pawn = new Pawn(PieceColor.Black);
            _opponent = new Pawn(PieceColor.White);
        }

        [Test]
        public void _31_black_pawn_capture_white_pawn()
        {
            _chessBoard.Add(_pawn, 3, 6);
            _chessBoard.Add(_opponent, 4, 1);
            Assert.That(_chessBoard.PiecesOnBoard(), Is.EqualTo(2));
            _pawn.Move(3, 5);
            _pawn.Move(3, 4);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(4));
            _opponent.Move(4, 3);
            Assert.That(_opponent.XCoordinate, Is.EqualTo(4));
            Assert.That(_opponent.YCoordinate, Is.EqualTo(3));
            _pawn.Capture(4, 3);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
            Assert.That(_chessBoard.PiecesOnBoard(), Is.EqualTo(1));
        }

        [Test]
        public void _32_black_vs_white_enPassant()
        {
            // take opposing pawn in passing 
            _chessBoard.Add(_pawn, 3, 6);
            _chessBoard.Add(_opponent, 4, 1);
            Assert.That(_chessBoard.PiecesOnBoard(), Is.EqualTo(2));
            _pawn.Move(3, 4);
            _pawn.Move(3, 3);
            _opponent.Move(4, 3);
            Assert.That(_opponent.XCoordinate, Is.EqualTo(4));
            Assert.That(_opponent.YCoordinate, Is.EqualTo(3));
            _pawn.Capture(4, 2);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(2));
            Assert.That(_chessBoard.PiecesOnBoard(), Is.EqualTo(1));
        }

        [Test]
        public void _33_black_vs_white_enPassant_Fail()
        {
            // take opposing pawn in passing 
            _chessBoard.Add(_pawn, 3, 6);
            _chessBoard.Add(_opponent, 4, 1);
            Assert.That(_chessBoard.PiecesOnBoard(), Is.EqualTo(2));
            _pawn.Move(3, 4);
            _opponent.Move(4, 3);
            _pawn.Move(3, 3);
            // move will fail, since the the enpassant action was not immediately after opponent move
            Assert.That(_opponent.XCoordinate, Is.EqualTo(4));
            Assert.That(_opponent.YCoordinate, Is.EqualTo(3));
            _pawn.Capture(4, 2);
            Assert.That(_pawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
            Assert.That(_chessBoard.PiecesOnBoard(), Is.EqualTo(2));
        }

    }

}
