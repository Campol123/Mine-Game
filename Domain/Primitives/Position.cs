namespace Domain;

public record struct Position(int X, int Y)
{
    public readonly int X = X;
    public readonly int Y = Y;
}