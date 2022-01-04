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
    public static class UserFileManager
    {
        public static readonly string AppPath = Path.Combine(Environment.CurrentDirectory, "BookStore");

        public static readonly string SavePath = Path.Combine(AppPath, "users.json");

        public static void CreateAppDirIfNotExists()
        {
            if (Directory.Exists(AppPath)) return;

            Directory.CreateDirectory(AppPath);
        }

        public static void CreateUsersFileIfNotExits()
        {
            if (File.Exists(SavePath)) return;

            CreateAppDirIfNotExists();

            List<User> users = new();
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(users, Formatting.Indented));
        }

        public static List<User> GetUsers()
        {
            CreateUsersFileIfNotExits();

            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(SavePath));

            return users;
        }
        public static User GetUserId(int userId)
        {
            CreateUsersFileIfNotExits();
            User user = new();

            if (GetUsers().Count != 0)
            {
                foreach (var item in GetUsers())
                {
                    if (item.Id == userId)
                    {
                        user = item;
                    }
                }
            }
            else
            {

            }
            return user;
        }
        public static bool SaveUsers(User user)
        {
            CreateUsersFileIfNotExits();

            var item = GetUserId(user.Id);
            var users = GetUsers();

            if (item.Id != user.Id)
            {
                users.Add(user);
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(users, Formatting.Indented));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void UpdateUser(User user)
        {
            var users = GetUsers();

            foreach (var item in users)
            {
                if (item.Id == user.Id)
                {
                    item.UserName = user.UserName;
                    item.MailAdress = user.MailAdress;
                    item.PhoneNumber = user.PhoneNumber;
                }
            }

            var output = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(SavePath, output);
        }
        public static bool RemoveUser(User user)
        {
            CreateUsersFileIfNotExits();

            var item = GetUserId(user.Id);
            List<User> users = GetUsers();

            if (item.Id != user.Id)
            {
                return false;
            }
            else
            {
                var a = users.Remove(users.Find(x => x.Id == user.Id));
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(users, Formatting.Indented));
                }
                return true;
            }
        }
    }
}
