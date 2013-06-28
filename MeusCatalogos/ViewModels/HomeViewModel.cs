using MeusCatalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeusCatalogos.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.Categories = new List<CatalogCategory>();
        }
        public String PageTitle { get; set; }
        public List<CatalogCategory> Categories { get; set; }
    }
}