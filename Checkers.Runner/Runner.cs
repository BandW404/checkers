using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Checkers.Runner
{
    class Program
    {
        static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom(args[0]);
            Color color;
            if (args[1] == "White")
                color = Color.White;
            else
                color = Color.Black;
            var player = assembly
                .GetTypes()
                .Where(z => z.GetInterfaces().Any(x => x == typeof(IPlayer)))
                .FirstOrDefault();
            var ctor = player
                .GetConstructor(new Type[] { });
            //var ctor = player.GetConstructors().FirstOrDefault();
            var playerObject = ctor
                .Invoke(new object[] { }) as IPlayer;
            playerObject.Initialize(color);
            //Console.WriteLine(playerObject.MakeTurn(new Game().CreateMap()).Count);
            while (true)
            {
                var str = Console.ReadLine();
                throw new Exception(str);
                var field = Serializer.StringToField(str);
                var moves = playerObject.MakeTurn(field);
                if (moves == null || moves.Count == 0)
                    throw new Exception(" game over ?");
                var answer = Serializer.MovesToString(moves);
                if (answer == null || answer == "")
                    throw new Exception("qqq");
                Console.WriteLine(answer);
            }

            //
            // 1. Поднимаете IPlayer (одного) с помощью рефлексии

            // в вечном цикле читаете из консоли карту шашечного поля, кормите ее игроку, а результат пишете в консоль

        }
    }
}
