using TokenTracker.Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using System.Linq;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace TokenTracker.DAL.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly BeyondTokenTrackerContext _context;

        public TokenRepository(BeyondTokenTrackerContext context)
        {
            _context = context;
        }

        public IQueryable<PointTransaction> Get()
        {
            return _context.PointTransaction
                .Include(x => x.AwardFrom)
                .Include(x => x.AwardTo)
                .Include(x => x.Product)
                .Include(x => x.PointTransactionType);
        }

        public PointTransaction Create(PointTransaction token)
        {
            var cleanToken = RemoveTransactionChildren(token);
            _context.PointTransaction.Add(cleanToken);

            return token;
        }

        public PointTransaction Update(PointTransaction token)
        {
            var cleanToken = RemoveTransactionChildren(token);
            _context.PointTransaction.Update(cleanToken);

            return token;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private PointTransaction RemoveTransactionChildren(PointTransaction transaction)
        {
            var cleanTransaction = transaction;
            cleanTransaction.AwardFrom = null;
            cleanTransaction.AwardTo = null;
            cleanTransaction.Product = null;
            cleanTransaction.PointTransactionType = null;
            return cleanTransaction;
        }
    }
}

