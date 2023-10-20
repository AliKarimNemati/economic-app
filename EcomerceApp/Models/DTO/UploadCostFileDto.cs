using System.ComponentModel.DataAnnotations;

namespace EconomicApp.Models.DTO
{
    public class UploadCostFileDto
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }

    }
}
