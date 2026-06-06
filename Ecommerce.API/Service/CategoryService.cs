using Ecommerce.API.Entities;
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
            var category = await categoryRepository.GetAsync(p => p.Id == model.Id);

            if (category is null)
                return 0;

            category.CategoryName = model.CategoryName;

            return await categoryRepository.SaveAsync();
        }

        public async Task<int> DeleteCategoryAsync(Guid Id)
        {
            var category = await categoryRepository.GetAsync(p => p.Id == Id);

            if (category is null) return 0;

             categoryRepository.Remove(category);
           return await categoryRepository.SaveAsync();
        }
    }
}
