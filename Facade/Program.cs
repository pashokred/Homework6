using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Operator op = new Operator();
            op.BuildHouse();
            op.RedoBathroom();
            op.MakeRoomRedo();
            // Wait for user 
            Console.Read();
        }
    }
    
    // "Subsystem ClassA" 
    class Electrician
    {
        public void SetWiring()
        {
            Console.WriteLine(" Set wiring");
        }
    }

    // Subsystem ClassB" 
    class Plumber
    {
        public void RepairBath()
        {
            Console.WriteLine(" Repaired bath");
        }

        public void RepairHeating()
        {
            Console.WriteLine(" Repaired heating system");
        }
    }


    // Subsystem ClassC" 
    class Builder
    {
        public void BuildHouse()
        {
            Console.WriteLine(" Builded house");
        }

        public void BringToPoint()
        {
            Console.WriteLine(" Bringed to point");
        }
        
    }
    // Subsystem ClassD" 
    class Architector
    {
        public void MakeDesign()
        {
            Console.WriteLine(" Made breathtaking design");
        }
    }
    // "Facade" 
    class Operator
    {
        Electrician electrician;
        Plumber plumber;
        Builder builder;
        Architector architector;

        public Operator()
        {
            electrician = new Electrician();
            plumber = new Plumber();
            builder = new Builder();
            architector = new Architector();
        }

        public void RedoBathroom()
        {
            Console.WriteLine("\nRedoing bathroom ---- ");
            electrician.SetWiring();
            plumber.RepairBath();
        }

        public void BuildHouse()
        {
            Console.WriteLine("\nBuilding house ---- ");
            architector.MakeDesign();
            builder.BuildHouse();
            electrician.SetWiring();
            plumber.RepairHeating();
            builder.BringToPoint();
        }

        public void MakeRoomRedo()
        {
            Console.WriteLine("\nRedoing room ---- ");
            builder.BringToPoint();
            electrician.SetWiring();
            plumber.RepairHeating();
        }
        
    }
}
