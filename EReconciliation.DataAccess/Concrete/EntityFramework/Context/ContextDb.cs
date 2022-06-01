using Microsoft.EntityFrameworkCore;

namespace EReconciliation.DataAccess.Concrete.EntityFramework.Context
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=eReconciliationDb;Integrated Security=true");
        }

        public DbSet<AccountReconciliationDetail>
    }
}
