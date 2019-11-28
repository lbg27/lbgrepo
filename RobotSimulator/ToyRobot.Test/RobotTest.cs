using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Surface;

namespace ToyRobot.Test
{
    [TestClass]
    public class RobotTest
    {

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_WorkingArea()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var warea = mrobot.GetWorkingArea();
            Assert.AreEqual(warea.GetLength(), 5);
            Assert.AreEqual(warea.GetWidth(), 5);
        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_PLACE_verify_until_valid()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var result = mrobot.RobotCommand("MOVE");
            Assert.AreEqual(result, null);

            result = mrobot.RobotCommand("LEFT");
            Assert.AreEqual(result, null);

            result = mrobot.RobotCommand("RIGHT");
            Assert.AreEqual(result, null);

            result = mrobot.RobotCommand("MOVE");
            Assert.AreEqual(result, null);


            result = mrobot.RobotCommand("PLACE 1,1,SOUTH");
            var postion = new Position(1, 1, Direction.SOUTH);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("RIGHT");
            postion = new Position(1, 1, Direction.WEST);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);
        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_DIRECTION()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);


            var result = mrobot.RobotCommand("PLACE 5,5,SOUTH");
            var postion = new Position(5, 5, Direction.SOUTH);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("LEFT");
            postion = new Position(5, 5, Direction.EAST);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);


            result = mrobot.RobotCommand("LEFT");
            postion = new Position(5, 5, Direction.NORTH);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("LEFT");
            postion = new Position(5, 5, Direction.WEST);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);


            result = mrobot.RobotCommand("RIGHT");
            postion = new Position(5, 5, Direction.NORTH);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);


            result = mrobot.RobotCommand("RIGHT");
            postion = new Position(5, 5, Direction.EAST);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("RIGHT");
            postion = new Position(5, 5, Direction.SOUTH);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);
        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_PLACE_Valid()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);


            var result = mrobot.RobotCommand("MOVE");
            Assert.AreEqual(result, null);

            var postion = new Position(1, 2, Direction.SOUTH);
            result = mrobot.RobotCommand("PLACE 1,2,SOUTH");

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            var postion2 = new Position(1, 2, Direction.WEST); //position will changed to west

            result = mrobot.RobotCommand("RIGHT");
            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);
        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_PLACE_Valid_CALL_Again()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);


            var result = mrobot.RobotCommand("MOVE");
            Assert.AreEqual(result, null);

            var postion = new Position(1, 2, Direction.SOUTH);
            result = mrobot.RobotCommand("PLACE 1,2,SOUTH");

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            var postion2 = new Position(1, 2, Direction.WEST); //position will changed to west
            result = mrobot.RobotCommand("RIGHT");

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            postion = new Position(2, 2, Direction.SOUTH);
            result = mrobot.RobotCommand("PLACE 2,2,SOUTH");

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            postion2 = new Position(2, 2, Direction.WEST); //position will changed to SOUTH
            result = mrobot.RobotCommand("RIGHT");

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_PLACE_OUT_OF_AREA_xaxis()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var result = mrobot.RobotCommand("PLACE 10,2,SOUTH");
            Assert.AreEqual(result, null);

        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_PLACE_OUT_OF_AREA_yaxis()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var result = mrobot.RobotCommand("PLACE 2,10,SOUTH");
            Assert.AreEqual(result, null);

        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_PLACE_OUT_OF_AREA_both()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var result = mrobot.RobotCommand("PLACE 10,10,SOUTH");
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_MOVE_valid_area()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var postion = new Position(1, 5, Direction.SOUTH);
            var result = mrobot.RobotCommand("PLACE 1,5,SOUTH");
            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            var postion2 = new Position(1, 4, Direction.SOUTH);
            result = mrobot.RobotCommand("MOVE");

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            postion2 = new Position(1, 3, Direction.SOUTH);
            result = mrobot.RobotCommand("MOVE");

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            postion2 = new Position(1, 2, Direction.SOUTH);
            result = mrobot.RobotCommand("MOVE");

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_MOVE_LEFT_MOVE()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var postion = new Position(1, 5, Direction.SOUTH);
            var result = mrobot.RobotCommand("PLACE 1,5,SOUTH");

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            var postion2 = new Position(1, 4, Direction.SOUTH);
            result = mrobot.RobotCommand("MOVE");

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            result = mrobot.RobotCommand("LEFT");
            postion2 = new Position(1, 4, Direction.EAST);

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            result = mrobot.RobotCommand("MOVE");
            postion2 = new Position(2, 4, Direction.EAST);

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            result = mrobot.RobotCommand("MOVE");
            postion2 = new Position(3, 4, Direction.EAST);

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);
        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_MOVE_RIGHT_MOVE()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var postion = new Position(1, 5, Direction.SOUTH);
            var result = mrobot.RobotCommand("PLACE 1,5,SOUTH");

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("MOVE");
            var postion2 = new Position(1, 4, Direction.SOUTH);
            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            result = mrobot.RobotCommand("RIGHT");
            postion2 = new Position(1, 4, Direction.WEST);

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            result = mrobot.RobotCommand("MOVE");
            postion2 = new Position(0, 4, Direction.WEST);  //no changes in current position'

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);

            result = mrobot.RobotCommand("MOVE");
            postion2 = new Position(0, 4, Direction.WEST); //no changes in current position

            Assert.AreEqual(result.X, postion2.X);
            Assert.AreEqual(result.Y, postion2.Y);
            Assert.AreEqual(result.PointDirection, postion2.PointDirection);
        }

        [TestMethod]
        public void Call_SetPosition_VerifyCommand_MOVE_invalid()
        {
            IWorkingArea workingarea = new WorkingArea(5, 5); // 5 by 5
            Robot mrobot = new Robot(workingarea);

            var result = mrobot.RobotCommand("PLACE 5,5,NORTH");
            var postion = new Position(5, 5, Direction.NORTH);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("PLACE 1,20,NORTH");

            //robot must not move ignore place command stay on the current position
            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("MOVE");

            //robot must not move ignore place command stay on the current position
            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("RIGHT");
            postion = new Position(5, 5, Direction.EAST);

            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

            result = mrobot.RobotCommand("MOVE");

            //robot must not move ignore move command stay on the current position and direction
            Assert.AreEqual(result.X, postion.X);
            Assert.AreEqual(result.Y, postion.Y);
            Assert.AreEqual(result.PointDirection, postion.PointDirection);

        }
    }
}
