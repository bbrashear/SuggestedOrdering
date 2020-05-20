using SuggestedOrdering.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestedOrdering
{
    interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
    }
}
