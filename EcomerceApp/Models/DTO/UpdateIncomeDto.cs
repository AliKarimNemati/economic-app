using System.ComponentModel.DataAnnotations;

namespace EconomicApp.Models.DTO
{
    public class UpdateIncomeDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
