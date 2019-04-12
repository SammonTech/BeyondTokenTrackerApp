using System.Collections.Generic;

namespace TokenTracker.Domain.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            PointTransactions = new HashSet<PointTransaction>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public string ImgSrc { get; set; }
        public bool? IsActive { get; set; }
        public int ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }
        public ICollection<PointTransaction> PointTransactions { get; set; }
    }
}
