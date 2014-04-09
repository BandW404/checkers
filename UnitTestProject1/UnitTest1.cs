using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace checkers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MustAttack()
        {
            //var validator = new Validator(); test
            var field = new Checker[8, 8];
            field[2, 2] = new Checker(Color.White, false);
            field[3, 3] = new Checker(Color.Black, false);
            //var moveInfo = new MoveInfo(new Point(2, 2), new Point(
            //validator.IsCorrectMove(MoveInfo moveInfo, Color playerColor)
        }
    }
}
