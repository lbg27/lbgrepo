namespace ToyRobot.Surface
{
    public interface IPosition
    {
     
        int X { get; set; }
        int Y { get; set; }
        Direction? PointDirection { get; set; }
        string PossitionMessage { get; set; }
    }
}