using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Surface;

namespace ToyRobot.Test
{
    [TestClass]
    public class WorkingAreaTest
    {

        [TestMethod]
        public void Call_IsValidMove_Verify_position()
        {
            WorkingArea workingarea = new WorkingArea(10,10);

            var postion = new Position(11, 11, Direction.SOUTH);
            var result = workingarea.IsValidMove(postion);
            var currentpostion = workingarea.GetCurrentPosition();

            Assert.AreEqual(result, false);
            Assert.AreEqual(currentpostion, null);

            postion = new Position(1, 2, Direction.NORTH);
            result = workingarea.IsValidMove(postion);
            currentpostion = workingarea.GetCurrentPosition();

            Assert.AreEqual(result, true);
            Assert.AreEqual(currentpostion.X, postion.X);
            Assert.AreEqual(currentpostion.Y, postion.Y);
            Assert.AreEqual(currentpostion.PointDirection, postion.PointDirection);

            var postion2 = new Position(10, 20, Direction.NORTH);
            result = workingarea.IsValidMove(postion2);
            currentpostion = workingarea.GetCurrentPosition();

            //position should not changed stay on current position
            Assert.AreEqual(result, false);
            Assert.AreEqual(currentpostion.X, postion.X);
            Assert.AreEqual(currentpostion.Y, postion.Y);
            Assert.AreEqual(currentpostion.PointDirection, postion.PointDirection);


        }



    }
}
