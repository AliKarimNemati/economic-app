using EconomicApp.Models.Domain;

namespace EconomicApp.Repositories
{
    public interface ICostFileRepository
    {
        Task<CostFile> Upload(CostFile costFile);
    }
}
