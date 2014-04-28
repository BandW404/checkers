using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public interface IPlayer
    {
        Color Color //убрать свойство
        {
            get;
            set; //убрать сеттер
        }

        //void Initialize(Color color);

        List<Move> MakeTurn(Checker[,] field);
    }
}
