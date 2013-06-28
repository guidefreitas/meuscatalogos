using MeusCatalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusCatalogos.Repositories
{
    public interface IUserRepository : IBaseRepository
    {
        void Insert(User user);
        void Update(User user);
        void Delete(int userId);
        void Delete(User user);
        User FindById(int userId);
        User FindByEmail(String email);
        User FindByName(String name);
        List<User> All();
    }
}
