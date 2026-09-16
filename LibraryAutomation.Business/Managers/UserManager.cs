using LibraryAutomation.DataAccess.Repositories;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Business.Managers
{
    public class UserManager
    {
        private readonly UserRepository _userRepository;
        public UserManager()
        {
            _userRepository = new UserRepository();
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
        public bool DeleteUser(int id)
        {
            return _userRepository.Delete(id);
        }
        public User Login(string username, string password)
        {
            return _userRepository.Login(username, password);
        }
    }
}
