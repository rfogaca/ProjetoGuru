using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuruDataModel;
using GuruBO;

namespace Admin.Areas.Administrador.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaBO bo = new CategoriaBO();
		//
		// GET: /Administrador/Categoria/
		public ActionResult Index()
		{

			return View();
		}
    }
}
