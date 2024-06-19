namespace Domain
{
    public class Player : BoardPiece
    {
        public Player(Position position) : base(position)
        {
            
        }

        public int Lives { get; private set; } = 3;

        public void HitMine()
        {
            Lives--;
        }
    }
}
