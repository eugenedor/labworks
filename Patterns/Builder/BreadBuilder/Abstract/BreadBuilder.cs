using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadBuilder.Concrete;


namespace BreadBuilder.Abstract
{
    /// <summary>
    ///  абстрактный класс строителя
    /// </summary>
    abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }
        public void CreateBread()
        {
            Bread = new Bread();
        }
        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }
}
