using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class Company
    {
        public Company()
        {
            this.CreatedDateTime = DateTime.Now;
        }

        public virtual int CompanyId { get; set; }
        public virtual String Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
    }
}