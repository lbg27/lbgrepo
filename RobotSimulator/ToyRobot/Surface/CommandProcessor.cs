using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToyRobot.Surface
{
    public class CommandProcessor
    {
        public Command CurrentCommand;
        public IPosition Location;

        public CommandProcessor()
        {
            Location = new Position(0,0,null);
        }

        public CommandProcessor ParseRequest(string request)
        {
            if (string.IsNullOrEmpty(request))
                return null;

            Command commanddata;
            CommandProcessor command = null;

            try
            {
                string[] requestcommand = request.Split(" ");             
                if (Enum.TryParse(requestcommand[0].Trim(), false, out commanddata))
                {
                    command = new CommandProcessor();
                    command.CurrentCommand = commanddata;
                    if (commanddata == Command.PLACE)
                    {
                        string[] requestdata = requestcommand[1].Split(",");
                        if (requestdata.Length > 2)
                        {                            
                            var direction = GetDirection(requestdata[2]);
                            if (direction == null)
                                return null;

                            command.Location.X = int.Parse(requestdata[0]);
                            command.Location.Y = int.Parse(requestdata[1]);
                            command.Location.PointDirection = direction;                              
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                command = null;
            }

            return command;
         }

        private Direction? GetDirection(string requestdata)
        {      
            foreach (Direction directionEnum in Enum.GetValues(typeof(Direction)))
            {
                string name = Enum.GetName(typeof(Direction), directionEnum);
                if (name.Equals(requestdata))
                {
                    return directionEnum;
                }
            }
            return null;
        }
    }

}
