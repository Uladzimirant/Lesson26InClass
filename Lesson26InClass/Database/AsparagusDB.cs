using Lesson26InClass.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson26InClass.Database
{
    public class AsparagusDB : DbContext
    {
        public AsparagusDB(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Asparagus> Asparagus { get; set; }
    }
}
