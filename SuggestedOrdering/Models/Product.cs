using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestedOrdering.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ItemNumber { get; set; }
        public string Description { get; set; }
        public string CaseSize { get; set; }
        public int UsageNumber { get; set; }
        public int OnHand { get; set; }
    }
}
