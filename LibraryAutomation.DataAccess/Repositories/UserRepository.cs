using LibraryAutomation.DataAccess.Context;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryAutomation.DataAccess.Repositories
{
    public class UserRepository 
    {
        public List<User> GetAll()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Users.ToList();

            }

        }

        public User GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public void Add(User user)
        {
            using (var context = new LibraryDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (var context = new LibraryDbContext())
            {
                var oldData = context.Users.FirstOrDefault(u => u.Id == user.Id);
                if (oldData != null)
                {
                    oldData.Username = user.Username;
                    oldData.Password = user.Password;
                    oldData.FullName = user.FullName;
                    oldData.Email = user.Email;
                    oldData.Role = user.Role;
                    oldData.IsActive = user.IsActive;
                    context.SaveChanges();
                }
            }
        }

        public bool Delete(int id)
        {
            using (var context = new LibraryDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public User Login(string username, string password)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Users
                    .FirstOrDefault(x =>
                        x.Username == username &&
                        x.Password == password &&
                        x.IsActive);
            }
        }


    }
}
