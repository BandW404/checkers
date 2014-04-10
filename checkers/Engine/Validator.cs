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
            if (field[turn.From.X, turn.From.Y].Color != playerColor)
                return false;
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
            for (var i = 0; i < 4; i++)
                if (InField(new Point(turn.From.X + dx[i], turn.From.Y + dy[i])))
                    if (field[turn.From.X + dx[i], turn.From.Y + dy[i]] == null)
                    {
                        var decr = GetNextFreePlace(dx[i], dy[i]);
                        if (field[turn.From.X + decr.X, turn.From.Y + decr.Y] != null &&
                            field[turn.From.X + decr.X, turn.From.Y + decr.Y].Color != playerColor)//ламповая проверка на возможность атаки
                            return true;
                    }
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
            AddBindingForQueens(field, ans, playerColor);
            return ans;
        }

        public void AddBindingForQueens(Checker[,] field, HashSet<Move> moves, Color playerColor)
        {
            var dx = new int[] { 1, -1, 1, -1 };
            var dy = new int[] { -1, -1, 1, 1 };
            for (var x = 0; x < 8; x++)
                for (var y = 0; y < 8; y++)
                    if (field[x,y] != null && field[x,y].IsQueen && field[x,y].Color == playerColor)
                    {
                        for (var delta = 1; delta < 8; delta++)
                            for (var i = 0; i < 4; i++)
                                if(InField(new Point(x + dx[i]*delta, y + dy[i]*delta)))
                                    if (field[x + dx[i]*delta, y + dy[i]*delta] != null)
                                        if(field[x + dx[i]*delta, y + dy[i]*delta].Color != playerColor)
                                        {
                                            var from = new Point(x,y);
                                            var to = new Point(x + dx[i]*delta, y + dy[i]*delta);
                                            var move = new Move(from, to);
                                            AddToHashset(moves, dx[i], dy[i], move, field);
                                        }
                    }

        }

        private void AddToHashset (HashSet<Move> moves, int dx, int dy, Move enemy, Checker[,] field)
        {
            var x = enemy.To.X;
            var y = enemy.To.Y;
            do
            {
                x += dx;
                y += dy;
                if (InField(new Point(x, y)))
                    if (field[x, y] == null)
                    moves.Add(new Move(new Point(enemy.From.X, enemy.From.Y), new Point(x, y)));
            }
            while (InField(new Point(x, y)));
        }

        private Point GetNextFreePlace(int x, int y)
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
