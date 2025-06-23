using Microsoft.ILP.UserRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.UserRepository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
