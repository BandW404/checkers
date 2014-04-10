using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace checkers
{
    [TestClass]
    public class UnitTest1
    {
        Checker[,] GetMapFrom(string filename)
        {
            var map = new Checker[8, 8];
            var file = File.ReadAllLines("Maps\\" + filename);
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    switch (file[i][j])
                    {
                        case '1':
                            map[j, i] = new Checker(Color.White, false);
                            break;
                        case '2':
                            map[j, i] = new Checker(Color.Black, false);
                            break;
                        case '3':
                            map[j, i] = new Checker(Color.White, true);
                            break;
                        case '4':
                            map[j, i] = new Checker(Color.Black, true);
                            break;
                        default:
                            break;
                    }
            return map;
        }
        [TestMethod]
        public void CheckCorrectMap()
        {
            var field = GetMapFrom("Tests1.txt");
            var a = field[2, 2].Color == Color.White;
            var b = field[3, 3].Color == Color.Black;
            var c = field[4, 4] == null;
            Assert.AreEqual(a && b && c, true);
        }
        void TwoSimpleCheckersTest(List<Move> moves, Color color, bool answer)
        {
            var validator = new Validator();
            var field = GetMapFrom("Tests1.txt");
            Assert.AreEqual(validator.IsCorrectMove(moves, field, color), answer);
        }
        [TestMethod]
        public void MustAttackBlackFalse()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(2, 2), new Point(1, 3)));
            TwoSimpleCheckersTest(moves, Color.Black, false);
        }
        [TestMethod]
        public void MustAttackBlackTrue()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(2, 2), new Point(4, 4)));
            TwoSimpleCheckersTest(moves, Color.Black, true);
        }
        [TestMethod]
        public void MustAttackWhiteTrue()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(3, 3), new Point(1, 1)));
            TwoSimpleCheckersTest(moves, Color.White, true);
        }
        [TestMethod]
        public void MoveNotYourOwn()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(3, 3), new Point(1, 1)));
            TwoSimpleCheckersTest(moves, Color.Black, false);
        }
    }
}
