using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeusCatalogos.Controllers
{
    public partial class CatalogsController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Detail(int id)
        {
            return View();
        }

    }
}
