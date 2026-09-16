using LibraryAutomation.DataAccess.Context;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.DataAccess.Repositories
{
    public class CategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Categories.FirstOrDefault(c => c.Id == categoryId);
            }
        }

        public void AddCategory(Category category)
        {
            using (var context = new LibraryDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new LibraryDbContext())
            {
                var existingCategory = context.Categories
                    .FirstOrDefault(c => c.Id == category.Id);

                if (existingCategory != null)
                {
                    existingCategory.Name = category.Name;
                    existingCategory.Description = category.Description;
                    existingCategory.IsActive = category.IsActive;

                    context.SaveChanges();
                }
            }
        }
        

        public void DeleteCategory(int categoryId)
        {
            using (var context = new LibraryDbContext())
            {
                var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                if (category != null)
                {
                    category.IsActive = false;
                    context.SaveChanges();
                }
            }
        }

        public List<Category> GetActiveCategories()
        {
            using (var context = new LibraryDbContext())
            return context.Categories.Where(x =>  x.IsActive).ToList();
        }
    }
}
