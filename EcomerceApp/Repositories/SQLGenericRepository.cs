using EcomerceApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EconomicApp.Repositories
{
    public class SQLGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EconomicAppDbContext dbContext;
        private readonly DbSet<T> entity;

        public SQLGenericRepository(EconomicAppDbContext dbContext)
        {
            this.dbContext = dbContext;
            entity = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T model)
        {
            await entity.AddAsync(model);
            await dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<T?> UpdateAsync(Guid id, T model)
        {
            var existingModel = entity.Find(id);

            if (existingModel == null)
            {
                return null;
            }
            entity.Update(model);

            await dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return typeof(T).Name == "Cost" ? await entity.Include("Type").Include("CostFile").ToListAsync() : await entity.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var existingModel = entity.Find(id);

            if (existingModel == null)
            {
                return null;
            }
            return existingModel;
        }

        public async Task<T?> DeleteAsync(Guid id)
        {
            // check existing
            var existingModel = entity.Find(id);

            if (existingModel == null)
            {
                return null;
            }

            entity.Remove(existingModel);
            await dbContext.SaveChangesAsync();

            return existingModel;
        }
    }
}
