using Domain;

namespace Testing;

public class FakeMineGenerator: IAmAMineGenerator
{
    private List<Mine> mines;
    private bool _shouldCreateMines;
    public void ShouldCreateMines(bool shouldCreateMines)
    {
        _shouldCreateMines = shouldCreateMines;
    }
    
    public IEnumerable<Mine> GenerateMines(Dimensions dimensions)
    {
        mines = new List<Mine>();

        if (_shouldCreateMines)
        {
            for (int x = 0; x < dimensions.width; x++)
            {
                for (int y = 0; y < dimensions.height; y++)
                {
                    var newPosition = new Position(x, y);
                    if (ValidPosition(newPosition))
                    {
                        mines.Add(new Mine(newPosition));
                    }
                }
            }
        }
        
        return mines;
    }

    private bool ValidPosition(Position position)
    {
        return !mines.Any(m => m.Position.Equals(position)) && !(position.X == 0 && position.Y == 0);
    }
}