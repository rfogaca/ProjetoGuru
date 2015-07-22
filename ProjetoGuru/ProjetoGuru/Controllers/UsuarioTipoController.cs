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
    public class UsuarioTipoController : Controller
    {
        private Conexao db = new Conexao();

        // GET: UsuarioTipo
        public ActionResult Index()
        {
            return View(db.UsuarioTipo.ToList());
        }

        // GET: UsuarioTipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioTipo usuarioTipo = db.UsuarioTipo.Find(id);
            if (usuarioTipo == null)
            {
                return HttpNotFound();
            }
            return View(usuarioTipo);
        }

        // GET: UsuarioTipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioTipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioTipoID,Tipo")] UsuarioTipo usuarioTipo)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioTipo.Add(usuarioTipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioTipo);
        }

        // GET: UsuarioTipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioTipo usuarioTipo = db.UsuarioTipo.Find(id);
            if (usuarioTipo == null)
            {
                return HttpNotFound();
            }
            return View(usuarioTipo);
        }

        // POST: UsuarioTipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioTipoID,Tipo")] UsuarioTipo usuarioTipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioTipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarioTipo);
        }

        // GET: UsuarioTipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioTipo usuarioTipo = db.UsuarioTipo.Find(id);
            if (usuarioTipo == null)
            {
                return HttpNotFound();
            }
            return View(usuarioTipo);
        }

        // POST: UsuarioTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioTipo usuarioTipo = db.UsuarioTipo.Find(id);
            db.UsuarioTipo.Remove(usuarioTipo);
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
