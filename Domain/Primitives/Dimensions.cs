namespace Domain;

public record struct Dimensions(int Width, int Height)
{
    public readonly int width = Width;
    public readonly int height = Height;
}