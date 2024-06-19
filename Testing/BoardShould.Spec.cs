using NUnit.Framework;
using Domain;

namespace Testing
{
    [TestFixture]
    public partial class BoardShould
    {
        [TestCase(MoveDirection.Up,1,2)]
        [TestCase(MoveDirection.Down,1,0)]
        [TestCase(MoveDirection.Left,0,1)]
        [TestCase(MoveDirection.Right,2,1)]
        public void LetPlayerMoveOneSpace(MoveDirection moveDirection, int X, int Y)
        {
            Given(() => a_player_at_position(1,1));
            And(() => a_board_of_size(4, 4));
            When(() => a_player_moves(moveDirection));
            Then(() => the_player_has_moved(X,Y));
        }

        [TestCase(MoveDirection.Up, 2, 4)]
        [TestCase(MoveDirection.Down, 2, 0)]
        [TestCase(MoveDirection.Left, 0, 2)]
        [TestCase(MoveDirection.Right, 4, 2)]
        public void LetPlayerMoveTwoSpaces(MoveDirection moveDirection, int X, int Y)
        {
            Given(() => a_player_at_position(2, 2));
            And(() => a_board_of_size(6, 6));
            When(() => a_player_moves(moveDirection));
            And(() => a_player_moves(moveDirection));
            Then(() => the_player_has_moved(X, Y));
        }

        [TestCase(MoveDirection.Left, 0, 0)]
        [TestCase(MoveDirection.Down, 0, 0)]
        [TestCase(MoveDirection.Up, 0, 3)]
        [TestCase(MoveDirection.Right, 3, 0)]
        public void DoesNotLetPlayerMoveIntoVoidSpace(MoveDirection moveDirection, int X, int Y)
        {
            Given(() => a_player_at_position(X, Y));
            And(() => a_board_of_size(4, 4));
            When(() => a_player_moves(moveDirection));
            Then(() => the_player_has_moved(X, Y));
        }
        
        [Test]
        public void PlayerCanDetonateMine()
        {
            Given(() => a_player_at_position(0, 0));
            And(a_board_is_full_of_mines);
            And(() => a_board_of_size(8, 8));
            When(() => a_player_moves(MoveDirection.Up));
            Then(the_player_loses_a_life);
        }
        
        [Test]
        public void PlayerCannotDetonateMineTwice()
        {
            Given(() => a_player_at_position(0, 0));
            And(a_board_is_full_of_mines);
            And(() => a_board_of_size(8, 8));
            When(() => a_player_moves(MoveDirection.Up));
            When(() => a_player_moves(MoveDirection.Down));
            When(() => a_player_moves(MoveDirection.Up));
            Then(the_player_loses_a_life);
        }
    }
}
