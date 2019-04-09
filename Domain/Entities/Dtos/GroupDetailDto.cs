using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
{
    public partial class GroupDetailDto
    {
        public int GroupDetailId { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int? ValueNumber { get; set; }
        public string ValueString { get; set; }
        public DateTime? ValueDate { get; set; }

    }
}
