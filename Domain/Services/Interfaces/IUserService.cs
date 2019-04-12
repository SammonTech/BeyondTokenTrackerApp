using System.Collections.Generic;
using System.Linq;
using TokenTracker.Domain.Entities.Dtos;
using TokenTracker.Domain.Entities.Models;

namespace Domain.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        List<User> NamelyUpdate(List<NamelyUpdateSvm> users);
        void SaveChanges();
    }
}
