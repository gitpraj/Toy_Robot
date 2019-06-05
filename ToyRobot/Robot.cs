using System;

namespace ToyRobot
{
    /* Interface Move - move the robot
        Any class can implement the interface and define the function */
    public interface RobotMoves
    {
        void Move();
    }

    /* Interface RobotTurnLeft - Turn the robot's direction 90 deg to the left
        Any class can implement the interface and define the function */
    public interface RobotTurnLeft
    {
        void TurnLeft();
    }

    /* Interface RobotTurnRight - - Turn the robot's direction 90 deg to the
     *  right
        Any class can implement the interface and define the function */
    public interface RobotTurnRight
    {
        void TurnRight();
    }


    /* Toy class
        Members:
            x: x coordinate of the toy
            y: y coordinate of the toy
            direction: direction the toy is facing */

    public class Toy
    {
        public int x = 0;
        public int y = 0;
        public string direction;
    }

    /* Robot class
        Inherits Toy class.
        Implements interfaces RobotMoves, RobotTurnLeft, RobotTurnRight */

    public class Robot : Toy, RobotMoves, RobotTurnLeft, RobotTurnRight
    {
        public string Report()
        {
            try
            {
                return x + "," + y + "," + direction.ToUpper();
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

        public void Move()
        {
            try
            {
                switch (direction)
                {
                    case "east":
                        x += 1;
                        break;
                    case "west":
                        x -= 1;
                        break;
                    case "north":
                        y += 1;
                        break;
                    case "south":
                        y -= 1;
                        break;
                }
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                    Console.WriteLine(e.InnerException.ToString());
            }
        }

        public void TurnLeft()
        {
            try
            {
                switch (direction)
                {
                    case "east":
                        direction = "north";
                        break;
                    case "west":
                        direction = "south";
                        break;
                    case "north":
                        direction = "west";
                        break;
                    case "south":
                        direction = "east";
                        break;
                }
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                    Console.WriteLine(e.InnerException.ToString());
            }
        }

        public void TurnRight()
        {
            try
            {
                switch (direction)
                {
                    case "east":
                        direction = "south";
                        break;
                    case "west":
                        direction = "north";
                        break;
                    case "north":
                        direction = "east";
                        break;
                    case "south":
                        direction = "west";
                        break;
                }
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                    Console.WriteLine(e.InnerException.ToString());
            }
        }
    }
}
