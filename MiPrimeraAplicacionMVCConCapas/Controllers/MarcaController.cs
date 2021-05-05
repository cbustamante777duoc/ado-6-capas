using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarMarca() 
        {
            MarcaBL marcaBL = new MarcaBL();
            return Json(marcaBL.listarMarca2(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FiltrarMarca(string nombre)
        {
            MarcaBL marcaBL = new MarcaBL();
            return Json(marcaBL.filtrarMarca(nombre), JsonRequestBehavior.AllowGet);
        }


        public JsonResult recuperarMarca(int id)
        {
            MarcaBL marcaBL = new MarcaBL();
            return Json(marcaBL.recuperarMarca(id), JsonRequestBehavior.AllowGet);
        }

        public int eliminarMarca(int iidMarca) 
        {
            MarcaBL marcaBL = new MarcaBL();
            return marcaBL.eliminarMarca(iidMarca);
        }

        public int guardarMarca(MarcaCLS oMarcaCLS) 
        {
            MarcaBL marcaBL = new MarcaBL();
            return marcaBL.guardarMarca(oMarcaCLS);
        }

    }
}