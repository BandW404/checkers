using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public enum Color {Black, White};
    public class Checker
    {
        public Checker(Color color, bool isQueen)
        {
            this.Color = color;
            this.IsQueen = isQueen;
        }
        public bool IsQueen
        {
            get;
            private set;
        }
        public Color Color
        {
            get;
            private set;
        }
    }
}
