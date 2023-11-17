using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListForMivnei
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {

        }

        // Getter for x
        public int GetX()
        {
            return x;
        }

        // Setter for x
        public void SetX(int newX)
        {
            x = newX;
        }

        // Getter for y
        public int GetY()
        {
            return y;
        }

        // Setter for y
        public void SetY(int newY)
        {
            y = newY;
        }
        public bool AreEqual(Point other)
        {
            return (x == other.GetX() && y == other.GetY());
        }

        public void CopyPoint(Point other)
        {
            this.x = other.GetX();
            this.y = other.GetY();
        }

        public override string ToString()
        {
            return "[" + x + "," + y + "]";
        }

    }
}
