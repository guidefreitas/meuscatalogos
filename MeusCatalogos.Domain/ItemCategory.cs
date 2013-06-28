using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class ItemCategory
    {
        public ItemCategory()
        {
            this.CreatedDateTime = DateTime.Now;
        }
        private ICollection<CatalogItem> _itens;

        public virtual int CategoryId { get; set; }
        public virtual ICollection<CatalogItem> Itens
        {
            get { return _itens ?? (_itens = new List<CatalogItem>()); }
            protected set { _itens = value; }
        }
        public virtual String Name { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual Catalog Catalog { get; set; }
        public virtual byte[] Timestamp { get; set; }
    }
}