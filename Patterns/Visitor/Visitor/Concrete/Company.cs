using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Abstract;

namespace Visitor.Concrete
{
    class Company : IAccount
    {
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
