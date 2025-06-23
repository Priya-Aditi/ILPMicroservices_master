using Microsoft.ILP.UserRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.UserBusiness.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
