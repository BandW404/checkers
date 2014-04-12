using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace checkers
{
    public class MyForm : Form
    {
        Timer timer;
        const int ElementSize = 64;
        List<Move> moves;
        Player white = new Player(Color.White);
        Player black = new Player(Color.Black);
        int tickCount;
        Checker[,] field;
        Validator validator;
        

        public MyForm(Checker[,] field)
        {
            this.field = field;
            validator = new Validator();
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(ElementSize * 8, ElementSize * 8);
            timer = new Timer();
            timer.Interval = 300;
            DoubleBuffered = true;
            Text = "Checkers";
            timer.Tick += TimerTick;
            timer.Start();
            tickCount = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    e.Graphics.FillRectangle(
                        (i + j) % 2 != 0 ? Brushes.Gray : Brushes.Wheat,
                        i * ElementSize,
                        j * ElementSize,
                        (i + 1) * ElementSize,
                        (j + 1) * ElementSize);
                    if (field[i, j] != null)
                    {
                        e.Graphics.FillEllipse(
                            field[i, j].Color == Color.White ? Brushes.White : Brushes.Black,
                            i * ElementSize + 5,
                            j * ElementSize + 5,
                            ElementSize - 10,
                            ElementSize - 10);
                        if (field[i, j].IsQueen)
                            e.Graphics.FillEllipse(
                            Brushes.Gold,
                            i * ElementSize + 20,
                            j * ElementSize + 20,
                            ElementSize - 40,
                            ElementSize - 40);
                    }

                }

        }

        void TimerTick(object sender, EventArgs args)
        {
            if (Keyboard.IsKeyDown(Key.Space))
                if (tickCount % 2 == 0)
                {
                    moves = white.MakeTurn(new MoveInfo(field));
                    validator.IsCorrectMove(moves, field, Color.White);
                }
                else
                {
                    moves = black.MakeTurn(new MoveInfo(field));
                    validator.IsCorrectMove(moves, field, Color.Black);
                }
                tickCount++;
            Invalidate();
        }
    }
}
