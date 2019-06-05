using System;

namespace ToyRobot
{
    /* Movement class
        Members:
            Toy: The actual toy
            TableTop: The board the toy moves on */

    public class Movement
    {
        public Robot Toy;
        public Table TableTop;

        public Movement(Table table)
        {
            TableTop = table;
        }

        /* Place()
            This executes place command.
            First check if the entry on table is valid and then check if the
            direction is valid */

        public void Place(int x, int y, string direction)
        {
            try
            {
                if (TableTop.IsValidEntryOnTable(x, y))
                {
                    if (TableTop.isValidDirection(direction.ToLower()))
                    {
                        Toy = new Robot
                        {
                            direction = direction.ToLower(),
                            x = x,
                            y = y
                        };
                    }
                }
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                    Console.WriteLine(e.InnerException.ToString());
            }
        }

        /* RobotMoves()
            This executes MOVE, RIGHT, LEFT command.
            For MOVE operation: validate the move according to the direction.
            FOR RIGHT operation: Turn right
            FOR LEFT operation: Turn left */

        public void RobotMoves(string movement)
        {
            try
            {
                switch (movement)
                {
                    case "right":
                        Toy.TurnRight();
                        break;

                    case "left":
                        Toy.TurnLeft();
                        break;

                    case "move":
                        switch (Toy.direction)
                        {
                            case "east":
                                if (TableTop.IsValidEntryOnTable(Toy.x + 1,
                                        Toy.y))
                                {
                                    Toy.Move();
                                }
                                break;
                            case "west":
                                if (TableTop.IsValidEntryOnTable(Toy.x - 1,
                                        Toy.y))
                                {
                                    Toy.Move();
                                }
                                break;
                            case "north":
                                if (TableTop.IsValidEntryOnTable(Toy.x,
                                        Toy.y + 1))
                                {
                                    Toy.Move();
                                }
                                break;
                            case "south":
                                if (TableTop.IsValidEntryOnTable(Toy.x,
                                        Toy.y - 1))
                                {
                                    Toy.Move();
                                }
                                break;
                        }
                        break;
                }
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                    Console.WriteLine(e.InnerException.ToString());
            }
        }

        /* Display()
            Displays the output */

        public string Display()
        {
            try
            {
                return Toy.Report();
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
