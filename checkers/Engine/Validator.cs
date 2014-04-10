using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class Validator
    {
        public void IsCorrectMove(List<Move> moves, Checker[,] field, Color playerColor) //void + exceptions.
        {
            var result = true;
            foreach (var turn in moves)
                if (result)
                {
                    var bindingMoves = GetBindingMoves(field, playerColor);
                    if (bindingMoves.Count != 0 && !bindingMoves.Contains(turn))
                        throw new NotImplementedException();
                    if (!field[turn.From.X, turn.From.Y].IsQueen)
                        result &= IsCheckerTurnCorrect(field, playerColor, turn);
                    else
                        result &= IsQuennTurnCorrect(field, playerColor, turn);
                    if (result)
                        MakeMove(field, turn);
                }
                if (!result) throw new NotImplementedException();
            return;
        }

        private bool IsCheckerTurnCorrect(Checker[,] field, Color playerColor, Move turn)
        {
            var dx = new int[2];
            var dy = new int[2];
            if (playerColor == Color.White)
            {
                dx = new int[] { 1, -1 };
                dy = new int[] { 1, -1 };
            }
            else
            {
                dx = new int[] { -1, 1 };
                dy = new int[] { 1, 1 };
            }
            for (var i = 0; i < 2; i++)
                if (InField(new Point(turn.From.X + dx[i], turn.From.Y + dy[i])))
                    if (field[turn.From.X + dx[i], turn.From.Y + dy[i]] == null &&
                        turn.From.X + dx[i] == turn.To.X && turn.From.Y + dy[i] == turn.To.Y)
                        return true;//ламповая проверка на возожность хода 
            
            dx = new int[] { 2, -2, 2, -2 };
            dy = new int[] { -2, -2, 2, 2 };
            /*
            for (var i = 0; i < 4; i++)
                if (InField(new Point(turn.From.X + dx[i], turn.From.Y + dy[i])))
                    if (field[turn.From.X + dx[i], turn.From.Y + dy[i]] == null)
                    {
                        var decr = GetDecreasedDim(dx[i], dy[i]);
                        if (field[turn.From.X + decr.X, turn.From.Y + decr.Y].Color != playerColor)//ламповая проверка на возможность атаки
                            return true;
                    }*/
            return false;
        }

        private bool IsQuennTurnCorrect(Checker[,] field, Color playerColor, Move turn)
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

        private Point GetDecreasedDim(int x, int y)
        {
            var dx = x > 0 ? x - 1 : x + 1;
            var dy = y > 0 ? y - 1 : y + 1;
            return new Point(dx, dy);
        }

        private void MakeMove(Checker[,] field, Move move)
        {

        }
    }
}
