using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract Toy FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Toy FactoryMethod(int type)
        {
            switch (type)
            {
                case 1: return new Car(); 
                case 2: return new Dinosaur();
                case 3: return new Plane();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Toy 
    {
        public abstract void Info();
    }

    //конкретні продукти з різною реалізацією
    public class Car : Toy 
    {
        public override void Info()
        {
            Console.WriteLine("Iграшка машинка.");
        }
    }

    public class Dinosaur : Toy 
    {
        public override void Info()
        {
            Console.WriteLine("Iграшка динозавр.");
        }
    }

    public class Plane : Toy 
    {
        public override void Info()
        {
            Console.WriteLine("Iграшка лiтачок.");
        }
    }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 3; i++)
            {
                var toy = creator.FactoryMethod(i);
                toy.Info();
            }
            Console.ReadKey();
        }
    }
}

