using Domain.Entities.Models;
using System.Linq;

namespace Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Get();
        User Create(User user);
        User Update(User user);
    }
}
