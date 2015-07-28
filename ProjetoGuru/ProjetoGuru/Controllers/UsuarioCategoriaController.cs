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
    public class UsuarioCategoriaController : Controller
    {
        private Conexao db = new Conexao();

        // GET: UsuarioCategoria
        public ActionResult Index()
        {
            //Envia a lista completa 
            //var usuarioCategoria = db.UsuarioCategoria.Include(u => u.Categoria).Include(u => u.Usuario);
            //return View(usuarioCategoria.ToList());

            int aux = Convert.ToInt16(Session["usuarioID"]);

            List<UsuarioCategoria> x = (from u in db.UsuarioCategoria
                                       where u.UsuarioID == aux
                                       select u).ToList();
            return View(x);
        }

        // GET: UsuarioCategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioCategoria usuarioCategoria = db.UsuarioCategoria.Find(id);
            if (usuarioCategoria == null)
            {
                return HttpNotFound();
            }
            return View(usuarioCategoria);
        }

        // GET: UsuarioCategoria/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email");
            return View();
        }

        // POST: UsuarioCategoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioCategoriaID,UsuarioID,CategoriaID")] UsuarioCategoria usuarioCategoria)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioCategoria.Add(usuarioCategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", usuarioCategoria.CategoriaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", usuarioCategoria.UsuarioID);
            return View(usuarioCategoria);
        }

        // GET: UsuarioCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioCategoria usuarioCategoria = db.UsuarioCategoria.Find(id);
            if (usuarioCategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", usuarioCategoria.CategoriaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", usuarioCategoria.UsuarioID);
            return View(usuarioCategoria);
        }

        // POST: UsuarioCategoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioCategoriaID,UsuarioID,CategoriaID")] UsuarioCategoria usuarioCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", usuarioCategoria.CategoriaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", usuarioCategoria.UsuarioID);
            return View(usuarioCategoria);
        }

        // GET: UsuarioCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioCategoria usuarioCategoria = db.UsuarioCategoria.Find(id);
            if (usuarioCategoria == null)
            {
                return HttpNotFound();
            }
            return View(usuarioCategoria);
        }

        // POST: UsuarioCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioCategoria usuarioCategoria = db.UsuarioCategoria.Find(id);
            db.UsuarioCategoria.Remove(usuarioCategoria);
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
