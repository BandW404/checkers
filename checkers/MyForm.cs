using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkers
{
    public class MyForm : Form
    {
        Timer timer;
        const int ElementSize = 64;
        Bitmap bitmapBlack;
        Bitmap bitmapWhite;
        int tickCount;

        public MyForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(ElementSize * 8, ElementSize * 8);
        }
    }
}
