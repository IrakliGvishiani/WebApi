using Azure.Core;
using Ecommerce.API.Entities;
using Ecommerce.API.Models.CategoryDtos;
using Ecommerce.API.Models.Product;
using Ecommerce.API.Models.ProductDtos;
using Ecommerce.API.Repository;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using MapsterMapper;

namespace Ecommerce.API.Service
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        //public ProductService() { }

        public async Task<int> CreateNewProductAsync(ProductForCreatingDto model)
        {
            var newProduct = mapper.Map<Product>(model);
            await productRepository.AddAsync(newProduct);
            // Mapping ProductForCreatingDto to Product entity
            return await productRepository.SaveAsync();


        }

        public async Task<int> DeleteProductAsync(Guid ProductId)
        {
            var product =  await productRepository.GetAsync(p => p.Id == ProductId);

            if (product is null)
                return 0;
            
                productRepository.Remove(product);
               return await productRepository.SaveAsync();
            
        }

        public async Task<IEnumerable<ProductForGettingDto>> GetAllProductAsync()
        {
           var products = (await productRepository.GetAllAsync(includes: p => p.Category)).Items;

            var result = mapper.Map<IEnumerable<ProductForGettingDto>>(products);

            return result;

            //return products.Select(p => new ProductForGettingDto()
            //{
            //    Id = p.Id,
            //    ProductName = p.ProductName,
            //    Price = p.Price,
            //    Category = new CategoryForGettingDto()
            //    {
            //        Id = p.Category.Id,
            //        CategoryName = p.Category.CategoryName
            //    }
            //});
        }

        public async Task<int> UpdateProductAsync(ProductForUpdatingDto request)
        {
            var product = await productRepository.GetAsync(p => p.Id == request.Id);

            if (product is null)
                return 0;

            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.CategoryId = request.CategoryId;
            product.SupplierId = request.SupplierId;
            productRepository.Update(product);
            return await productRepository.SaveAsync();
        }
    }
}
