using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDictionary
{
    internal class Calculator
    {
        internal delegate decimal OperationDelegate(decimal x, decimal y);
        internal Dictionary<string, OperationDelegate> operations;

        internal Calculator()
        {
            operations = new Dictionary<string, OperationDelegate>
            {
                { "+", delegate(decimal x, decimal y) { return x + y; } },
                { "-", (x, y) => x - y },
                { "*", DoMultiplication },
                { "/", this.DoDivision },
            };
        }

        public void DefineOperation(string op, OperationDelegate body)
        {
            if (operations.ContainsKey("op"))
                throw new ArgumentException("Operation already exists", "op");

            operations[op] = body;  //operations.Add(op, body);
        }

        public decimal SimpleOperation(string op, decimal x, decimal y)
        {
            switch (op)
            {
                case "+": return x + y;
                case "-": return x - y;
                case "*": return x * y;
                case "/": return x / y;
                default: throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            }
        }

        public decimal PerformOperation(string op, decimal x, decimal y)
        {
            if (!operations.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");

            var method = operations[op];

            return method(x, y);
        }

        private decimal DoAddition(decimal x, decimal y) { return x + y; }
        private decimal DoSubtraction(decimal x, decimal y) { return x - y; }
        private decimal DoMultiplication(decimal x, decimal y) { return x * y; }
        private decimal DoDivision(decimal x, decimal y) { return x / y; }
    }
}
