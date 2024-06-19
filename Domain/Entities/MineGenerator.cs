namespace Domain;

public interface IAmAMineGenerator
{
    public IEnumerable<Mine> GenerateMines(Dimensions dimensions);
}
public class MineGenerator: IAmAMineGenerator
{
    private List<Mine> mines;
    public IEnumerable<Mine> GenerateMines(Dimensions dimensions)
    {
        mines = new List<Mine>();
        
        Random rnd = new Random();

        int numOfMines = rnd.Next(3, (dimensions.width * dimensions.height) - 1);

        for (int i = 0; i <= numOfMines; i++)
        {
            while (true)
            {
                int x = rnd.Next(0,dimensions.width-1);
                int y = rnd.Next(0,dimensions.height-1);
                if (ValidPosition(new Position(x, y)))
                {
                    mines.Add(new Mine(new Position(x,y)));
                    break;
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