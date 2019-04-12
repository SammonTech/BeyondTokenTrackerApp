using System.Linq;
using TokenTracker.Domain.Entities;
using TokenTracker.Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        #region Members

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        public IQueryable<Product> GetProducts()
        {
            return _productRepository.Get();
        }

        public IQueryable<Product> GetRedeemableProducts()
        {
            return _productRepository.Get().Where(x => x.ProductGroupId != (int)ProductGroups.NonRedeemable);
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.Create(product);
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }

        public void SaveChanges()
        {
            _productRepository.SaveChanges();
        }
    }
}
