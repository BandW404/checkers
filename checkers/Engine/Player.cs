using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class Player : IPlayer
    {
        public Player(Color color)
        {
            this.Color = color;
        }
        public Color Color
        {
            get;
            private set;
        }

        public List<Move> MakeTurn(MoveInfo moveInfo)
        {
            throw new NotImplementedException();
        }
    }
}
