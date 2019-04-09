using System.Linq;
using Domain.Entities.Models;

namespace Domain.Services.Interfaces
{
    public interface ITokenTypeService
    {
        IQueryable<PointTransactionType> GetTokenTypes();
        PointTransactionType CreateTokenType(PointTransactionType tokenType);
        PointTransactionType UpdateTokenType(PointTransactionType tokenType);
    }
}
