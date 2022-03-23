using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AreaOfShapes
{
    public class CalArea
    {
        decimal circle_area;
        double result;
     
        public double Rectangle(double length, double breadth)
        {
            result = length * breadth;
            return result;
        }
        public double Circle(double radius,decimal constant)
        {
            result = (radius * Convert.ToDouble(constant));
            return result;
        }
        public double Square(double side)
        {
            result = side * side;
            return result;
        }
        public double Triangle(double breadthfortriangle, double height)
        {
            result = (breadthfortriangle * height) / 2;
            return result;
        }
    }
}