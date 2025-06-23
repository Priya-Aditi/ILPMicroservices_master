using Microsoft.ILP.UserBusiness.Interfaces;
using Microsoft.ILP.UserRepository;
using Microsoft.ILP.UserRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.UserBusiness.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateUser(User user)
        {
            _repository.Create(user);
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }
    }
}
