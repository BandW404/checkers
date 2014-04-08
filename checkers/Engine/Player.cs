using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    class Player : IPlayer
    {
        public Color color
        {
            get;
            private set;
        }

        public MoveInfo MakeTurn(MoveInfo moveInfo)
        {
            throw new NotImplementedException();
        }
    }
}
