using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class MoveInfo
    {
        public MoveInfo()
        {
            this.Field = Game.Field;
            Moves = new List<Move>();
        }
        public List<Move> Moves
        {
            get;
            set;
        }
        public Checker[,] Field
        {
            get;
            private set;
        }
        //принимаем мувинфо возвращаем лист(мув)
    }
}
