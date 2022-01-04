using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete;

namespace BookStore.Business.Abstract
{
    public interface IBookService
    {
        bool AddBook(Book book);

        bool RemoveBook(Book book);

        void UpdateBook(Book bookToUpdate);

        Book GetBookId(long bookId);

        List<Book> GetBooksList();
    }
}
