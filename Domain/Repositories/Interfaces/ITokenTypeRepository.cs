using Domain.Entities.Models;
using System.Linq;

namespace Domain.Repositories.Interfaces
{
    public interface ITokenTypeRepository
    {
        IQueryable<PointTransactionType> Get();
        PointTransactionType Create(PointTransactionType tokenType);
        PointTransactionType Update(PointTransactionType tokenType);
    }
}
