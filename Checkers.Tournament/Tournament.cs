using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace Checkers.Tournament
{
    class MyRemotePlayer
    {
        Process process;
        public MyRemotePlayer(string dllName, Color color)
        {
            process = new Process();
            process.StartInfo.FileName = "Checkers.Runner.exe";
            process.StartInfo.Arguments = dllName + " " + color.ToString();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = false;
            process.Start();
        }

        public List<Move> MakeTurn(Checker[,] field)
        {
            var fieldInString = Serializer.FieldToString(field);
            process.StandardInput.WriteLine(fieldInString);
            var movesInString = process.StandardOutput.ReadLine();
            if (movesInString == "White LOSE" || movesInString == "Black LOSE")
            {
                Console.WriteLine(movesInString);
                Environment.Exit(0);
            }
            return Serializer.StringToMoves(movesInString);
        }
    }


    public class Program
    {
        public static string firstPlayerFile;
        public static string secondPlayerFile;
        public static Form1 Window = new Form1();
        [STAThread]
        static void Main(string[] args)
        {
            firstPlayerFile = args[0];
            secondPlayerFile = args[1];
            var thread = new Thread(Gaming);
            thread.Start();
            Application.Run(Window);
        }
        static void Gaming()
        {
            var white = new MyRemotePlayer(firstPlayerFile, Color.White);
            var black = new MyRemotePlayer(secondPlayerFile, Color.Black);
            var validator = new Validator();
            var field = new Game().CreateMap();
            while (true)
            {
                validator.IsCorrectMove(white.MakeTurn(field), field, Color.White);
                Window.BeginInvoke(new Action<Checker[,]>(Window.Update), new object[] { field });
                Thread.Sleep(500);
                validator.IsCorrectMove(black.MakeTurn(field), field, Color.Black);
                Window.BeginInvoke(new Action<Checker[,]>(Window.Update), new object[] { field });
                Thread.Sleep(500);
            }
        }
    }
}