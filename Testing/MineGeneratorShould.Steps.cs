using Domain;
using FluentAssertions;

namespace Testing
{
    public partial class MineGeneratorShould : Specification
    {
        private MineGenerator _mineGenerator;
        private IEnumerable<Mine> _mines = null;

        private void a_mine_generator()
        {
            _mineGenerator = new MineGenerator();
        }

        private void mines_are_generated()
        {
            _mines = _mineGenerator.GenerateMines(new Dimensions(8,8));
        }

        private void there_are_at_least_3_mines()
        {
            _mines.Count().Should().BeGreaterThan(2);
        }

        private void no_mines_are_in_the_same_position()
        {
            _mines.GroupBy(m => m.Position).Count().Should().Be(_mines.Count());
        }

    }
}
