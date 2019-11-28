using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Surface
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction? PointDirection { get; set; }
        public string PossitionMessage { get; set; } = "";

        public Position(int x, int y, Direction? pointDirection)
        {
            X = x;
            Y = y;
            PointDirection = pointDirection;
        }

        public static IPosition SetPosition(Position pos)
        {
            if (pos == null)
                 return null;

            Position posdata = new Position(pos.X, pos.Y, pos.PointDirection);
            var direction = (Direction)pos.PointDirection;
            switch (direction)
            {
                case Direction.NORTH:
                    posdata.Y++;
                    break;
                case Direction.SOUTH:
                    posdata.Y--;
                    break;
                case Direction.EAST:
                    posdata.X++;
                    break;
                case Direction.WEST:
                    posdata.X--;
                    break;
            }
            return posdata;
        }

        public static Direction? SetDirectionToLeft(Direction? posdirection)
        {
            if (posdirection == null)
                return posdirection;

            Direction direction = (Direction)posdirection + 1;
            return (direction > Direction.EAST) ? Direction.NORTH : direction;
        }

        public static Direction? SetDirectionToRight(Direction? posdirection)
        {
            if (posdirection == null)
                return posdirection;

            Direction direction = (Direction)posdirection - 1;
            return (direction < Direction.NORTH) ? Direction.EAST : direction;
        }
    }
}
