using System;
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

        [Fact]
        public void CanPlayFirst()
        {
            const string squares = "   " +
                                   "   " +
                                   "   ";

            const int expected = 8;
            var actual = MiniMax.BestNextMove(new Board(squares));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanPlaySecond()
        {
            const string squares = "   " +
                                   "   " +
                                   "  x";

            const int expected = 7;
            var actual = MiniMax.BestNextMove(new Board(squares));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TooFewSquaresRaisesException()
        {
            const string squares = "   " +
                                   "   " +
                                   "  ";

            Assert.Throws<ArgumentException>(() => new Board(squares));
        }

        [Fact]
        public void TooManySquaresRaisesException()
        {
            const string squares = "    " +
                                   "   " +
                                   "   ";

            Assert.Throws<ArgumentException>(() => new Board(squares));
        }
    }
}