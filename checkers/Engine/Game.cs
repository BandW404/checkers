using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    static class LinqExtention
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var e in list)
                action(e);
        }
    }

    public class Game
    {
        Checker[,] field;
        IPlayer whitePlayer;
        IPlayer blackPlayer;
        Validator validator;

        public Checker[,] CreateMap()
        {
            field = new Checker[8,8];
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 3; j++)
                    if (j == 1)
                    {
                        field[i * 2 + 1, 7 - j] = new Checker(Color.White, false);
                        field[i * 2, j] = new Checker(Color.Black, false);
                    }
                    else
                    {
                        field[i * 2, 7 - j] = new Checker(Color.White, false);
                        field[i * 2 + 1, j] = new Checker(Color.Black, false);
                    }
            return field;
        }
        public void StartGame()
        {
            validator = new Validator();
            whitePlayer = new Player(Color.White);
            blackPlayer = new Player(Color.Black);
            List<Move> listOfMoves;
            while (true)
            {
                listOfMoves = whitePlayer.MakeTurn(field);
                validator.IsCorrectMove(listOfMoves, field, Color.White);
                listOfMoves = blackPlayer.MakeTurn(field);
                validator.IsCorrectMove(listOfMoves, field, Color.Black);
            }
        }
        public static void GameOver(Color winner)
        {
            Console.WriteLine(winner.ToString() + " WINS!!!");
            Environment.Exit(0);
        }
    }
}
