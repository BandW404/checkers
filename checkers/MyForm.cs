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
        Bitmap bitmapBlack;
        Bitmap bitmapWhite;
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
            timer.Interval = 3000;
            DoubleBuffered = true;
            Text = "Checkers";
            timer.Tick += TimerTick;
            timer.Start();
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
                        e.Graphics.FillEllipse(
                            field[i, j].Color == Color.White ? Brushes.White : Brushes.Black, i * ElementSize + 5, j * ElementSize + 5, ElementSize - 10, ElementSize - 10);
                            //i * ElementSize,
                            //j * ElementSize,
                            //(i + 1) * ElementSize,
                            //(j + 1) * ElementSize);
                }

        }

        void TimerTick(object sender, EventArgs args)
        {
            if (Keyboard.IsKeyDown(Key.Space))
            {
                var moves = new List<Move>();
                moves.Add(new Move(new Point(0, 5), new Point(1, 4)));
                validator.IsCorrectMove(moves, field, Color.White);
                
            }
            Invalidate();
        }
    }
}
