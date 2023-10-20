using EconomicApp.Models.Domain;

namespace EconomicApp.Models.DTO
{
    public class CostDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public CostType Type { get; set; }

        public CostFile CostFile { get; set; }
    }
}
