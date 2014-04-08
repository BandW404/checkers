﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    class Validator
    {
        public bool IsCorrectMove(MoveInfo moveInfo, Color playerColor)
        {
            var result = true;
            foreach (var turn in moveInfo.Moves)
                if (result)
                {
                    var bindingMoves = GetBindingMoves(moveInfo.Field, playerColor);
                    if (bindingMoves.Count != 0 && !bindingMoves.Contains(turn))
                        return false;
                    if (!moveInfo.Field[turn.From.X, turn.From.Y].IsQueen)
                        result &= IsCheckerTurnCorrect(moveInfo.Field, playerColor, turn);
                    else
                        result &= IsQuennTurnCorrect(moveInfo.Field, playerColor, turn);
                }
                else break;
            return result;
        }

        private bool IsCheckerTurnCorrect(Checker[,] field, Color playerColor, Move turn)
        {
            var dx = new int[]{ 1, -1, 1, -1 };
            var dy = new int[]{ -1, 1, 1, -1 };
            for (var x = 0; x < 4; x++)
                for (var y = 0; y < 4; y++)
                    if (InField(field, new Point(turn.From.X + dx[x], turn.From.Y + dy[y])))
                        return field[turn.From.X + dx[x], turn.From.Y + dy[y]] == null &&
                            turn.From.X + dx[x] == turn.To.X && turn.From.Y + dy[y] == turn.To.Y; //ламповая проверка на возможность хода 
            return false;
        }

        private bool IsQuennTurnCorrect(Checker[,] field, Color playerColor, Move turn)
        {
            return true;
        }

        private bool IsNextTurnPossible(Checker[,] field, Color playerColor, Move turn)
        {
            return true;
        }

        private bool InField(Checker[,] field, Point pos)
        {
            return pos.X < field.GetLength(0) && pos.X > 0 && pos.Y < field.GetLength(1) && pos.Y > 0;
        }

        private HashSet<Move> GetBindingMoves(Checker[,] field, Color playerColor)
        {
            return new HashSet<Move>();
        }
    }
}
