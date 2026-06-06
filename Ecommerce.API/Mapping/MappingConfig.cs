using Ecommerce.API.Entities;
using Ecommerce.API.Models.CategoryDtos;
using Ecommerce.API.Models.Product;
using Ecommerce.API.Models.ProductDtos;
using Ecommerce.API.Models.SupplierDtos;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //// PRODUCT MAPPING
           config.NewConfig<ProductForCreatingDto, Product>();
           config.NewConfig<Product, ProductForGettingDto>();
           config.NewConfig<ProductForUpdatingDto, Product>();


            //// CATEGORY MAPPING
            config.NewConfig<Category, CategoryForGettingDto>();
            config.NewConfig<CategoryForCreatingDto, Category>();
            config.NewConfig<CategoryForUpdatingDto, Category>();

            //// SUPPLIER MAPPING
            //config.NewConfig<Supplier, SupplierForGettingDto>();
            config.NewConfig<SupplierForCreatingDto, Supplier>();
            config.NewConfig<SupplierForUpdatingDto, Supplier>();
        }
    }
}
