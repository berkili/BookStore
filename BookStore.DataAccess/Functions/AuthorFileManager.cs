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
    public static class AuthorFileManager
    {
        public static readonly string AppPath = Path.Combine(Environment.CurrentDirectory, "BookStore");

        public static readonly string SavePath = Path.Combine(AppPath, "authors.json");

        public static void CreateAppDirIfNotExists()
        {
            if (Directory.Exists(AppPath)) return;

            Directory.CreateDirectory(AppPath);
        }

        public static void CreateAuthorsFileIfNotExits()
        {
            if (File.Exists(SavePath)) return;

            CreateAppDirIfNotExists();

            List<Author> authors = new();
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(authors, Formatting.Indented));
        }

        public static List<Author> GetAuthors()
        {
            CreateAuthorsFileIfNotExits();

            List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(File.ReadAllText(SavePath));

            return authors;
        }
        public static Author GetAuthorId(int authorId)
        {
            CreateAuthorsFileIfNotExits();
            Author author = new();

            if (GetAuthors().Count != 0)
            {
                foreach (var item in GetAuthors())
                {
                    if (item.Id == authorId)
                    {
                        author = item;
                    }
                }
            }
            else
            {

            }
            return author;
        }
        public static bool SaveAuthors(Author author)
        {
            CreateAuthorsFileIfNotExits();

            var item = GetAuthorId(author.Id);
            var authors = GetAuthors();

            if (item.Id == 0)
            {
                authors.Add(author);
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(authors, Formatting.Indented));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void UpdateAuthor(Author author)
        {            
            var authors = GetAuthors();

            foreach (var item in authors)
            {
                if (item.Id == author.Id)
                {
                    item.Name = author.Name;
                    item.PublisherId = author.PublisherId;
                }
            }

            var output = JsonConvert.SerializeObject(authors, Formatting.Indented);
            File.WriteAllText(SavePath, output);
        }
        public static bool RemoveAuthor(Author author)
        {
            CreateAuthorsFileIfNotExits();

            var item = GetAuthorId(author.Id);
            var authors = GetAuthors();

            if (item.Id == 0)
            {
                return false;
            }
            else
            {
                authors.Remove(authors.Find(x => x.Id == author.Id));
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(authors, Formatting.Indented));
                }
                return true;
            }
        }
    }
}
