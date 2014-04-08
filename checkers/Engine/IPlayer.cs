using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    interface IPlayer
    {
        Color color
        {
            get;
            set;
        }
        MoveInfo MakeTurn(MoveInfo moveInfo);
    }
}
