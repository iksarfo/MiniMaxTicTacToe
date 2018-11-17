using Xunit;

namespace Kofi.Waves.Tests
{
    public class MiniMaxTests
    {
        [Fact]
        public void AvoidsObviousLoss()
        {
            const string squares = "xo " +
                                 "oxx" +
                                 "ox ";

            const int expected = 8;
            var actual = MiniMax.BestNextMove(new Board(squares));
            Assert.Equal(expected, actual);
        }
    }
}