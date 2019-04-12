using TokenTracker.Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using System.Linq;
using DAL.Context;

namespace TokenTracker.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BeyondTokenTrackerContext _context;

        public UserRepository(BeyondTokenTrackerContext context)
        {
            _context = context;
        }

        public IQueryable<User> Get()
        {
            return _context.User;
        }

        public User Create(User user)
        {
            _context.User.Add(user);

            return user;
        }

        public User Update(User user)
        {
            _context.User.Update(user);

            return user;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
