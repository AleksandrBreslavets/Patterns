using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.PayBasic();
            facade.PayAdditional();
            // Wait for user 
            Console.Read();
        }
    }


    // "Subsystem Electricity" 
    class Electricity
    {
        public void PayElectrInFlats()
        {
            Console.WriteLine("Оплата за свiтло в квартирах.");
        }
        public void PayElectrInEntrance()
        {
            Console.WriteLine("Оплата за свiтло в пiд'їздi");
        }
    }

    // Subsystem Water" 
    class Water
    {
        public void PayWater()
        {
            Console.WriteLine("Оплата за постачання води.");
        }
    }

    // Subsystem Lift" 
    class Lift
    {
        public void PayLift()
        {
            Console.WriteLine("Оплата за користуванням лiфтом.");
        }
    }

    // Subsystem Gas" 
    class Gas
    {
        public void PayGas()
        {
            Console.WriteLine("Оплата за постачання газу.");
        }
    }
    // "Facade" 
    class Facade
    {
        Electricity electr;
        Lift lift;
        Water water;
        Gas gas;

        public Facade()
        {
            electr = new Electricity();
            lift = new Lift();
            water = new Water();
            gas = new Gas();
        }

        public void PayBasic()
        {
            Console.WriteLine("\nPayBasic() ---- ");
            electr.PayElectrInFlats();
            water.PayWater();
            gas.PayGas();
        }

        public void PayAdditional()
        {
            Console.WriteLine("\nPayAdditional() ---- ");
            electr.PayElectrInEntrance();
            lift.PayLift();
        }
    }
}
