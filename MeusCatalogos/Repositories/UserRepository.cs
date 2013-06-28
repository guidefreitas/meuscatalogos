using MeusCatalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository() : base() { }

        public void Insert(Models.User user)
        {
            dbcontext.Users.Add(user);
        }

        public void Update(User user)
        {
            dbcontext.Users.Attach(user);
            dbcontext.Entry(user).State = System.Data.EntityState.Modified;
        }

        public void Delete(Models.User user)
        {
            dbcontext.Entry(user).State = System.Data.EntityState.Deleted;
        }

        public void Delete(int userId)
        {
            User userdb = dbcontext.Users.Where(x => x.UserId == userId).First();
            Delete(userdb);
        }

        public User FindById(int userId)
        {
            return dbcontext.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public User FindByEmail(string email)
        {
            return dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User FindByName(string name)
        {
            return dbcontext.Users.Where(x => x.Name == name).FirstOrDefault();
        }



        public List<User> All()
        {
            return dbcontext.Users.ToList<User>();
        }
    }
}