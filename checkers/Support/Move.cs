using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class Move
    {
        public Move(Point from, Point to)
        {
            this.From = from;
            this.To = to;
        }
        public Point From
        {
            get;
            set;
        }
        public Point To
        {
            get;
            set;
        }
    }
}
