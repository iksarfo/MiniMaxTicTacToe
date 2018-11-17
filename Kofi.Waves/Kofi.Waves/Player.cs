using System.Collections.Generic;
using System.Linq;

namespace Kofi.Waves
{
    public class Player
    {
        public const char Us = 'o';
        public const char Them = 'x';
        public const char Neither = ' ';

        public static char Next(char player) => player == Us ? Them : Us;
    }

    public class Board
    {
        private char[] _validPieces = new char[] { Player.Us, Player.Them, Player.Neither };

        public string Squares { get; }

        public Board(string squares)
        {
            Squares = squares;
        }

        public bool HasNoEmptySquares() => Squares.All(_ => _ != Player.Neither);

        public Board AddPiece(char player, int location)
        {
            var newBoardState = new char[Squares.Length];
            for (var square = 0; square < Squares.Length; square++)
            {
                newBoardState[square] =
                    location == square
                    ? player
                    : Squares[square];
            }

            return new Board(new string(newBoardState));
        }
    }

    public static class Winning
    {
        public static int[,] States => new[,]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };
    }

    public class Game
    {
        public static bool Over(Board board) => board.HasNoEmptySquares();

        public static bool HasBeenWon(Board board, char player)
        {
            return Winning.States.Cast<int>().Where((_, i) =>
                i <= Winning.States.GetUpperBound(0) &&
                board.Squares[Winning.States[i, 0]] == player && 
                board.Squares[Winning.States[i, 1]] == player && 
                board.Squares[Winning.States[i, 2]] == player).Any();
        }
    }

    public static class MiniMax
    {
        public static int BestLocationForNextPiece { get; private set; }

        public static int BestNextMove(Board board)
        {
            Calculate(board, 0, Player.Us);

            return BestLocationForNextPiece;
        }

        private static int GetScore(Board board, int depth)
        {
            if (Game.HasBeenWon(board, Player.Us))
            {
                return 10 - depth;
            }

            if (Game.HasBeenWon(board, Player.Them))
            {
                return depth - 10;
            }

            return 0;
        }

        private static int Calculate(Board board, int depth, char player)
        {
            if (Game.Over(board))
            {
                return GetScore(board, depth);
            }

            depth++;

            var moves = new Dictionary<int, int>();
            for (var location = 0; location < board.Squares.Length; location++)
            {
                if (board.Squares[location] != Player.Neither)
                {
                    continue;
                }

                var played = board.AddPiece(player, location);
                var miniMax = Calculate(played, depth, Player.Next(player));
                moves[miniMax] = location;
            }

            var best =
                player == Player.Us
                    ? moves.Keys.Max()
                    : moves.Keys.Min();

            BestLocationForNextPiece = moves[best];

            return best;
        }
    }
}