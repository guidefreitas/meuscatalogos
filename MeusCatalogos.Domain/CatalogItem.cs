using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class CatalogItem
    {
        public CatalogItem()
        {
            this.CreatedDateTime = DateTime.Now;
        }
        public virtual int ItemId { get; set; }
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual Decimal Price { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
        public virtual Image ImageCover { get; set; }
        public virtual ItemCategory Category { get; set; }
        public virtual byte[] Timestamp { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
    }
}