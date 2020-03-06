﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Abstract;

namespace Visitor.Concrete
{
    class Bank
    {
        List<IAccount> accounts = new List<IAccount>();
        public void Add(IAccount acc)
        {
            accounts.Add(acc);
        }
        public void Remove(IAccount acc)
        {
            accounts.Remove(acc);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (IAccount acc in accounts)
                acc.Accept(visitor);
        }
    }
}