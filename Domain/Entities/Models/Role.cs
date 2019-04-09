using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            PointTransactionTypes = new HashSet<PointTransactionType>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<PointTransactionType> PointTransactionTypes { get; set; }
    }
}
