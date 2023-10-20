using System.ComponentModel.DataAnnotations;

namespace EconomicApp.Models.DTO
{
    public class AddCostTypeDto
    {
        [Required]
        public string Name { get; set; }
    }
}
