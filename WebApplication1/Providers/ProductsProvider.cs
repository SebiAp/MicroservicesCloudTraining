using AutoMapper;
using Centric.eCommerce.Product.API.DB;
using Centric.eCommerce.Product.API.Infrastructure;
using Centric.eCommerce.Product.API.Interfaces;
using Centric.eCommerce.Product.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Centric.eCommerce.Product.API.Providers
{
    public class ProductsProvider: IProductsProvider
    {
        private readonly ProductsDbContext _context;
        private readonly ILogger<ProductsProvider> _logger;
        private readonly IMapper _mapper;

        public ProductsProvider(ProductsDbContext context, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _context.SeedProducts();
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductModel> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                if (products != null && products.Any())
                {
                    var result = _mapper.Map<IEnumerable<ProductModel>>(products);
                    return (true, result, null);
                }

                return (false, null, "Not found!");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, ProductModel Product, string ErrorMessage)> GetProductAsync(Guid id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    var result = _mapper.Map<ProductModel>(product);
                    return (true, result, null);
                }

                return (false, null, "Not found!");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
