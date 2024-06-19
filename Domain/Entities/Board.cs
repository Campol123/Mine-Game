using System.Runtime.Intrinsics.X86;

namespace Domain
{

    public class Board
    {
        private Dimensions _dimensions;
        private Player _player;
        private Mine[] _mines;
        
        public Board(Player player, Dimensions dimensions, IAmAMineGenerator mineGenerator)
        {
            _player = player;
            _dimensions = dimensions;
            _mines = mineGenerator.GenerateMines(_dimensions).ToArray();
        }
        
        public Player GetPlayer()
        {
            return _player;
        }

        public bool PlayerIsAtTop()
        {
            return _player.Position.Y == _dimensions.height - 1;
        }

        public void MovePlayer(MoveDirection movementDir)
        {
            switch(movementDir)
            {
                case MoveDirection.Up:
                    MoveYIfValid(MoveDirection.Up);
                    break;
                case MoveDirection.Right:
                    MoveXIfValid(MoveDirection.Right);
                    break;
                case MoveDirection.Down:
                    MoveYIfValid(MoveDirection.Down);
                    break;
                case MoveDirection.Left:
                    MoveXIfValid(MoveDirection.Left);
                    break;
            }
        }

        private void MoveYIfValid(MoveDirection moveDirection)
        {
            if (_player.Position.Y > 0 && moveDirection == MoveDirection.Down)
            {
                _player.Position = new Position(_player.Position.X, _player.Position.Y - 1);
                DetonateMine();
            }
            else if (_player.Position.Y  <= _dimensions.height - 2 && moveDirection == MoveDirection.Up)
            {
                _player.Position = new Position(_player.Position.X, _player.Position.Y + 1);
                DetonateMine();
            }
        }

        private void MoveXIfValid(MoveDirection moveDirection)
        {
            if (_player.Position.X > 0 && moveDirection == MoveDirection.Left)
            {
                _player.Position = new Position(_player.Position.X - 1, _player.Position.Y);
                DetonateMine();
            }
            else if (_player.Position.X <= _dimensions.width - 2 && moveDirection == MoveDirection.Right)
            {
                _player.Position = new Position(_player.Position.X + 1, _player.Position.Y);
                DetonateMine();
            }
        }

        private void DetonateMine()
        {
            var mine = _mines.FirstOrDefault(m => m.Position == _player.Position);

            if (mine is not null && !mine.IsMineDetonated())
            {
                _player.HitMine();
                mine.DetonateMine();
            }
        }
    }
}