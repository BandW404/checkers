using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkers
{
    public class Player : IPlayer
    {
        public Player(Color color)
        {
            this.Color = color;
        }
        public Color Color
        {
            get;
            private set;
        }

        public List<Move> MakeTurn(Checker[,] field)
        {
            Func<Point, bool> InField = (point => point.X < 8 && point.X >= 0 && point.Y < 8 && point.Y >= 0);
            var answer = new List<Move>();
            var valid = new Validator();
            var way = (Color == Color.White)?-1:1;
            var listOfMyCheckersWhoCanMove = new List<Move>();
            var bindingMoves = valid.GetBindingMoves(field, Color);
            if (bindingMoves.Count > 0) //ходим сначала рандомной фигурой из списка, затем ищем возможные ходы  дальше и ходим. иначе конец хода.
            {
                answer.Add(bindingMoves.ToArray()[Program.Rand.Next(0, bindingMoves.Count)]);
                var point = answer[0].To;
                while (true)
                    for (var di = -1; di < 2; di += 2)
                        for (var dj = -1; dj < 2; dj += 2)
                        {
                            var from = new Point(point.X, point.Y);
                            var enemy = new Point(point.X + di, point.Y + dj);
                            var free = new Point(point.X + di * 2, point.Y + dj * 2);
                            var move = new Move(from, free);
                            if (InField(enemy) &&
                                field[enemy.X, enemy.Y] != null &&
                                field[enemy.X, enemy.Y].Color != Color &&
                                InField(free) &&
                                field[free.X, free.Y] == null &&
                                !answer.Contains(move))
                                answer.Add(new Move(from, free));
                            else
                                return answer;
                        }
            }
            for (var i = 0; i < 8; i++) // составляем список всех возможных фигур, которые могут ходить
                for (var j = 0; j < 8; j++)
                    if (field[i, j] != null && field[i, j].Color == Color)
                    {
                        if (InField(new Point(i + 1, j + way)) && field[i + 1, j + way] == null)
                            listOfMyCheckersWhoCanMove.Add(new Move(new Point(i, j), new Point(i + 1, j + way)));
                        if (InField(new Point(i - 1, j + way)) && field[i - 1, j + way] == null)
                            listOfMyCheckersWhoCanMove.Add(new Move(new Point(i, j), new Point(i - 1, j + way)));
                    }
            if (listOfMyCheckersWhoCanMove.Count > 0) //если в этом списке что-то есть -- добавляем рандомный эл-т и заканчиваем ход
            {
                var rand = Program.Rand.Next(0, listOfMyCheckersWhoCanMove.Count);
                var move = listOfMyCheckersWhoCanMove[rand];
                answer.Add(move);
                return answer;
            }
            MessageBox.Show(Color.ToString() + " lose");
            Environment.Exit(0);
            return null;
        }
    }
}
