using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLaboratorio21.Utilerias;
using System.Data;
using System.Data.SqlClient;

namespace MVCLaboratorio21.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            ViewData["data"] = BaseHelper.ejecutarConsulta("select * from video", CommandType.Text);
            return View();

        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int idVideo,
            string titulo,
            int repro,
            string url)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));
            Parametros.Add(new SqlParameter("@tittle", titulo));
            Parametros.Add(new SqlParameter("@rep", repro));
            Parametros.Add(new SqlParameter("@url", url));
            BaseHelper.ejecutarSentencia("AddVideo", CommandType.StoredProcedure, Parametros);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Edit(int idVideo,
            string titulo,
            int repro,
            string url)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));
            Parametros.Add(new SqlParameter("@tittle", titulo));
            Parametros.Add(new SqlParameter("@rep", repro));
            Parametros.Add(new SqlParameter("@url", url));
            BaseHelper.ejecutarSentencia("EditVideo", CommandType.StoredProcedure, Parametros);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Delete(int idVideo)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));

            BaseHelper.ejecutarSentencia("DeleteVideo", CommandType.StoredProcedure, Parametros);
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Search(int idVideo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            ViewData["data"] = BaseHelper.ejecutarConsulta("SearchVideo", CommandType.StoredProcedure, parametros);
            return View("Resultado");
        }


    }
}

