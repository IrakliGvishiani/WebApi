using Azure.Core;
using Ecommerce.API.Entities;
using Ecommerce.API.Exceptions;
using Ecommerce.API.Models.CategoryDtos;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using MapsterMapper;

namespace Ecommerce.API.Service
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper Mapper) : ICategoryService
    {
        public async Task<int> CreateNewCategoryAsync(CategoryForCreatingDto model)
        {
            if (model is null) throw new BadRequestException("Request model required!");

            if (model.CategoryName.Length > 100) throw new BadRequestException("Product Name Length Can't Exceed 100!");

            var newCategory = Mapper.Map<Category>(model);
            await categoryRepository.AddAsync(newCategory);
            return await categoryRepository.SaveAsync();
        }

        public async Task<IEnumerable<CategoryForGettingDto>> GetAllCategoryAsync()
        {
            

            var categories = (await categoryRepository.GetAllAsync()).Items;

            var mapper = Mapper.Map<IEnumerable<CategoryForGettingDto>>(categories);

            return mapper;

            //return categories.Select(c => new CategoryForGettingDto()
            //{
            //    Id = c.Id,
            //    CategoryName = c.CategoryName
            //});

        }

        public async Task<int> UpdateCategoryAsync(CategoryForUpdatingDto model)
        {

            if (model is null) throw new BadRequestException("Request model required!");

            if (model.Id == Guid.Empty) throw new BadRequestException("Id Required");



            var category = await categoryRepository.GetAsync(p => p.Id == model.Id);

            if (category is null)
                throw new NotFoundException($"Category With Id {model.Id} Not Found!");

            category.CategoryName = model.CategoryName;

            return await categoryRepository.SaveAsync();
        }

        public async Task<int> DeleteCategoryAsync(Guid Id)
        {
            if (Id == Guid.Empty) throw new BadRequestException("Id Required");


            var category = await categoryRepository.GetAsync(p => p.Id == Id);

            if (category is null) throw new NotFoundException($"Category With Id {Id} Not Found!");

             categoryRepository.Remove(category);
           return await categoryRepository.SaveAsync();
        }
    }
}
