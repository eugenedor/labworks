using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Proxy.Concrete
{
    class PageContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
    }
}
