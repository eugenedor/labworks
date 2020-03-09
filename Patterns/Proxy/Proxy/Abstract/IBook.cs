using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Concrete;

namespace Proxy.Abstract
{
    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }
}
