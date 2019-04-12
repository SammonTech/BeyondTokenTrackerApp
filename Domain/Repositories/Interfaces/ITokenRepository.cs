using TokenTracker.Domain.Entities.Models;
using System.Linq;

namespace Domain.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        IQueryable<PointTransaction> Get();
        PointTransaction Create(PointTransaction token);
        PointTransaction Update(PointTransaction token);
        void SaveChanges();
    }
}
