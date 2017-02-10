using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MmsDb
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Database") { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
    }
}
