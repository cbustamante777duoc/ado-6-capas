using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult lista()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.listarProducto(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult filtrarProductoPorNombre(string nombreProducto)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.filtrarProductos(nombreProducto), JsonRequestBehavior.AllowGet);
        }

    }
}