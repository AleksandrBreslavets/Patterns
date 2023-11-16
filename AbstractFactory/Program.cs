using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine, Wheels wheels)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
            Console.WriteLine("Wheels:");
            wheels.WheelsInfo();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    //ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    //Mercedes car
    public class Mercedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mercedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }

    //ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }

    //MercedesEngine
    public class MercedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mercedes Engine");
        }
    }

    // AbstractProduct Wheels
    public abstract class Wheels
    {
        public virtual void WheelsInfo()
        {
        }
    }

    public class FordWheels: Wheels
    {
        public override void WheelsInfo()
        {
            Console.WriteLine("Ford wheels");
        }
    }

    public class ToyotaWheels : Wheels
    {
        public override void WheelsInfo()
        {
            Console.WriteLine("Toyota wheels");
        }
    }

    public class MercedesWheels : Wheels
    {
        public override void WheelsInfo()
        {
            Console.WriteLine("Mercedes wheels");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
        Wheels CreateWheels();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }

        Wheels ICarFactory.CreateWheels()
        {
            return new FordWheels();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }

        Wheels ICarFactory.CreateWheels()
        {
            return new ToyotaWheels();
        }
    }

    // MercedesFactory
    public class MercedesFactory : ICarFactory
    {
        Car ICarFactory.CreateCar()
        {
            return new Mercedes();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new MercedesEngine();
        }

        Wheels ICarFactory.CreateWheels()
        {
            return new MercedesWheels();
        }
    }

    public class ClientFactory
    {
        private Car _car;
        private Engine _engine;
        private Wheels _wheels;


        public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            _car = factory.CreateCar();
            _engine = factory.CreateEngine();
            _wheels = factory.CreateWheels();
        }

        public void Run()
        {
            _car.GetType();
            //Абстрагування варіантів використання
            _car.Interact(_engine, _wheels);
        }
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);
            client1.Run();
            Console.WriteLine('\n');

            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            client2.Run();
            Console.WriteLine('\n');

            carFactory = new MercedesFactory();
            ClientFactory client3 = new ClientFactory(carFactory);
            client3.Run();

            Console.ReadKey();
        }
    }
}
