using System.ComponentModel.DataAnnotations;

namespace EconomicApp.Models.DTO
{
    public class UpdateCostDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public Guid TypeId { get; set; }

        public Guid? CostFileId { get; set; }
    }
}
