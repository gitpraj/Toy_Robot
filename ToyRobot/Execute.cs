using System;
using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class Execute
    {
        public Table Table = new Table(5, 5);
        public int ToyPlacedFlag = 0;

        public Movement ToyMove;

        /* Run() - Run the commands - PLACE, MOVE, RIGHT, LEFT, REPORT.
            Toy not to move, or turn directions unless a PLACE command
            is issued. */
        public string Run(string[] commands)
        {
            try
            {
                ExecCommand ec = new ExecCommand();
                string msg = "";
                ToyMove = new Movement(Table);
                foreach (string command in commands)
                {
                    if (ToyPlacedFlag == 1)
                    {
                        msg = ec.ExecuteCommand(command, ToyMove);
                    }
                    else if (Regex.IsMatch(command, "^PLACE"))
                    {
                        msg = ec.ExecuteCommand(command, ToyMove);
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
    }
}
