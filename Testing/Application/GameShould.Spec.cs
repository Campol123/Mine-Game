using NUnit.Framework;

namespace Testing.Application;

public partial class GameShould
{
    [Test]
    public void LetPlayerWin()
    {
        Given(a_player);
        And(a_mineless_board);
        When(the_player_gets_to_the_top);
        Then(the_player_has_won);
        And(the_player_is_at_the_top);
        And(the_player_has_3_lives);
    }

    [Test]
    public void LetPlayerLose()
    {
        Given(a_player);
        And(a_board_full_of_mines);
        When(the_player_moves_into_3_mines);
        Then(the_player_has_lost);
    }

    [Test]
    public void StopPlayerMovingAfterFinish()
    {
        Given(the_game_has_been_lost);
        When(a_player_tries_to_move);
        Then(the_player_position_remains_the_same);
    }
}