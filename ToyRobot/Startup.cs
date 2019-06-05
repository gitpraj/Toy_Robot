using System;
using System.Collections.Generic;
using System.IO;

namespace ToyRobot
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Startup prog = new Startup();
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("File argument missing");
                return;
            }

            if (File.Exists(args[0]))
            {
                string[] commands = File.ReadAllLines(args[0]);
                String result = prog.RunTheCommand(commands);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }

        /* RunTheCommand - runs the program according to whatever commands
            are present in the file given as argument. */

        public string RunTheCommand(string[]commands)
        {
            try
            {
                string message = "";
                Execute exec = new Execute();
                if (exec != null)
                {
                    message = exec.Run(commands);
                }
                return message;
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
