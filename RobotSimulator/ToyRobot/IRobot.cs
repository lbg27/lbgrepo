using ToyRobot.Surface;

namespace ToyRobot
{
    public interface IRobot
    {
        IWorkingArea GetWorkingArea();
        IPosition RobotCommand(string command);
        string DisplayReport();
    }
}