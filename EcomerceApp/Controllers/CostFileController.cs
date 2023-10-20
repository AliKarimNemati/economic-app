using EconomicApp.Models.Domain;
using EconomicApp.Models.DTO;
using EconomicApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EconomicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostFileController : ControllerBase
    {
        private readonly ICostFileRepository costFileRepository;

        public CostFileController(ICostFileRepository costFileRepository)
        {
            this.costFileRepository = costFileRepository;
        }

        // Upload File
        [HttpPost]
        [Route("Uplaod")]
        public async Task<IActionResult> Upload([FromForm] UploadCostFileDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var costFile = new CostFile
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription
                };

                // Upload File
                await costFileRepository.Upload(costFile);

                return Ok(costFile);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //validation file that the length must be less than 10MB and file can only be pdf, png, jpg and jpeg
        private void ValidateFileUpload(UploadCostFileDto request)
        {
            var allowedExtensions = new string[] { ".pdf", ".png", ".jpg", ".jpeg" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file.");
            }
        }
    }
}
