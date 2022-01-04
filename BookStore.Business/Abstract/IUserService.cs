using BookStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Abstract
{
    public interface IUserService
    {

        bool AddUser(User user);

        bool RemoveUser(User user);

        void UpdateUser(User userToUpdate);

        User GetUserId(int userId);

        List<User> GetUsersList();
    }
}
