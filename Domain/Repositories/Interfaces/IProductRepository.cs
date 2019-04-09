using Domain.Entities.Models;
using System.Linq;

namespace Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Get();
        Product Create(Product product);
        Product Update(Product product);
        void SaveChanges();
    }
}
