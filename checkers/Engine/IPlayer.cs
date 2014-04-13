using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public interface IPlayer
    {
        Color Color
        {
            get;
        }
        List<Move> MakeTurn(Checker[,] field);
    }
}
