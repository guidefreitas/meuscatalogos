using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusCatalogos.Repositories
{
    public interface IBaseRepository
    {
        void SaveChanges();
        void Discard();
    }
}
