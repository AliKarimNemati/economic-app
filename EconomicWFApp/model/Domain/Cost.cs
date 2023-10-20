using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicWFApp.model
{
    internal class Cost
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public Guid TypeId { get; set; }
        public Guid? CostFileId { get; set; }
    }
}
