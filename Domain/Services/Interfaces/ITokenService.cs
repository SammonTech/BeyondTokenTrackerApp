using System.Linq;
using Domain.Entities.Dtos;
using Domain.Entities.Models;

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
