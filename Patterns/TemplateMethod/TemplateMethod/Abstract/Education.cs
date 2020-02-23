using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.Abstract
{
    abstract class Education
    {
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExams()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }
        public abstract void GetDocument();

        /// <summary>
        /// Template Method
        /// </summary>
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
    }
}
