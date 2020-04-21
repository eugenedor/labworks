using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadBuilder.Abstract;
using BreadBuilder.Concrete.BreadComponent;

namespace BreadBuilder.Concrete
{
    /// <summary>
    /// строитель для ржаного хлеба
    /// </summary>
    class RyeBreadBuilder : BreadBuilder.Abstract.BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            // не используется
        }
    }
}
