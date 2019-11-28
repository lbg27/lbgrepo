using System;
using System.Linq;
using ToyRobot.Surface;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        private IWorkingArea _workingArea;
         private CommandProcessor _processCommand;
        private string _reportmessage = "";

        public Robot(IWorkingArea workingArea)
        {
            _workingArea = workingArea;
            _processCommand = new CommandProcessor();
        }

        public string DisplayReport()
        {
            return _reportmessage;
        }

        public IWorkingArea GetWorkingArea()
        {
            return _workingArea;
        }

        public IPosition RobotCommand(string command)
        {
            _reportmessage = "";
            CommandProcessor currentcommant =  _processCommand.ParseRequest(command);

            if(currentcommant != null)
            {
                var pos = _workingArea.GetCurrentPosition();
                if (pos == null && currentcommant.CurrentCommand != Command.PLACE)
                    return pos;

                switch (currentcommant.CurrentCommand)
                {
                    case Command.PLACE:
                        _workingArea.IsValidMove(currentcommant.Location);
                        break;
                    case Command.MOVE:
                        _workingArea.IsValidMove(Position.SetPosition(pos));
                        break;
                    case Command.LEFT:
                        pos.PointDirection = Position.SetDirectionToLeft(pos.PointDirection);
                        _workingArea.IsValidMove(pos);
                        break;
                    case Command.RIGHT:
                        pos.PointDirection = Position.SetDirectionToRight(pos.PointDirection);
                        _workingArea.IsValidMove(pos);
                        break;
                    case Command.REPORT:
                        if (pos.PointDirection == null)
                            return null;
                        string mreport = "Output: " + pos.X + "," + pos.Y + "," + Enum.GetName(typeof(Direction), (Direction)pos.PointDirection);
                        _workingArea.GetCurrentPositionReport(mreport);
                        _reportmessage = mreport;
                        break;
                }
            }

            return _workingArea.GetCurrentPosition();
        }



    }

}
