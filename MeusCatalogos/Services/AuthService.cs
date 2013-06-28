using MeusCatalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Services
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
            : base()
        {
        }

        public UnauthorizedException(String message) : base(message) { }
    }
    public class AuthService
    {
        public User Login(String email, String password)
        {

            throw new UnauthorizedException();
        }
    }
}