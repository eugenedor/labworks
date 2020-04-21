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
    /// строитель для пшеничного хлеба
    /// </summary>
    class WheatBreadBuilder : BreadBuilder.Abstract.BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            this.Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
        }
    }
}
