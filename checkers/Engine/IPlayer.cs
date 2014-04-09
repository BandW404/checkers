using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public interface IPlayer
    {
        Color Color
        {
            get;
        }
        MoveInfo MakeTurn(MoveInfo moveInfo);
    }
}
