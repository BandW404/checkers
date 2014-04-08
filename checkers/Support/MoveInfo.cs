using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class MoveInfo
    {
        public MoveInfo(Point from, Point to)
        {
            this.From = from;
            this.To = to;
            this.Field = Game.Field;
        }
        public Checker[,] Field
        {
            get;
            private set;
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
