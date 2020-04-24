using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.Abstract;
using Composite.Concrete;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Component root = new Composite.Concrete.Composite("Root");
            Component leaf = new Leaf("Leaf");
            Component subtree = new Composite.Concrete.Composite("Subtree"); //Composite.Concrete.Composite subtree = new Composite.Concrete.Composite("Subtree");
            root.Add(leaf);
            root.Add(subtree);
            root.Display();

            Console.ReadLine();
        }
    }
}
