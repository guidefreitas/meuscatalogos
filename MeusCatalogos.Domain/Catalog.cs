using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class Catalog
    {
        public Catalog()
        {
            this.CreatedDateTime = DateTime.Now;
            this.isPrivate = false;
            if (this.Itens == null)
            {
                this.Itens = new List<CatalogItem>();
            }
        }
        private ICollection<CatalogItem> _itens;

        public virtual int CatalogId { get; set; }
        public virtual String Name { get; set; }
        public virtual ICollection<CatalogItem> Itens
        {
            get { return _itens ?? (_itens = new List<CatalogItem>()); }
            protected set { _itens = value; }
        }
        public virtual CatalogCategory Category { get; set; }
        public virtual Company Company { get; set; }
        public virtual User UserCreated { get; set; }
        public virtual Image ImageCover { get; set; }
        public virtual bool isPrivate { get; set; }
        public virtual byte[] Timestamp { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
    }
}