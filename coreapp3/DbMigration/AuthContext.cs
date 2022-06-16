using coreapp3.DbModels;
using Microsoft.EntityFrameworkCore;

namespace coreapp3.DbMigration
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {

        }

        public DbSet<dbUsers> Users { get; set; }
        protected void Seed(AuthContext db)
        {
            db.SaveChanges();
        }
        protected void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
