﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class MoveInfo
    {
        public MoveInfo(Point from, Point to)
        {
            this.Field = Game.Field;
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
    }
}
