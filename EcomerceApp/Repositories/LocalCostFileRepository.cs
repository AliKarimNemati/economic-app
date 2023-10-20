using EcomerceApp.Data;
using EconomicApp.Models.Domain;

namespace EconomicApp.Repositories
{
    public class LocalCostFileRepository : ICostFileRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly EconomicAppDbContext dbContext;

        public LocalCostFileRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, EconomicAppDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<CostFile> Upload(CostFile costFile)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "CostFiles", $"{costFile.FileName}{ costFile.FileExtension}");
            
            // Upload file to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await costFile.File.CopyToAsync(stream);

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/CostFiles/{costFile.FileName}{costFile.FileExtension}";
            costFile.FilePath = urlFilePath;

            // Add files to files table
            await dbContext.CostFiles.AddAsync(costFile);
            await dbContext.SaveChangesAsync();

            return costFile;
        }
    }
}
