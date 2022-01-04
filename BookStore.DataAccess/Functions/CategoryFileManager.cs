using BookStore.Entity.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Functions
{
    public static class CategoryFileManager
    {
        public static readonly string AppPath = Path.Combine(Environment.CurrentDirectory, "BookStore");

        public static readonly string SavePath = Path.Combine(AppPath, "category.json");

        public static void CreateAppDirIfNotExists()
        {
            if (Directory.Exists(AppPath)) return;

            Directory.CreateDirectory(AppPath);
        }

        public static void CreateCategoriesFileIfNotExits()
        {
            if (File.Exists(SavePath)) return;

            CreateAppDirIfNotExists();

            List<Category> categories = new();
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(categories, Formatting.Indented));
        }

        public static List<Category> GetCategories()
        {
            CreateCategoriesFileIfNotExits();

            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(SavePath));

            return categories;
        }
        public static Category GetCategoryId(int categoryId)
        {
            CreateCategoriesFileIfNotExits();
            Category category = new();

            if (GetCategories().Count != 0)
            {
                foreach (var item in GetCategories())
                {
                    if (item.Id == categoryId)
                    {
                        category = item;
                    }
                }
            }
            else
            {

            }
            return category;
        }
        public static bool SaveCategories(Category category)
        {
            CreateCategoriesFileIfNotExits();

            var item = GetCategoryId(category.Id);
            var categories = GetCategories();

            if (item.Id == 0)
            {
                categories.Add(category);
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(categories, Formatting.Indented));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void UpdateCategory(Category category)
        {
            var categories = GetCategories();

            foreach (var item in categories)
            {
                if (item.Id == category.Id)
                {
                    item.Name = category.Name;
                }
            }

            var output = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(SavePath, output);
        }
        public static bool RemoveCategory(Category category)
        {
            CreateCategoriesFileIfNotExits();

            var item = GetCategoryId(category.Id);
            var categories = GetCategories();

            if (item.Id == 0)
            {
                return false;
            }
            else
            {
                categories.Remove(categories.Find(x => x.Id == category.Id));
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(categories, Formatting.Indented));
                }
                return true;
            }
        }
    }
}
