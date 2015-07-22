using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoGuru.Models;

namespace ProjetoGuru.Controllers
{
    public class UsuarioCreditoController : Controller
    {
        private Conexao db = new Conexao();

        // GET: UsuarioCredito
        public ActionResult Index()
        {
            var usuarioCredito = db.UsuarioCredito.Include(u => u.Usuario);
            return View(usuarioCredito.ToList());
        }

        // GET: UsuarioCredito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioCredito usuarioCredito = db.UsuarioCredito.Find(id);
            if (usuarioCredito == null)
            {
                return HttpNotFound();
            }
            return View(usuarioCredito);
        }

        // GET: UsuarioCredito/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email");
            return View();
        }

        // POST: UsuarioCredito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioCreditoID,Valor,UsuarioID,Data")] UsuarioCredito usuarioCredito)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioCredito.Add(usuarioCredito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", usuarioCredito.UsuarioID);
            return View(usuarioCredito);
        }

        // GET: UsuarioCredito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioCredito usuarioCredito = db.UsuarioCredito.Find(id);
            if (usuarioCredito == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", usuarioCredito.UsuarioID);
            return View(usuarioCredito);
        }

        // POST: UsuarioCredito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioCreditoID,Valor,UsuarioID,Data")] UsuarioCredito usuarioCredito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioCredito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", usuarioCredito.UsuarioID);
            return View(usuarioCredito);
        }

        // GET: UsuarioCredito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioCredito usuarioCredito = db.UsuarioCredito.Find(id);
            if (usuarioCredito == null)
            {
                return HttpNotFound();
            }
            return View(usuarioCredito);
        }

        // POST: UsuarioCredito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioCredito usuarioCredito = db.UsuarioCredito.Find(id);
            db.UsuarioCredito.Remove(usuarioCredito);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
