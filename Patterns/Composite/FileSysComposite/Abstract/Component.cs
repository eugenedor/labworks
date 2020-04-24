using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSysComposite.Abstract
{
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }
}
