﻿using System;
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
            var possibleAttack = Bind(field, new Point(turn.From.X, turn.From.Y), playerColor);
            return possibleAttack.Contains(turn) || IsRightQueenMove(turn, field, playerColor);
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
            AddToHash(ans, AddBindingForQueens(field, playerColor));
            return ans;
        }

        public void AddToHash(HashSet<Move> source, HashSet<Move> other)
        {
            foreach (var e in other)
                source.Add(e);
        }

        private bool IsRightQueenMove(Move move, Checker[,] field, Color playerColor)
        {
            var dx = new int[] { 1, -1, 1, -1 };
            var dy = new int[] { -1, -1, 1, 1 };
            var x = move.From.X;
            var y = move.From.Y;
            for (var i = 0; i < 4; i++)
            {
                var enemyFound = false;
                for (var delta = 1; delta < 8; delta++)
                    if (!enemyFound)
                    if (InField(new Point(x + dx[i] * delta, y + dy[i] * delta)))
                    {
                        if (field[x + dx[i] * delta, y + dy[i] * delta] != null)
                        {
                            enemyFound = true;
                            continue;
                        }
                        if (move.To.X == x + dx[i] * delta && move.To.Y == y + dy[i] * delta)
                            return true;
                    }
            }
            return false;
        }

        private HashSet<Move> Bind(Checker[,] field, Point pos, Color playerColor)
        {
            var dx = new int[] { 1, -1, 1, -1 };
            var dy = new int[] { -1, -1, 1, 1 };
            var x = pos.X;
            var y = pos.Y;
            var ans = new HashSet<Move>();
            for (var i = 0; i < 4; i++)
            {
                var noEnemy = true;
                var enemyFound = false;
                for (var delta = 1; delta < 8; delta++)
                    if  (InField(new Point(x+dx[i]*delta, y+dy[i]*delta)))
                    { 
                        if (InField(new Point(x+dx[i]*(delta+1), y+dy[i]*(delta+1))))
                        {
                            if (field[x + dx[i] * delta, y + dy[i] * delta] != null
                                && field[x + dx[i] * (delta + 1), y + dy[i] * (delta + 1)] != null)
                            if (field[x + dx[i] * delta, y + dy[i] * delta].Color != playerColor
                                && field[x + dx[i] * (delta + 1), y + dy[i] * (delta + 1)].Color != playerColor)
                                noEnemy = false;
                        }
                        if (field[x+dx[i]*delta, y+dy[i]*delta] != null)
                            if ((field[x+dx[i]*delta, y+dy[i]*delta].Color != playerColor || enemyFound) && noEnemy
                                && field[x+dx[i]*(delta+1), y+dy[i]*(delta+1)] == null)
                            {
                                ans.Add(new Move(new Point(x,y), new Point(x+dx[i]*(delta+1), y+dy[i]*(delta+1))));
                                enemyFound = true;
                            }
                        if (enemyFound && field[x + dx[i] * delta, y + dy[i] * delta] == null)
                            ans.Add(new Move(new Point(x, y), new Point(x + dx[i] * (delta), y + dy[i] * (delta))));
                        }
            }
            return ans;
        }


        public HashSet<Move> AddBindingForQueens(Checker[,] field, Color color)
        {
            var ans = new HashSet<Move>();
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    if (field[i, j] != null && field[i, j].Color == color && field[i, j].IsQueen)
                        AddToHash(ans, Bind(field, new Point(i, j), color));
            return ans;
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
