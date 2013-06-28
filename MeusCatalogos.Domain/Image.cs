using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class Image
    {
        public Image()
        {
            this.CreatedDateTime = DateTime.Now;
            this.ImageId = System.Guid.NewGuid();
        }
        public virtual Guid ImageId { get; set; }
        public virtual String Url { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
    }
}