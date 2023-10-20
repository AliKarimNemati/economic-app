using EconomicApp.Models.Domain;
using EconomicApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace EconomicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportViewerController : Controller
    {
        private readonly IGenericRepository<Income> genericIncomeRepository;
        private readonly IGenericRepository<Cost> genericCostRepository;

        public ReportViewerController(IGenericRepository<Income> genericIncomeRepository, IGenericRepository<Cost> genericCostRepository)
        {
            this.genericIncomeRepository = genericIncomeRepository;
            this.genericCostRepository = genericCostRepository;
        }

        //download file function
        [NonAction]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            var downloadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", filename);

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(downloadFilePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(downloadFilePath);

            return File(bytes, contentType, Path.GetFileName(downloadFilePath));
        }

        //get income items report in pdf file 
        [HttpGet]
        [Route("IncomeReport")]
        public async Task<IActionResult> IncomeReport()
        {
            var renderer = new ChromePdfRenderer();

            // report template
            var html = "<style>table, th, td {border: 1px solid gray; padding: 8px;} h2 {color: red;}</style>";
            html += "<body><h2>Income Report</h2><table style =\"width: 100%\"><tr><th></th><th>Name</th><th>Price</th></tr>";

            var i = 0;
            foreach (var income in await genericIncomeRepository.GetAllAsync())
            {
                i++;
                html += $"<tr><td>{i}</td><td>{income.Name}</td><td>${income.Amount}</td></tr>";
            }

            html += "</table></body>";

            // render html as pdf
            var pdf = renderer.RenderHtmlAsPdf(html);

            string pdfFileName = DateTime.Now.Ticks.ToString() + ".pdf";
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "Reports", pdfFileName));

            //return download link
            return await DownloadFile(pdfFileName);
        }

        //get cost items report in pdf file
        [HttpGet]
        [Route("CostReport")]
        public async Task<IActionResult> CostReport()
        {
            var renderer = new ChromePdfRenderer();

            // report template
            var html = "<style>table, th, td {border: 1px solid gray; padding: 8px;} h2 {color: red;}</style>";
            html += "<body><h2>Cost Report</h2><table style =\"width: 100%\"><tr><th></th><th>Name</th><th>Price</th><th>Type</th></tr>";

            var i = 0;
            foreach (var cost in await genericCostRepository.GetAllAsync())
            {
                i++;
                html += $"<tr><td>{i}</td><td>{cost.Name}</td><td>${cost.Amount}</td><td>{cost.Type.Name}</td></tr>";
            }

            html += "</table></body>";

            // render html to pdf
            var pdf = renderer.RenderHtmlAsPdf(html);

            string pdfFileName = DateTime.Now.Ticks.ToString() + ".pdf";
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "Reports", pdfFileName));

            //return download link
            return await DownloadFile(pdfFileName);
        }
    }
}
