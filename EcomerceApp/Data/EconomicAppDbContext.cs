using EconomicApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EcomerceApp.Data
{
    public class EconomicAppDbContext: DbContext 
    {
        public EconomicAppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
        public DbSet<CostFile> CostFiles { get; set; }

    }
}
