using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    static class LinqExtention
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var e in list)
                action(e);
        }
    }

    public static class Game
    {
        public static Checker[,] Field;


        public static void Begin()
        {
            Field = new Checker[8, 8];
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 3; j++)
                    if (j == 1)
                    {
                        Field[i * 2 + 1, 7 - j] = new Checker(Color.White, false);
                        Field[i * 2, j] = new Checker(Color.Black, false);
                    }
                    else
                    {
                        Field[i * 2, 7 - j] = new Checker(Color.White, false);
                        Field[i * 2 + 1, j] = new Checker(Color.Black, false);
                    }
        }
    }
}
