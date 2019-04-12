using System.Collections.Generic;

namespace TokenTracker.Domain.Entities.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupDetails = new HashSet<GroupDetail>();
            Users = new HashSet<User>();
            Badges = new HashSet<Badge>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<GroupDetail> GroupDetails { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Badge> Badges { get; set; }
    }
}
