using Domain;

namespace Application;

public class Game(Board board)
{
    public GameState Play(MoveDirection moveDirection)
    {

        var currentGameState = CalculateGameState();
        if (currentGameState != GameState.Playing) return currentGameState;
        
        board.MovePlayer(moveDirection);
        return CalculateGameState();
    }

    public Position GetPlayerPosition()
    {
        return board.GetPlayer().Position;
    }

    public int GetPlayerLives()
    {
        return board.GetPlayer().Lives;
    }

    private GameState CalculateGameState()
    {
        if (board.GetPlayer().Lives <= 0)
        {
            return GameState.Lost;
        }
        
        if (board.PlayerIsAtTop())
        {
            return GameState.Won;
        }

        return default;
    }
}

public enum GameState
{
    Playing,
    Won,
    Lost
    
}