using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Tournament
{

    class MyRemotePlayer : IPlayer
    {
        Process process;

        public MyRemotePlayer()
        {
            //поднимаете два Checkers.Runner вот так:
            process = new Process();
            process.StartInfo.FileName = "Checkers.Runner.exe"; //в референсы его!
         //   process.StartInfo.Arguments = args[0];
            process.StartInfo.UseShellExecute = false; //а может true
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.StartInfo.CreateNoWindow = true;
            process.Start();

         
        }



        public Color Color
        {
            get { throw new NotImplementedException(); }
        }

        public List<Move> MakeTurn(Checker[,] field)
        {

            process.StandardInput.WriteLine("anything");
            process.StandardOutput.ReadLine();
            return null; //на самом деле возвращаете то что пришло из процесса
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // JavascriptSerializer - преобразует че угодно в JSON 

            //и м.б. отрисовка?

        }
    }
}