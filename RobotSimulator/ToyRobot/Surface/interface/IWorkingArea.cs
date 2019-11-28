namespace ToyRobot.Surface
{
    public interface IWorkingArea
    {
        bool IsValidMove(IPosition position);
        Position GetCurrentPosition();
        void GetCurrentPositionReport(string message);
        int GetWidth();
        int GetLength();
    }
}