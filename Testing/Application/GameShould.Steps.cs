using Application;
using Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Testing.Application;

public partial class GameShould : Specification
{
    private Board _board = null!;
    private Player player = null!;
    private FakeMineGenerator _fakeMineGenerator = null!;
    private Game game = null!;
    private GameState currentState;
    
    protected override void BeforeEach()
    {
        base.BeforeEach();
        _fakeMineGenerator = new FakeMineGenerator();
    }
    
    private void a_mineless_board()
    {
        _board = new Board(player, new Dimensions(3, 3), _fakeMineGenerator);
        game = new Game(_board);
    }

    private void a_board_full_of_mines()
    {
        _fakeMineGenerator.ShouldCreateMines(true);
        _board = new Board(player, new Dimensions(4, 4), _fakeMineGenerator);
        game = new Game(_board);
    }
    
    private void a_player()
    {
        player = new Player(new Position(0, 0));
    }

    private void the_player_gets_to_the_top()
    {
        game.Play(MoveDirection.Up);
        currentState = game.Play(MoveDirection.Up);
    }

    private void the_player_moves_into_3_mines()
    {
        game.Play(MoveDirection.Up);
        game.Play(MoveDirection.Up);
        currentState = game.Play(MoveDirection.Up);
    }

    private void the_player_is_at_the_top()
    {
        game.GetPlayerPosition().Should().Be(new Position(0, 2));
    }

    private void the_player_has_3_lives()
    {
        game.GetPlayerLives().Should().Be(3);
    }

    private void the_player_has_won()
    {
        currentState.Should().Be(GameState.Won);
    }
    
    private void the_player_has_lost()
    {
        currentState.Should().Be(GameState.Lost);
    }

    private void the_game_has_been_lost()
    {
        a_player();
        a_board_full_of_mines();
        the_player_moves_into_3_mines();
    }

    private void a_player_tries_to_move()
    {
        game.Play(MoveDirection.Right);
    }

    private void the_player_position_remains_the_same()
    {
        game.GetPlayerPosition().Should().Be(new Position(0, 3));
    }
    
}