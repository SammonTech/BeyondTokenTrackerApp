using TokenTracker.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context.Interfaces
{
    public interface IBeyondTokenTrackerContext
    {
        DbSet<Group> Group { get; set; }
        DbSet<GroupDetail> GroupDetail { get; set; }
        DbSet<PointTransaction> PointTransaction { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductGroup> ProductGroup { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<User> User { get; set; }

        int SaveChanges();
    }
}
