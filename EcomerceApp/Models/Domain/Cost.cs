namespace EconomicApp.Models.Domain
{
    public class Cost
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Guid TypeId { get; set; }
        public Guid? CostFileId { get; set; } 

        // navigation prop
        public CostType Type { get; set; }
        public CostFile CostFile { get; set; }
    }
}
