using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree tree = new ChristmasTree();
            ChristmasToysDecorator d1 = new ChristmasToysDecorator("Жовта кулька", "снiжинка");
            Garland d2 = new Garland("Жовта");

            // Link decorators
            d1.SetComponent(tree);
            d2.SetComponent(d1);

            d2.Decorate();

            // Wait for user
            Console.Read();
        }
    }

    abstract class Component
    {
        public abstract void Decorate();
    }

  
    class ChristmasTree : Component
    {
        public override void Decorate()
        {
            Console.WriteLine("Ялинка встановлена!");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Decorate()
        {
            if (component != null)
            {
                component.Decorate();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ChristmasToysDecorator : Decorator
    {
        private string toyA;
        private string toyB;

        public ChristmasToysDecorator(string toyA, string toyB)
        {
            this.toyA = toyA;
            this.toyB = toyB;
        }

        public override void Decorate()
        {
            base.Decorate();
            Console.WriteLine("{0} та {1} декорують ялинку.", toyA, toyB);
        }
    }

    // "ConcreteDecoratorB" 
    class Garland : Decorator
    {
        private string garlandColor;

        public Garland(string color)
        {
            garlandColor = color;
        }

        public override void Decorate()
        {
            base.Decorate();
            LightUpChristmasTree();
            Console.WriteLine("{0} гiрлянда пiдсвiчує ялинку.", garlandColor);
        }

        void LightUpChristmasTree()
        {
            Console.WriteLine("Гiрлянда встановлена на ялинку.");
        }
    }
}
