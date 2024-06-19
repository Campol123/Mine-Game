namespace Domain;

public class Mine(Position position) : BoardPiece(position)
{
    private bool mineDetonated;

    public void DetonateMine()
    {
        mineDetonated = true;
    }

    public bool IsMineDetonated()
    {
        return mineDetonated;
    }
}