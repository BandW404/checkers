﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkers
{
    public class Program
    {
        public static Random Rand = new Random();
        [STAThread]
        public static void Main(string[] args)
        {
            //hello
            //Game.Begin();
            //for (var i = 0; i < 8; i++)
            //{
            //    for (var j = 0; j < 8; j++)
            //    {
            //        if (Game.Field[j, i] != null)
            //            Console.Write(Game.Field[j, i].Color + " ");
            //        else
            //            Console.Write("null  ");
            //    }
            //    Console.WriteLine();
            //}
            //var a = new Move(new Point(0, 1), new Point(2, 3));
            //var b = new Move(new Point(0, 1), new Point(2, 3));
            //var q = new List<Move>();
            //q.Add(a);
            //Console.Write(q.Contains(b));
            
            Application.Run(new MyForm(new Game().CreateMap()));
        }
    }
}
