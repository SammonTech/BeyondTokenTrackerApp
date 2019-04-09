using System.Linq;
using Domain.Entities.Dtos;
using Domain.Entities.Models;

namespace Domain.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
    }
}
