using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Prototype prototype = new ConcretePrototype1(10, 15, 23);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(14, 5, 50);
            clone = prototype.Clone();
            
            prototype = new Triangle(10, 14, 50);;
            clone = prototype.Clone();

        }
    }

    public abstract class Prototype
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public Prototype(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(double side1, double side2, double side3)
        : base(side1, side2, side3)
        { }
        public override Prototype Clone()
        {
            Console.WriteLine("Cloned ConcretePrototype1 with sides: {0}, {1}, {2}", Side1, Side2, Side3);
            return new ConcretePrototype1(Side1, Side2, Side3);
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(double side1, double side2, double side3)
            : base(side1, side2, side3)
        { }
        public override Prototype Clone()
        {
            Console.WriteLine("Cloned ConcretePrototype2 with sides: {0}, {1}, {2}", Side1, Side2, Side3);
            return new ConcretePrototype2(Side1, Side2, Side3);
        }
    }
    
    public class Triangle : Prototype
    {
        public Triangle(double side1, double side2, double side3)
            : base(side1, side2, side3)
        {
            if (!IfTriangle(side1, side2, side3)) return;
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        private static bool IfTriangle(double side1, double side2, double side3)
        {
            return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
        }
        
        public void ChangeSide(double value, int siteNumber)
        {
            switch (siteNumber)
            {
                case 1 when IfTriangle(value, Side2, Side3):
                    Side1 = value;
                    break;
                case 2 when IfTriangle(Side1, value, Side3):
                    Side2 = value;
                    break;
                case 3 when IfTriangle(Side1, Side2, value):
                    Side3 = value;
                    break;
                default:
                    Console.WriteLine("Incorrect number of side. There is only sides with numbers 1, 2 and 3");
                    break;
            }
        }

        public double ComputeAngle(int site1Number, int site2Number)
        {
            switch (site1Number)
            {
                case 1 when site2Number == 2:
                case 2 when site2Number == 1:
                    return Math.Acos((Side1 * Side1 + Side2 * Side2 - Side3 * Side3) / (2 * Side1 * Side2)) * 180 / Math.PI;
                case 1 when site2Number == 3:
                case 3 when site2Number == 1:
                    return Math.Acos((Side1 * Side1 + Side3 * Side3 - Side2 * Side2) / (2 * Side1 * Side3)) * 180 / Math.PI;
                case 2 when site2Number == 3:
                case 3 when site2Number == 2:
                    return Math.Acos((Side2 * Side2 + Side3 * Side3 - Side1 * Side1) / (2 * Side2 * Side3)) * 180 / Math.PI;
                default:
                    Console.WriteLine("Incorrect number of side or equal sides: {0}, {1}. There is only sides with numbers 1, 2 and 3", site1Number, site2Number);
                    return 0;
            }
        }

        public double ComputePerimeter()
        {
            return Side1 + Side2 + Side3;
        }
        
        
        public static double Side1 { get; set; }
        public static double Side2 { get; set; }
        public static double Side3 { get; set; }
        public override Prototype Clone()
        {
            Console.WriteLine("Cloned Triangle with sides: {0}, {1}, {2}", Side1, Side2, Side3);
            return new Triangle(Side1, Side2, Side3);
        }
    }
}
