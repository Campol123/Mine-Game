namespace Domain;

public abstract class BoardPiece
{
    public Position Position;
    
    public BoardPiece(Position position)
    {
        Position = position;
    }
}