using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Abstract
{
    /// <summary>
    /// Абстрактный класс строительной компании (Creator)
    /// </summary>
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Фабричный метод (abstract Product FactoryMethod())
        /// </summary>
        public abstract House Create();

        public void PrintDev()
        {
            Console.WriteLine(Name);
        }
    }
}
