using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.Abstract;
using BookStore.Entity.Concrete;
using BookStore.DataAccess.Functions;

namespace BookStore.Business.Functions
{
    public class CategoryManager : ICategoryService
    {
        public List<Category> categories = new();
        public bool AddCategory(Category category)
        {
            int categoryId = GetCategoriesList().Select(x => x.Id).LastOrDefault();
            category.Id = categoryId == null ? 0 : categoryId + 1;
            var status = CategoryFileManager.SaveCategories(category);
            return status;
        }

        public List<Category> GetCategoriesList()
        {
            return categories = CategoryFileManager.GetCategories();
        }

        public Category GetCategoryId(int categoryId)
        {
            return CategoryFileManager.GetCategoryId(categoryId);
        }

        public bool RemoveCategory(Category category)
        {
            var status = CategoryFileManager.RemoveCategory(category);
            return status;
        }

        public void UpdateCategory(Category categoryToUpdate)
        {
            CategoryFileManager.UpdateCategory(categoryToUpdate);
        }
    }
}
