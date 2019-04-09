using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
{
    public class TransactionTypeDto
    {
        public int PointTransactionTypeId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public int AffectOnAwardTo { get; set; }
        public int AffectOnAwardFrom { get; set; }
        public bool? IsActive { get; set; }
        public RoleDto Role { get; set; }
    }
}
