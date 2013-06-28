using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class CatalogCategory
    {
        public CatalogCategory()
        {
            this.CreatedDateTime = DateTime.Now;
        }
        private ICollection<Catalog> _catalogs;

        public virtual int CategoryId { get; set; }
        public virtual ICollection<Catalog> Catalogs
        {
            get { return _catalogs ?? (_catalogs = new List<Catalog>()); }
            protected set { _catalogs = value; }
        }
        public virtual String Name { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual byte[] Timestamp { get; set; }
    }
}