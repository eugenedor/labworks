using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadBuilder.Abstract;

namespace BreadBuilder.Concrete
{
    /// <summary>
    /// пекарь
    /// </summary>
    class Baker
    {
        public Bread Bake(BreadBuilder.Abstract.BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }
}
