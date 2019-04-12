using TokenTracker.Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using System.Linq;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace TokenTracker.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BeyondTokenTrackerContext _context;

        public ProductRepository(BeyondTokenTrackerContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Get()
        {
            return _context.Product
                .Include(x => x.ProductGroup);
        }

        public Product Create(Product product)
        {
            var cleanProduct = RemoveProductChildren(product);
            _context.Product.Add(cleanProduct);

            return product;
        }

        public Product Update(Product product)
        {
            var cleanProduct = RemoveProductChildren(product);
            _context.Product.Update(cleanProduct);

            return product;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private Product RemoveProductChildren(Product product)
        {
            var cleanProduct = product;
            cleanProduct.ProductGroup = null;
            return cleanProduct;
        }
    }
}
