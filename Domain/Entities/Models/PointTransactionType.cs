using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class PointTransactionType
    {
        public PointTransactionType()
        {
            PointTransactions = new HashSet<PointTransaction>();
        }

        public int PointTransactionTypeId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public int AffectOnAwardTo { get; set; }
        public int AffectOnAwardFrom { get; set; }
        public bool? IsActive { get; set; }

        public Role Role { get; set; }
        public ICollection<PointTransaction> PointTransactions { get; set; }
    }
}
