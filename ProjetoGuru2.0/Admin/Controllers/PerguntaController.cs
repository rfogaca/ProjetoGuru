﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class PerguntaController : Controller
    {
        // GET: Pergunta
        public ActionResult Index()
        {
            return View();
        }
    }
}