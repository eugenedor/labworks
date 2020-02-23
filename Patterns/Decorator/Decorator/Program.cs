using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Abstract;
using Decorator.Concrete;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            //ItalianPizza
            Pizza pizzaIt1 = new ItalianPizza();
            Console.WriteLine("Название: {0}", pizzaIt1.Name);
            Console.WriteLine("Цена: {0}", pizzaIt1.GetCost());

            pizzaIt1 = new PlusTomatoPizza(pizzaIt1); // итальянская пицца с томатами
            Console.WriteLine("Название: {0}", pizzaIt1.Name);
            Console.WriteLine("Цена: {0}", pizzaIt1.GetCost());

            Pizza pizzaIt2 = new ItalianPizza();
            pizzaIt2 = new PlusCheesePizza(pizzaIt2);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizzaIt2.Name);
            Console.WriteLine("Цена: {0}", pizzaIt2.GetCost());

            Console.WriteLine();

            //BulgerianPizza
            Pizza pizzaBul = new BulgerianPizza();
            Console.WriteLine("Название: {0}", pizzaBul.Name);
            Console.WriteLine("Цена: {0}", pizzaBul.GetCost());

            pizzaBul = new PlusTomatoPizza(pizzaBul);
            pizzaBul = new PlusCheesePizza(pizzaBul);// болгарская пиццы с томатами и сыром
            Console.WriteLine("Название: {0}", pizzaBul.Name);
            Console.WriteLine("Цена: {0}", pizzaBul.GetCost());

            Console.ReadLine();
        }
    }
}



//abstract class Component
//{
//    public abstract void Operation();
//}
//class ConcreteComponent : Component
//{
//    public override void Operation()
//    { }
//}
//abstract class Decorator : Component
//{
//    protected Component component;

//    public void SetComponent(Component component)
//    {
//        this.component = component;
//    }

//    public override void Operation()
//    {
//        if (component != null)
//            component.Operation();
//    }
//}
//class ConcreteDecoratorA : Decorator
//{
//    public override void Operation()
//    {
//        base.Operation();
//    }
//}
//class ConcreteDecoratorB : Decorator
//{
//    public override void Operation()
//    {
//        base.Operation();
//    }
//}

//Comment
//В отличие от формальной схемы здесь установка декорируемого объекта происходит не в методе SetComponent, а в конструкторе.
//Сначала объект BulgerianPizza обертывается декоратором TomatoPizza, а затем CheesePizza. 
//И таких обертываний мы можем сделать множество. Просто достаточно унаследовать от декоратора класс, который будет определять дополнительный функционал.

//Если бы мы использовали наследование, 
//то в данном случае только для двух видов пицц с двумя добавками нам бы пришлось создать восемь различных классов.