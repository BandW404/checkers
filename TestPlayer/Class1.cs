using Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlayer
{
    public class Class1 : IPlayer
    {
        public Color Color
        {
            get { throw new NotImplementedException(); }
        }

        public List<Move> MakeTurn(Checker[,] field)
        {
            throw new NotImplementedException();
        }
    }
}
