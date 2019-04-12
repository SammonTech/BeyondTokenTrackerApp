using System.Linq;
using TokenTracker.Domain.Entities.Models;

namespace Domain.Services.Interfaces
{
    public interface ITokenTypeService
    {
        IQueryable<PointTransactionType> GetTokenTypes();
        PointTransactionType CreateTokenType(PointTransactionType tokenType);
        PointTransactionType UpdateTokenType(PointTransactionType tokenType);
    }
}
