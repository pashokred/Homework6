using System;
using System.Collections.Generic;

namespace ChristmasTree
{
    class Program
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree chrTree = new ChristmasTree();
            AddDecoration d1 = new AddDecoration();
            AddGarland d2 = new AddGarland();

            // Link decorators
            d1.SetComponent(chrTree);
            d2.SetComponent(d1);
            
            d1.Operation();
            d2.Operation();
            d1.Operation();
            d1.Operation();
            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Tree
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ChristmasTree : Tree
    {
        public override void Operation()
        {
            Console.WriteLine("Christmas tree is shining very pretty!");
        }
    }
    // "Decorator"
    abstract class Decorator : Tree
    {
        protected Tree component;

        public void SetComponent(Tree component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class AddDecoration : Decorator
    {
        private string addedState;
        private int counter;
        private List<string> decorationsAvailable = new List<string>(){"green ", "red ", "blue ", "white ", "brown ", "fairy "};
        
        public override void Operation()
        {
            base.Operation();
            counter++;
            addedState += decorationsAvailable[counter];
            Console.WriteLine("Added new decoration. There is so pretty decorations here: {0}", addedState);
        }
    }

    // "ConcreteDecoratorB" 
    class AddGarland : Decorator
    {
        private int garlandCount;
        public override void Operation()
        {
            base.Operation();
            AddedGarland();
            Console.WriteLine("Added new garland. This {0} garlands are so attractive!", garlandCount);
        }

        void AddedGarland()
        {
            garlandCount++;
        }
    }
}