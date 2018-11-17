﻿using System.Linq;

namespace Kofi.Waves
{
    public class Player
    {
        public const char Us = 'o';
        public const char Them = 'x';
        public const char Neither = ' ';
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
            for (var i = 0; i < Winning.States.Length; i++)
            {
                if (board.Squares[Winning.States[i, 0]] == player &&
                    board.Squares[Winning.States[i, 1]] == player &&
                    board.Squares[Winning.States[i, 2]] == player)
                {
                    return true;
                }
            }

            return false;
        }
    }
}