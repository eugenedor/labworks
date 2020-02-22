using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer developer = new PanelDeveloper("ООО КирпичСтрой");
            developer.PrintDev();
            House housePanel = developer.Create();
            Console.WriteLine();

            developer = new WoodDeveloper("Частный застройщик");
            developer.PrintDev();
            House houseWood = developer.Create();
            Console.ReadLine();
        }
    }
}


//abstract class Product
//{ }

//class ConcreteProductA : Product
//{ }

//class ConcreteProductB : Product
//{ }

//abstract class Creator
//{
//    public abstract Product FactoryMethod();
//}

//class ConcreteCreatorA : Creator
//{
//    public override Product FactoryMethod() { return new ConcreteProductA(); }
//}

//class ConcreteCreatorB : Creator
//{
//    public override Product FactoryMethod() { return new ConcreteProductB(); }
//}