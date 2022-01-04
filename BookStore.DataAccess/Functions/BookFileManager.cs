using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookStore.Entity.Concrete;

namespace BookStore.DataAccess.Functions
{
    public static class BookFileManager 
    {
        public static readonly string AppPath = Path.Combine(Environment.CurrentDirectory, "BookStore");

        public static readonly string SavePath = Path.Combine(AppPath, "books.json");

        public static void CreateAppDirIfNotExists()
        {
            if (Directory.Exists(AppPath)) return;

            Directory.CreateDirectory(AppPath);
        }
        public static void CreateBooksFileIfNotExits()
        {
            if (File.Exists(SavePath)) return;

            CreateAppDirIfNotExists();

            List<Book> books = new();
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(books, Formatting.Indented));
        }
        public static List<Book> GetBooks()
        {
            CreateBooksFileIfNotExits();

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(SavePath));

            return books;
        }
        public static Book GetBookId(long bookId)
        {
            CreateBooksFileIfNotExits();
            Book book = new();

            if (GetBooks().Count != 0)
            {
                foreach (var item in GetBooks())
                {
                    if (item.ISBN == bookId)
                    {
                        book = item;
                    }
                }
            }
            else
            {

            }            
            return book;
        }
        public static bool SaveBooks(Book book) 
        {
            CreateBooksFileIfNotExits();

            var item = GetBookId(book.ISBN);
            var books = GetBooks();

            if(item.ISBN == 0)
            {
                books.Add(book);
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(books, Formatting.Indented));                    
                }
                return true;
            }
            else
            {
                return false;
            }            
        }
        public static void UpdateBook(Book book)
        {            
            var books = GetBooks();

            foreach(var item in books)
            {
                if (item.ISBN == book.ISBN)
                {
                    item.PublicationDate = book.PublicationDate;
                    item.Description = book.Description;
                    item.PurchasePrice = book.PurchasePrice;
                    item.SalePrice = book.SalePrice;
                    item.AuthorId = book.AuthorId;
                    item.CategoryId = book.CategoryId;
                    item.PublisherId = book.PublisherId;
                    item.TotalStock = book.TotalStock;
                }
            }

            var output = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(SavePath, output);
        }
        public static bool RemoveBook(Book book)
        {
            CreateBooksFileIfNotExits();

            var item = GetBookId(book.ISBN);
            var books = GetBooks();

            if (item.ISBN == 0)
            {
                return false;
            }
            else
            {
                books.Remove(books.Find(x => x.ISBN == book.ISBN));
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(books, Formatting.Indented));
                }
                return true;
            }
        }
    }
}
