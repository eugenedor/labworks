using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadBuilder.Concrete.BreadComponent;

namespace BreadBuilder.Concrete
{
    /// <summary>
    /// хлеб
    /// </summary>
    class Bread
    {
        // мука
        public Flour Flour { get; set; }

        // соль
        public Salt Salt { get; set; }

        // пищевые добавки
        public Additives Additives { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Flour != null)
                sb.Append(Flour.Sort + "\n");
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append("Добавки: " + Additives.Name + " \n");
            return sb.ToString();
        }
    }
}
