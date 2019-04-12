using System.Linq;
using TokenTracker.Domain.Entities.Dtos;
using TokenTracker.Domain.Entities.Models;

namespace Domain.Services.Interfaces
{
    public interface ITokenService
    {
        IQueryable<PointTransaction> GetTokens();
        PointTransaction CreateToken(PointTransaction token);
        PointTransaction UpdateToken(PointTransaction token);
        TokenStatsDto GetTokensStats(int userId);
        int GetAllotedAmount(int roleId);
        void SaveChanges();
    }
}
