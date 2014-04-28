using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Threading;

namespace Checkers.Tournament
{

    class MyRemotePlayer
    {
        Process process;

        public MyRemotePlayer(string dllName, Color color)
        {
            //поднимаете два Checkers.Runner вот так:
            process = new Process();
            process.StartInfo.FileName = "Checkers.Runner.exe"; //в референсы его!
            process.StartInfo.Arguments = dllName + " " + color.ToString();
            process.StartInfo.UseShellExecute = false; //а может true
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true; // nado true, just for test bljad
            process.Start();

        }

        public List<Move> MakeTurn(Checker[,] field)
        {
            var fieldInString = Serializer.FieldToString(field);
            process.StandardInput.WriteLine(fieldInString); //  строка филд
            var movesInString = process.StandardOutput.ReadLine();
            if (movesInString == null)
                throw new Exception("nulla");
            return Serializer.StringToMoves(movesInString); // тут плеер сходил и вернул нам поле.
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



            //var moves = new List<Move>();
            //moves.Add(new Move(new Point(0, 0), new Point(1, 1)));
            //moves.Add(new Move(new Point(1, 1), new Point(0, 0)));
            //var str = Serializer.MovesToString(moves);
            //Console.WriteLine(str);
            //var mvs = Serializer.StringToMoves(str);
            //if (mvs.Count != moves.Count)
            //    throw new Exception("jopa");
            //if (mvs[0] == mvs[1])
            //    throw new Exception("???");
            //for (var i = 0; i < mvs.Count; i++)
            //    if (moves[i] != mvs[i])
            //            throw new Exception(i.ToString());


            //var field = new Game().CreateMap();
            //var str = Serializer.FieldToString(field);
            //Console.WriteLine(str);
            //var back = Serializer.StringToField(str);
            //for (var i = 0; i < 8; i++)
            //    for (var j = 0; j < 8; j++)
            //        if (field[i, j] != back[i, j] || field.Length != back.Length)
            //            throw new Exception((i + j).ToString());
            // JavascriptSerializer - преобразует че угодно в JSON 

            //и м.б. отрисовка?

        }
    }
}