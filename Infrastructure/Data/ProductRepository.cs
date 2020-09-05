using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
           _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = _context.Products.ToList();
            foreach(var item in products)
            {
                item.ProductBrand = await _context.ProductBrands.FindAsync(item.ProductBrandId);
                item.ProductType = await _context.ProductTypes.FindAsync(item.ProductTypeId);
            }
            return products ;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
