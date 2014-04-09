using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace checkers
{
    [TestClass]
    public class UnitTest1
    {
        void TwoSimpleCheckersTest(MoveInfo moveInfo, Color color, bool answer)
        {
            var validator = new Validator();
            Game.field = new Checker[8, 8];
            Game.field[2, 2] = new Checker(Color.Black, false);
            Game.field[3, 3] = new Checker(Color.White, false);
            Assert.AreEqual(validator.IsCorrectMove(moveInfo, color), answer);
        }
        [TestMethod]
        public void MustAttackBlackFalse()
        {
            var moveInfo = new MoveInfo();
            moveInfo.Moves.Add(new Move(new Point(2, 2), new Point(1, 3)));
            TwoSimpleCheckersTest(moveInfo, Color.Black, false);
        }
        [TestMethod]
        public void MustAttackBlackTrue()
        {
            var moveInfo = new MoveInfo();
            moveInfo.Moves.Add(new Move(new Point(2, 2), new Point(4, 4)));
            TwoSimpleCheckersTest(moveInfo, Color.Black, true);
        }
        public void MustAttackWhiteTrue()
        {
            var moveInfo = new MoveInfo();
            moveInfo.Moves.Add(new Move(new Point(3, 3), new Point(1, 1)));
            TwoSimpleCheckersTest(moveInfo, Color.White, true);
        }
        public void MoveNotYourOwn()
        {
            var moveInfo = new MoveInfo();
            moveInfo.Moves.Add(new Move(new Point(3, 3), new Point(1, 1)));
            TwoSimpleCheckersTest(moveInfo, Color.Black, false);
        }
    }
}
