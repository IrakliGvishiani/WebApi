using Azure.Core;
using Ecommerce.API.Entities;
using Ecommerce.API.Exceptions;
using Ecommerce.API.Models.CategoryDtos;
using Ecommerce.API.Models.Product;
using Ecommerce.API.Models.ProductDtos;
using Ecommerce.API.Repository;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Service
{
    public class ProductService(IProductRepository productRepository, IMapper mapper
        , ISupplierRepository supplierRepository,
        ICategoryRepository categoryRepository
        ) : IProductService
    {
        //public ProductService() { }

        public async Task<int> CreateNewProductAsync(ProductForCreatingDto model)
        {
            if(model is null) throw new BadRequestException("Request model required!");

            if (model.ProductName.Length > 100) throw new BadRequestException("Product Name Length Can't Exceed 100!");

            if (model.Price < 0) throw new BadRequestException("Product Price Can't be Negative Number");

            if (model.Quantity < 0) throw new BadRequestException("Product Price Can't be Negative Number");

            if (model.CategoryId == Guid.Empty) throw new BadRequestException("Product Category Is Required");

            if (model.SupplierId == Guid.Empty) throw new BadRequestException("Product Supplier Is Required");

            if (!await CategoryExists(model.CategoryId)) throw new BadRequestException("Category Not Found!");

            if (!await SupplierExists(model.SupplierId)) throw new BadRequestException("Supplier Not Found!");


            var newProduct = mapper.Map<Product>(model);
            await productRepository.AddAsync(newProduct);
            // Mapping ProductForCreatingDto to Product entity
            return await productRepository.SaveAsync();


        }

        public async Task<int> DeleteProductAsync(Guid ProductId)
        {
            var product =  await productRepository.GetAsync(p => p.Id == ProductId);

            if (product is null)
                throw new NotFoundException($"Product With Id {ProductId} Not Found!");
            
                productRepository.Remove(product);
               return await productRepository.SaveAsync();
            
        }

        public async Task<IEnumerable<ProductListForGettingDto>> GetAllProductAsync()
        {
           var products = (await productRepository.GetAllAsync()).Items;

            var result = mapper.Map<IEnumerable<ProductListForGettingDto>>(products);

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

        public async Task<ProductForGettingDto> GetProductAsync(Guid Id)
        {
            if(Id == Guid.Empty)
            {
                throw new BadRequestException("Product Id Required!");
            }

            var product = await productRepository.GetAsync(
                filter: p => p.Id == Id,
                include: p => p.Include(p => p.Category)
                .Include(p => p.Supplier)
                );

            if (product is null)
                throw new NotFoundException($"Product With Id {Id} Not Found!");


            var result = mapper.Map<ProductForGettingDto>(product);
            return result;
        }

        public async Task<int> UpdateProductAsync(ProductForUpdatingDto request)
        {
            if(request is null)
                throw new BadRequestException("Product is required!");

            if(request.Id == Guid.Empty) throw new BadRequestException("Id Required");
            var product = await productRepository.GetAsync(p => p.Id == request.Id);

            if (product is null)
                throw new BadRequestException($"Product With Id {request.Id} Not Found!");

            if (request.ProductName.Length > 100) throw new BadRequestException("Product Name Length Can't Exceed 100!");

            if (request.Price < 0) throw new BadRequestException("Product Price Can't be Negative Number");

            if (request.Quantity < 0) throw new BadRequestException("Product Price Can't be Negative Number");

            if (request.CategoryId == Guid.Empty) throw new BadRequestException("Product Category Is Required");

            if (request.SupplierId == Guid.Empty) throw new BadRequestException("Product Supplier Is Required");

            if (!await CategoryExists(request.CategoryId)) throw new BadRequestException("Category Not Found!");

            if (!await SupplierExists(request.SupplierId)) throw new BadRequestException("Supplier Not Found!");

            mapper.Map(request,product);

            //product.ProductName = request.ProductName;
            //product.Price = request.Price;
            //product.Quantity = request.Quantity;
            //product.CategoryId = request.CategoryId;
            //product.SupplierId = request.SupplierId;
            productRepository.Update(product);
            return await productRepository.SaveAsync();
        }


        private async Task<bool> CategoryExists(Guid categoryId)
        {
            return await categoryRepository.ExistsAsync(p => p.Id == categoryId);
        }


        private async Task<bool> SupplierExists (Guid supplierId)
        {
            return await supplierRepository.ExistsAsync(s => s.Id == supplierId);
        }
    }
}
