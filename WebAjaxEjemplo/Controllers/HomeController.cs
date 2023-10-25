using DatosMascotas;
using DatosMascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAjaxEjemplo.Controllers
{
    public class HomeController : Controller
    {
        DBMascotas m = new DBMascotas();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            try
            {
                List<Mascotas> lista = m.Obtener();
                return Json( new {mensaje = "ok", ls = lista}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {mensaje = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerPorId(int id)
        {
            try
            {
                Mascotas mascota  = m.Obtener(id);
                return Json(new { mensaje = "ok", mascota = mascota}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Agregar(Mascotas mascota)
        {
            try
            {
                m.Agregar(mascota);
                return Json( new {mensaje = "ok"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BorrarDeServidor(int id)
        {
            try
            {
                m.Borrar(id);
                return Json(new { mensaje = "ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Editar(Mascotas mascota)
        {
            try
            {
                m.Editar(mascota);
                return Json(new { mensaje = "ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}