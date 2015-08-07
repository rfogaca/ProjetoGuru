using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuruDataModel;
using GuruBO;

namespace Admin.Controllers
{
    public class CategoriaController : Controller
    {	
		CategoriaBO bo = new CategoriaBO();
        // GET: Categoria
        public ActionResult Index()
        {
			
			return View();
        }
    }
}