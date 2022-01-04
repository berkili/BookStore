using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete;

namespace BookStore.Business.Abstract
{
    public interface IAuthorService
    {
        bool AddAuthor(Author author);

        bool RemoveAuthor(Author author);

        void UpdateAuthor(Author authorToUpdate);

        Author GetAuthorId(int authorId);

        List<Author> GetAuthorsList();
    }
}
