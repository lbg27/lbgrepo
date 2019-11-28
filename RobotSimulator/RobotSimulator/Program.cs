using System;
using System.Text;
using ToyRobot;
using ToyRobot.Surface;

namespace RobotSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuider = new StringBuilder();

            stringBuider.AppendLine("******************************");
            stringBuider.AppendLine(" Description");
            stringBuider.AppendLine(" - The application is a simulation of a toy robot moving on a square tabletop, of");
            stringBuider.AppendLine("   dimensions 5 units x 5 units.");
            stringBuider.AppendLine(" - There are no other obstructions on the table surface.");
            stringBuider.AppendLine(" - The robot is free to roam around the surface of the table, but must be prevented from");
            stringBuider.AppendLine("   falling to destruction.Any movement that would result in the robot falling from the");
            stringBuider.AppendLine("   table must be prevented, however further valid movement commands must still be allowed.");
            stringBuider.AppendLine(" Toy robot command input case sensitve");
            stringBuider.AppendLine(" Usage:");
            stringBuider.AppendLine("    PLACE <X>,<Y>,<F>");
            stringBuider.AppendLine("         X = number format x position");
            stringBuider.AppendLine("         Y = number format y position");
            stringBuider.AppendLine("         F = NORTH, EAST, SOUTH, WEST");
            stringBuider.AppendLine("    MOVE");
            stringBuider.AppendLine("    LEFT");
            stringBuider.AppendLine("    RIGHT");
            stringBuider.AppendLine("    REPORT");
            stringBuider.AppendLine("******************************");
            Console.WriteLine(stringBuider.ToString());
            Console.WriteLine("Press enter no input command to stop"); 
            Console.WriteLine("******************************");

            IWorkingArea workingarea = new WorkingArea(5, 5);
            Robot mrobot = new Robot(workingarea);
            bool exitcommand = true;
            do
            {
                Console.WriteLine("Input command: ");
                string command = Console.ReadLine();
                if (!string.IsNullOrEmpty(command))
                {
                    mrobot.RobotCommand(command);
                    string reportmessage = mrobot.DisplayReport();
                    if (!string.IsNullOrEmpty(reportmessage))
                        Console.WriteLine(reportmessage);
                }
                else
                {
                    exitcommand = false;
                }
              
            } while (exitcommand);
        }
    }
}
