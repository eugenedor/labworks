using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.Abstract;

namespace TemplateMethod.Concrete
{
    class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в первый класс");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем уроки, делаем домашние задания");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }
}
