using Domain;

namespace Application;

public class Game
{
    private Board board;
    private Player player;
    public Game(Board board)
    {
        this.board = board;
    }
    public GameState Play(MoveDirection moveDirection)
    {
        if (board.GetPlayer().Lives <= 0)
        {
            return GameState.Lost;
        }
        else if(board.PlayerIsAtTop())
        {
            return GameState.Won;
        }
        board.MovePlayer(moveDirection);
        return default;
    }

    public Position GetPlayerPosition()
    {
        return board.GetPlayer().Position;
    }

    public int GetPlayerLives()
    {
        return board.GetPlayer().Lives;
    }
}

public enum GameState
{
    Playing,
    Won,
    Lost
    
}