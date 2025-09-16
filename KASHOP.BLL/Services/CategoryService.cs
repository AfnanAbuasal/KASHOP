using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return _categoryRepository.Add(category);
        }

        public int DeleteCategory(int ID)
        {
            var category = _categoryRepository.GetByID(ID);
            if (category is null) return 0;
            return _categoryRepository.Delete(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponse>>();
        }

        public CategoryResponse? GetCategoryByID(int ID)
        {
            var category = _categoryRepository.GetByID(ID);
            return category is null ? null : category.Adapt<CategoryResponse>();
        }

        public bool ToggleStatus(int ID)
        {
            var category = _categoryRepository.GetByID(ID);
            if (category is null) return false;
            category.Status = category.Status == Status.Active ? Status.Inactive : Status.Active;
            _categoryRepository.Update(category);
            return true;
        }

        public int UpdateCategory(int ID, CategoryRequest request)
        {
            var category = _categoryRepository.GetByID(ID);
            if (category is null) return 0;
            category.Name = request.Name;
            return _categoryRepository.Update(category);
        }
    }
}
