using System;
using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class Execute
    {
        public Movement Move;
        public Table Table = new Table(5, 5);
        public int ToyPlacedFlag = 0;

        /* Run() - Run the commands - PLACE, MOVE, RIGHT, LEFT, REPORT.
            Toy not to move, or turn directions unless a PLACE command
            is issued. */
        public string Run(string[] commands)
        {
            try
            {
                string msg = "";
                Move = new Movement(Table);
                foreach (string command in commands)
                {
                    if (ToyPlacedFlag == 1)
                    {
                        msg = ExecCommand(command);
                    }
                    else if (Regex.IsMatch(command, "^PLACE"))
                    {
                        msg = ExecCommand(command);
                        if (!msg.Contains("Not Placed"))
                        {
                            ToyPlacedFlag = 1;
                        }
                        //msg = "";
                    }
                }

                if (ToyPlacedFlag == 0)
                {
                    return "Not Placed";
                }

                return msg;
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.ToString());
                    return "Exception: " + e.InnerException.ToString();
                }

                return "Exception";
            }
        }

        /* ExecCommand() - do operations according to the commands. 
              Return string messages which would be displayed on the console */

        public string ExecCommand(string command)
        {
            try
            {
                if (Regex.IsMatch(command, "^MOVE") 
                    || Regex.IsMatch(command, "^RIGHT") 
                    || Regex.IsMatch(command, "^LEFT"))
                {
                    Move.RobotMoves(command.ToLower());
                    return "";
                }
                else if (Regex.IsMatch(command, "^PLACE"))
                {
                    string[] coords = command.Split(new[] { ',', ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries);
                    if (coords.Length == 4)
                    {
                        string firstArg = coords[1];
                        string secondArg = coords[2];
                        string thirdArg = coords[3];
                        int x;
                        int y;

                        /* to make sure first 2 args are integers */
                        if (Int32.TryParse(firstArg, out x) &&
                                Int32.TryParse(secondArg, out y))
                        {
                            Move.Place(x, y, thirdArg);
                        }
                    }

                    if (Move.Toy == null)
                    {
                        return "Not Placed";
                    }

                    return "";
                } 
                else if (Regex.IsMatch(command, "^REPORT"))
                {
                    return Move.Display();
                }
                else
                {
                    return "Commands are not right.";
                }
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.ToString());
                    return "Exception: " + e.InnerException.ToString();
                }

                return "Exception";
            }
        }
    }
}
