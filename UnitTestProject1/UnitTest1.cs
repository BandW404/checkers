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
            var a = field[3, 3].Color == Color.White;
            var b = field[2, 2].Color == Color.Black;
            var c = field[4, 4] == null;
            Assert.AreEqual(a && b && c, true);
        }
        void Test(List<Move> moves, Color color, bool answer, string mapname)
        {
            var validator = new Validator();
            var field = GetMapFrom(mapname);
            if (!answer)
                try 
                { 
                    validator.IsCorrectMove(moves, field, color); 
                    Assert.Fail(); 
                }
                catch (NotImplementedException e) { }
            else
                validator.IsCorrectMove(moves, field, color);

        }
        [TestMethod]
        public void MustAttackBlackFalse()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(2, 2), new Point(1, 3)));
            Test(moves, Color.Black, false, "Tests1.txt");
        }
        [TestMethod]
        public void MustAttackBlackTrue()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(2, 2), new Point(4, 4)));
            Test(moves, Color.Black, true, "Tests1.txt");
        }
        [TestMethod]
        public void MustAttackWhiteTrue()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(3, 3), new Point(1, 1)));
            Test(moves, Color.White, true, "Tests1.txt");
        }
        [TestMethod]
        public void MoveNotYourOwn() //пробую сходить не своей фигурой
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(3, 3), new Point(1, 1)));
            Test(moves, Color.Black, false, "Tests1.txt");
        }
        [TestMethod]
        public void QueenMustAttackWhiteTrue() //пробую верно срубить королевой
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(1, 1), new Point(7, 7)));
            Test(moves, Color.White, true, "Tests2.txt");
        }
        [TestMethod]
        public void QueenMustAttackBlackTrue()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(6, 6), new Point(0, 0)));
            Test(moves, Color.Black, true, "Tests2.txt");
        }
        [TestMethod]
        public void QueenMustAttackWhiteFalse()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(1, 1), new Point(4, 4)));
            Test(moves, Color.White, false, "Tests2.txt");
        }
        [TestMethod]
        public void QueenMustAttackBlackFalse()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(6, 6), new Point(5, 7)));
            Test(moves, Color.Black, false, "Tests2.txt");
        }
        [TestMethod] //?
        public void NormalMoveWhite()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(6, 6), new Point(5, 5)));
            Test(moves, Color.White, true, "Tests3.txt");
        }
        [TestMethod]
        public void NormalMoveBlack()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(1, 1), new Point(0, 2)));
            Test(moves, Color.Black, true, "Tests3.txt");
        }
        [TestMethod]
        public void MoveBackBlackFalse()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(1, 1), new Point(0, 0)));
            Test(moves, Color.Black, false, "Tests3.txt");
        }
        [TestMethod]
        public void MoveBackWhiteFalse()
        {
            var moves = new List<Move>();
            moves.Add(new Move(new Point(6, 6), new Point(5, 7)));
            Test(moves, Color.White, false, "Tests3.txt");
        }
    }
}
