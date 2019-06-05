using System;

namespace ToyRobot
{
    /* Table class
        Members:
            width: width of the table
            length: length of the table */

    public class Table
    {
        public int width;
        public int length;

        public Table(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        /* IsValidEntryOnTable()
            This validates if the position of the toy is on the table. */

        public bool IsValidEntryOnTable(int x, int y)
        {
            try
            {
                if (x >= 0 && y >= 0 && x < width && y < length)
                    return true;
                else
                    return false;
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                    Console.WriteLine(e.InnerException.ToString());

                return false;
            }
        }

        /* isValidDirection()
            This validates if the direction of the toy facing is valid. */

        public bool isValidDirection(string dir)
        {
            try
            {
                int flag = 0;
                switch (dir)
                {
                    case "east":
                        flag = 1;
                        break;
                    case "west":
                        flag = 1;
                        break;
                    case "north":
                        flag = 1;
                        break;
                    case "south":
                        flag = 1;
                        break;
                }

                if (flag == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception e)
            {
                if (e != null && e.InnerException != null)
                    Console.WriteLine(e.InnerException.ToString());

                return false;
            }
        }
    }
}