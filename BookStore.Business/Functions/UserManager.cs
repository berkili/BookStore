using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Business.Abstract;
using BookStore.Entity.Concrete;
using BookStore.DataAccess.Functions;
using System.Threading.Tasks;

namespace BookStore.Business.Functions
{
    public class UserManager : IUserService
    {
        public List<User> users = new();
        public bool AddUser(User user)
        {
            int userId = GetUsersList().Select(x => x.Id).LastOrDefault();
            user.Id = userId == 0 ? 1 : userId + 1;
            var status = UserFileManager.SaveUsers(user);
            return status;
        }

        public User GetUserId(int userId)
        {
            return UserFileManager.GetUserId(userId);
        }

        public List<User> GetUsersList()
        {
            return users = UserFileManager.GetUsers();
        }

        public bool RemoveUser(User user)
        {
            var status = UserFileManager.RemoveUser(user);
            return status;
        }

        public void UpdateUser(User userToUpdate)
        {
            UserFileManager.UpdateUser(userToUpdate);
        }
    }
}
