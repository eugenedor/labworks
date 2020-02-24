using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Concrete;

namespace Visitor.Abstract
{
    interface IVisitor
    {
        void Visit(Person acc);

        void Visit(Company acc);
    }
}
