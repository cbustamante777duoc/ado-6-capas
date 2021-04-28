using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class CamaController : Controller
    {
        // GET: Cama
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarCama() 
        {
            CamaBL oCamaBL = new CamaBL();
            return Json( oCamaBL.listarCama(),JsonRequestBehavior.AllowGet);
        
        }

        public JsonResult FiltrarCama(string nombre)
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.FiltrarCama(nombre), JsonRequestBehavior.AllowGet);

        }
    }
}