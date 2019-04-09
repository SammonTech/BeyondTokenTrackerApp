using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
{
    public partial class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool? IsActive { get; set; }
        public int ProductGroupId { get; set; }

        public ProductGroupDto ProductGroup { get; set; }
    }
}
