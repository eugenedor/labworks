using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Abstract;

namespace Visitor.Concrete
{
    /// <summary>
    /// сериализатор в XML
    /// </summary>
    class XmlVisitor : IVisitor
    {
        public void Visit(Person acc)
        {
            string result = "<Person><Name>" + acc.Name + "</Name>" +
                "<Number>" + acc.Number + "</Number><Person>";
            Console.WriteLine(result);
        }

        public void Visit(Company acc)
        {
            string result = "<Company><Name>" + acc.Name + "</Name>" +
                "<RegNumber>" + acc.RegNumber + "</RegNumber>" +
                "<Number>" + acc.Number + "</Number><Company>";
            Console.WriteLine(result);
        }
    }
}
