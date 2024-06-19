using Domain;
using FluentAssertions;

namespace Testing
{
    public partial class BoardShould : Specification
    {
        private Board _board;
        private Player player;
        private FakeMineGenerator _fakeMineGenerator;

        protected override void BeforeEach()
        {
            base.BeforeEach();
            _fakeMineGenerator = new FakeMineGenerator();
        }
        
        private void a_player_at_position(int X, int Y)
        {
            player = new Player(new Position(X, Y));
        }
        
        private void a_board_of_size(int width, int height)
        {
            _board = new Board(player, new Dimensions(width, height), _fakeMineGenerator);
        }

        private void a_player_moves(MoveDirection moveDirection)
        {
            _board.MovePlayer(moveDirection);
        }
        private void the_player_has_moved(int X, int Y)
        {
            player = _board.GetPlayer();
            player.Position.Should().Be(new Position(X, Y));
        }

        private void a_board_is_full_of_mines()
        {
            _fakeMineGenerator.ShouldCreateMines(true);
        }

        private void the_player_loses_a_life()
        {
            player.Lives.Should().Be(2);
        }
    }
}
