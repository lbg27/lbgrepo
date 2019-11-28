using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Surface
{
    public class WorkingArea : IWorkingArea
    {
        private readonly int _width;
        private readonly int _lenght;
        private Position _currentPosition;

        public WorkingArea(int width, int lenght)
        {
            _width = width;
            _lenght = lenght;
            _currentPosition = null;
        }

        public Position GetCurrentPosition()
        {
            return _currentPosition;
        }

        public void GetCurrentPositionReport(string message)
        {
             _currentPosition.PossitionMessage = message;
        }

        public int GetLength()
        {
            return _lenght;
        }

        public int GetWidth()
        {
            return _width;
        }

        public bool IsValidMove(IPosition position)
        {
           
            if (position == null)
                return false;

            Position pos = new Position(position.X, position.Y, position.PointDirection);

            if (pos.X < 0 || pos.X > _width ||
                pos.Y < 0 || pos.Y > _lenght)
                return false;

            _currentPosition = pos;
            return true;
        }
    }
}
