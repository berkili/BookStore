using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.Abstract;
using BookStore.DataAccess.Functions;
using BookStore.Entity.Concrete;

namespace BookStore.Business.Functions
{
    public class AuthorManager : IAuthorService
    {
        public List<Author> authors = new();
        public bool AddAuthor(Author author)
        {
            int authorId = GetAuthorsList().Select(x => x.Id).LastOrDefault();
            author.Id = authorId == null ? 0 : authorId + 1;
            var status = AuthorFileManager.SaveAuthors(author);
            return status;
        }

        public Author GetAuthorId(int authorId)
        {
            return AuthorFileManager.GetAuthorId(authorId);
        }

        public List<Author> GetAuthorsList()
        {
            return authors = AuthorFileManager.GetAuthors();
        }

        public bool RemoveAuthor(Author author)
        {
            var status = AuthorFileManager.RemoveAuthor(author);
            return status;
        }

        public void UpdateAuthor(Author authorToUpdate)
        {
            AuthorFileManager.UpdateAuthor(authorToUpdate);
        }
    }
}
