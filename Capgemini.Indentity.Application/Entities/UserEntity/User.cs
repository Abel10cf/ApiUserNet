using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Indentity.Application.Entities.UserEntity
{
    public class User
    {

        private List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                UserName = "dansan",
                Password = "test11",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Active = true
            },

            new User
            {
                Id = 2,
                UserName = "hecjai",
                Password = "test12",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Active = false
            }
        };

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

    }
}
