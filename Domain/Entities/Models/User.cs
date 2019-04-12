using System.Collections.Generic;

namespace TokenTracker.Domain.Entities.Models
{
    public partial class User
    {
        public User()
        {
            PointTransactionAwardFroms = new HashSet<PointTransaction>();
            PointTransactionAwardTos = new HashSet<PointTransaction>();
        }

        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string ImgSrc { get; set; }
        public bool? IsActive { get; set; }

        public Group Group { get; set; }
        public Role Role { get; set; }

        public ICollection<PointTransaction> PointTransactionAwardFroms { get; set; }
        public ICollection<PointTransaction> PointTransactionAwardTos { get; set; }
    }
}
