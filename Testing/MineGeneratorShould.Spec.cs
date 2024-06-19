using NUnit.Framework;

namespace Testing
{
    [TestFixture]
    public partial class MineGeneratorShould
    {
        [Test]
        public void GenerateAtLeastThreeMines()
        {
            
            Given(() => a_mine_generator());
            When(() => mines_are_generated());
            Then(() => there_are_at_least_3_mines());
            And(() => no_mines_are_in_the_same_position());
        }
    }
}