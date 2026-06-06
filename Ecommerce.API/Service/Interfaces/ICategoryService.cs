using Ecommerce.API.Models.CategoryDtos;

namespace Ecommerce.API.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryForGettingDto>> GetAllCategoryAsync();

        Task<int> CreateNewCategoryAsync(CategoryForCreatingDto model);

        Task<int> UpdateCategoryAsync(CategoryForUpdatingDto model);

        Task<int> DeleteCategoryAsync(Guid Id);
    }
}
