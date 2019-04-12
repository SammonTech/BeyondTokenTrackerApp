using System.Linq;
using TokenTracker.Domain.Entities.Dtos;
using TokenTracker.Domain.Entities.Models;

namespace Domain.Services.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();
        IQueryable<Product> GetRedeemableProducts();
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        void SaveChanges();
    }
}
