using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public static bool operator ==(Point a, Point b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public override bool Equals(object a)
        {
            return this == (Point)a;
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
