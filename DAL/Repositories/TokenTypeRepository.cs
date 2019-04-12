using TokenTracker.Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using System.Linq;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace TokenTracker.DAL.Repositories
{
    public class TokenTypeRepository : ITokenTypeRepository
    {
        private readonly BeyondTokenTrackerContext _context;

        public TokenTypeRepository(BeyondTokenTrackerContext context)
        {
            _context = context;
        }

        public IQueryable<PointTransactionType> Get()
        {
            return _context.PointTransactionType;
        }

        public PointTransactionType Create(PointTransactionType tokenType)
        {
            var cleanTokenType = RemoveTransactionTypeChildren(tokenType);
            _context.PointTransactionType.Add(cleanTokenType);

            return cleanTokenType;
        }

        public PointTransactionType Update(PointTransactionType tokenType)
        {
            var cleanTokenType = RemoveTransactionTypeChildren(tokenType);
            _context.PointTransactionType.Update(cleanTokenType);

            return cleanTokenType;
        }

        private PointTransactionType RemoveTransactionTypeChildren(PointTransactionType transactionType)
        {
            var cleanTransactionType = transactionType;
            cleanTransactionType.Role = null;
            cleanTransactionType.PointTransactions = null;

            return cleanTransactionType;
        }
    }
}
