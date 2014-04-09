using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class Validator
    {
        public bool IsCorrectMove(List<Move> moves, Checker[,] field, Color playerColor) //void + exceptions.
        {
            var result = true;
            foreach (var turn in moves)
                if (result)
                {
                    var bindingMoves = GetBindingMoves(field, playerColor);
                    if (bindingMoves.Count != 0 && !bindingMoves.Contains(turn))
                        return false;
                    if (!field[turn.From.X, turn.From.Y].IsQueen)
                        result &= IsCheckerTurnCorrect(field, playerColor, turn);
                    else
                        result &= IsQuennTurnCorrect(field, playerColor, turn);
                    if (result)
                        MakeMove(field, turn);
                }
                else break;
            return result;
        }

        private bool IsCheckerTurnCorrect(Checker[,] field, Color playerColor, Move turn)
        {
            var dx = new int[]{ 1, -1 };
            var dy = new int[]{ -1, 1 };
            for (var x = 0; x < 2; x++)
                for (var y = 0; y < 2; y++)
                    if (InField(new Point(turn.From.X + dx[x], turn.From.Y + dy[y])))
                        return field[turn.From.X + dx[x], turn.From.Y + dy[y]] == null &&
                            turn.From.X + dx[x] == turn.To.X && turn.From.Y + dy[y] == turn.To.Y;//ламповая проверка на возможность хода 
            dx = new int[] { 3, -3, 3, -3 };
            dy = new int[] { -3, -3, 3, 3 };
            for (var x = 0; x < 4; x++)
                for (var y = 0; y < 4; y++)
                    if (InField(new Point(turn.From.X + dx[x], turn.From.Y + dy[y])))
                        if (field[turn.From.X + dx[x], turn.From.Y + dy[y]] == null)
                        {
                            if (field[turn.From.X + dx[x], turn.From.Y + dy[y]].Color != playerColor)//ламповая проверка на возможность атаки
                                return true;
                        }
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

        private bool InField(Point pos)
        {
            return pos.X < 8 && pos.X >= 0 && pos.Y < 8 && pos.Y >= 0;
        }

        public HashSet<Move> GetBindingMoves(Checker[,] field, Color playerColor) 
        {
            var ans = new HashSet<Move>();
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    if (field[i, j] != null && field[i, j].Color == playerColor)
                        for (var di = -1; di < 2; di += 2)
                            for (var dj = -1; dj < 2; dj += 2)
                            {
                                var from = new Point(i, j);
                                var enemy = new Point(i + di, j + dj);
                                var free = new Point(i + di * 2, j + dj * 2);
                                if (InField(enemy) &&
                                    field[enemy.X, enemy.Y] != null &&
                                    field[enemy.X, enemy.Y].Color != playerColor &&
                                    InField(free) &&
                                    field[free.X, free.Y] == null)
                                    ans.Add(new Move(from, free));
                            }
            return ans;
        }

        private bool IsNeighbourEnemy(Checker[,] field, Point pos)
        {
            return true;
        }

        private void MakeMove(Checker[,] field, Move move)
        {

        }
    }
}
