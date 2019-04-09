using System.Linq;
using Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class TokenTypeService : ITokenTypeService
    {
        #region Members

        private readonly ITokenTypeRepository _tokenTypeRepository;

        public TokenTypeService(ITokenTypeRepository tokenTypeRepository)
        {
            _tokenTypeRepository = tokenTypeRepository;
        }
        #endregion

        public IQueryable<PointTransactionType> GetTokenTypes()
        {
            return _tokenTypeRepository.Get();
        }

        public PointTransactionType CreateTokenType(PointTransactionType tokenType)
        {
            return _tokenTypeRepository.Create(tokenType);
        }

        public PointTransactionType UpdateTokenType(PointTransactionType tokenType)
        {
            return _tokenTypeRepository.Update(tokenType);
        }
    }
}
