using EconomicWFApp.model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicWFApp.model.DTO
{
    internal class CostDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public CostType Type { get; set; }
        public CostFile CostFile { get; set; }
    }
}
