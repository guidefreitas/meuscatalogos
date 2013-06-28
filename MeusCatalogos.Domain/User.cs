using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class User
    {
        public User()
        {
            this.CreatedDateTime = DateTime.Now;
            this.isActive = true;
            this.isEmailConfirmed = false;
        }

        public virtual int UserId { get; set; }
        public virtual String Name { get; set; }
        public virtual String Email { get; set; }
        public virtual String PasswordDigest { get; set; }
        public virtual Company Company { get; set; }
        public byte[] Timestamp { get; set; }
        public virtual String Password { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual Boolean isActive { get; set; }
        public virtual Boolean isEmailConfirmed { get; set; }
    }
}