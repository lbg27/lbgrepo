using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Surface;

namespace ToyRobot.Test
{
    [TestClass]
    public class CommandProcessorTest
    {

        [TestMethod]
        public void Call_ParseRequest_Verify_Command()
        {
            CommandProcessor comprocessor = new CommandProcessor();

            var postion = new Position(1, 1, Direction.SOUTH);

            var resultpos = comprocessor.ParseRequest("PLACE 1,1,SOUTH");
            var result = resultpos.Location;

            Assert.AreEqual(resultpos.CurrentCommand, Command.PLACE);
            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            postion = new Position(2, 1, Direction.NORTH);
            resultpos = comprocessor.ParseRequest("PLACE 2,1,NORTH");
            result = resultpos.Location;

            Assert.AreEqual(resultpos.CurrentCommand, Command.PLACE);
            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            resultpos = comprocessor.ParseRequest("MOVE");
            Assert.AreEqual(resultpos.CurrentCommand, Command.MOVE);

            resultpos = comprocessor.ParseRequest("LEFT");
            Assert.AreEqual(resultpos.CurrentCommand, Command.LEFT);

            resultpos = comprocessor.ParseRequest("RIGHT");
            Assert.AreEqual(resultpos.CurrentCommand, Command.RIGHT);

            resultpos = comprocessor.ParseRequest("REPORT");
            Assert.AreEqual(resultpos.CurrentCommand, Command.REPORT);

        }

 

    }
}
