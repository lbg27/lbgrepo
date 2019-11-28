using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Surface;

namespace ToyRobot.Test
{
    [TestClass]
    public class PositionTest
    {

        [TestMethod]
        public void Call_SetPosition_VerifyPosition()
        {
            var resultpos = Position.SetPosition(new Position(1, 1, Direction.SOUTH));
            var postion = new Position(1, 0, Direction.SOUTH);

            Assert.AreEqual(resultpos.X, postion.X);
            Assert.AreEqual(resultpos.Y, postion.Y);
            Assert.AreEqual(resultpos.PointDirection, postion.PointDirection);

            resultpos = Position.SetPosition(new Position(3, 3, Direction.NORTH));
            postion = new Position(3, 4, Direction.NORTH);

            Assert.AreEqual(resultpos.X, postion.X);
            Assert.AreEqual(resultpos.Y, postion.Y);
            Assert.AreEqual(resultpos.PointDirection, postion.PointDirection);

            resultpos = Position.SetPosition(new Position(3, 3, Direction.EAST));
            postion = new Position(4, 3, Direction.EAST);

            Assert.AreEqual(resultpos.X, postion.X);
            Assert.AreEqual(resultpos.Y, postion.Y);
            Assert.AreEqual(resultpos.PointDirection, postion.PointDirection);

            resultpos = Position.SetPosition(new Position(3, 3, Direction.WEST));
            postion = new Position(2, 3, Direction.WEST);

            Assert.AreEqual(resultpos.X, postion.X);
            Assert.AreEqual(resultpos.Y, postion.Y);
            Assert.AreEqual(resultpos.PointDirection, postion.PointDirection);

        }

        [TestMethod]
        public void Call_SetDirectionToLeft_Verify_Direction()
        {
            var resultpos = Position.SetDirectionToLeft(Direction.SOUTH);
            Assert.AreEqual(resultpos, Direction.EAST);

            resultpos = Position.SetDirectionToLeft(Direction.EAST);
            Assert.AreEqual(resultpos, Direction.NORTH);

            resultpos = Position.SetDirectionToLeft(Direction.NORTH);
            Assert.AreEqual(resultpos, Direction.WEST);

            resultpos = Position.SetDirectionToLeft(Direction.WEST);
            Assert.AreEqual(resultpos, Direction.SOUTH);

        }

        [TestMethod]
        public void Call_SetDirectionToRight_Verify_Direction()
        {
            var resultpos = Position.SetDirectionToRight(Direction.SOUTH);
            Assert.AreEqual(resultpos, Direction.WEST);

            resultpos = Position.SetDirectionToRight(Direction.EAST);
            Assert.AreEqual(resultpos, Direction.SOUTH);

            resultpos = Position.SetDirectionToRight(Direction.NORTH);
            Assert.AreEqual(resultpos, Direction.EAST);

            resultpos = Position.SetDirectionToRight(Direction.WEST);
            Assert.AreEqual(resultpos, Direction.NORTH);

        }


    }
}
