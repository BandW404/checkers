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
        public static bool operator ==(Move a, Move b)
        {
            return a.From == b.From && a.To == b.To;
        }
        public override bool Equals(object a)
        {
            return this == (Move)a;
        }
        public static bool operator !=(Move a, Move b)
        {
            return !(a==b);
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
