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
    public class BookManager : IBookService
    {
        public List<Book> books = new();
        public bool AddBook(Book book)
        {
            var status = BookFileManager.SaveBooks(book);
            return status;
        }

        public Book GetBookId(long bookId)
        {
            return BookFileManager.GetBookId(bookId);
        }

        public List<Book> GetBooksList()
        {
            return books = BookFileManager.GetBooks();
        }

        public bool RemoveBook(Book book)
        {
            var status = BookFileManager.RemoveBook(book);
            return status;
        }

        public void UpdateBook(Book bookToUpdate)
        {
            BookFileManager.UpdateBook(bookToUpdate);
        }
    }
}
