using LibraryAutomation.DataAccess.Repositories;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Business.Managers
{
    public class CategoryManager
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryManager()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<Category> GetActiveCategories()
        {
            return _categoryRepository.GetActiveCategories();
        }
        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }
        public void AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
