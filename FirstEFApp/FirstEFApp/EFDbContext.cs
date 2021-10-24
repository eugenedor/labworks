using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FirstEFApp
{
    class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}
