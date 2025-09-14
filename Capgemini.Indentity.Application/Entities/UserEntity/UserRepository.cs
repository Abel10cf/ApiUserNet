using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Indentity.Application.Entities.UserEntity
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                UserName = "dansan",
                Password = "test11",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Active = false
            },

            new User
            {
                Id = 2,
                UserName = "hecjai",
                Password = "test12",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Active = false
            },

            new User
            {
                Id = 3,
                UserName = "luccon",
                Password = "test13",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Active = true
            },
            new User
            {
                Id = 4,
                UserName = "vidlui",
                Password = "test14",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Active = false
            },
            new User
            {
                Id = 5,
                UserName = "abcor",
                Password = "test15",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Active = true
            }
        };

        // Método que busca un usuario por email y password, devuelve null si no existe
        public User? GetUserByCredentials(string username, string password)
        {
            return users.FirstOrDefault(u =>
                u.UserName == username &&
                u.Password == password);
        }
    }
}