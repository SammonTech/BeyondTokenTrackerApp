using System.Collections.Generic;

namespace TokenTracker.Domain.Entities.Models
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Products = new HashSet<Product>();
        }

        public int ProductGroupId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
