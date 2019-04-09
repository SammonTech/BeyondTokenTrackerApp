using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
{
    public partial class ProductGroupDto
    {
        public int ProductGroupId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
