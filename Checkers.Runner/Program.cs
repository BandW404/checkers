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
                .Where(z => z.GetInterfaces().Any(x => x.ToString() == typeof(IPlayer).ToString()))
                .FirstOrDefault();
            //var ctor = player
            //    .GetConstructor(new Type[] { typeof(Color) });
            var ctor = player.GetConstructors().FirstOrDefault();
            var playerObject = ctor
                .Invoke(new object[] { color }) as IPlayer;
            if (playerObject == null)
                throw new Exception("lol");
            //Console.WriteLine(playerObject.MakeTurn(new Game().CreateMap()).Count);
            
            //var moves = playerObject.MakeTurn( (Checker[,])serializer.Deserialize(Console.ReadLine(), typeof(Checker[,])) );
            //Console.WriteLine(serializer.Serialize(moves));

            //
            // 1. Поднимаете IPlayer (одного) с помощью рефлексии

            // в вечном цикле читаете из консоли карту шашечного поля, кормите ее игроку, а результат пишете в консоль

        }
    }
}
