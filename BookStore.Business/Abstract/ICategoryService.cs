using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete;

namespace BookStore.Business.Abstract
{
    public interface ICategoryService
    {
        bool AddCategory(Category category);

        bool RemoveCategory(Category category);

        void UpdateCategory(Category categoryToUpdate);

        Category GetCategoryId(int categoryId);

        List<Category> GetCategoriesList();
    }
}
