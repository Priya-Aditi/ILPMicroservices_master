using Microsoft.ILP.UserRepository.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Microsoft.ILP.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private const string FilePath = "UserData/users.json";

        public List<User> GetAll()
        {
            if (!File.Exists(FilePath)) return new List<User>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(u => u.Id == id);
        }

        public void Create(User user)
        {
            var users = GetAll();
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            Save(users);
        }

        public void Update(User user)
        {
            var users = GetAll();
            var index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                users[index] = user;
                Save(users);
            }
        }

        public void Delete(int id)
        {
            var users = GetAll();
            users.RemoveAll(u => u.Id == id);
            Save(users);
        }

        private void Save(List<User> users)
        {
            Directory.CreateDirectory("UserData");
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
