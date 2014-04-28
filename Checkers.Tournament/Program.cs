using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Checkers.Tournament
{

    class MyRemotePlayer : IPlayer
    {
        Process process;
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        public MyRemotePlayer(string dllName, Color color)
        {
            //поднимаете два Checkers.Runner вот так:
            Color = color;
            process = new Process();
            process.StartInfo.FileName = "Checkers.Runner.exe"; //в референсы его!
            process.StartInfo.Arguments = dllName + " " + color.ToString();
            process.StartInfo.UseShellExecute = false; //а может true
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = false; // nado true, just for test bljad
            process.Start();

        }



        public Color Color
        {
            get;
            set;
        }

        public List<Move> MakeTurn(Checker[,] field)
        {
            process.StandardInput.WriteLine(serializer.Serialize(field)); // вместо эни строка филд
            
            return (List<Move>)serializer.Deserialize(process.StandardOutput.ReadLine(), typeof(List<Move>)); // тут плеер сходил и вернул нам поле.
            //return null; //на самом деле возвращаете то что пришло из процесса
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var white = new MyRemotePlayer(args[0], Color.White);
            var black = new MyRemotePlayer(args[1], Color.Black);
            var validator = new Validator();
            var field = new Game().CreateMap();
            while (true)
            {
                validator.IsCorrectMove(white.MakeTurn(field), field, Color.White);
                validator.IsCorrectMove(black.MakeTurn(field), field, Color.Black);
            }
            // JavascriptSerializer - преобразует че угодно в JSON 

            //и м.б. отрисовка?

        }
    }
}