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
    public class PerguntaController : Controller
    {
        private Conexao db = new Conexao();

        // GET: Pergunta
        public ActionResult Index()
        {
            ViewBag.Barra = " | ";
            var pergunta = db.Pergunta.Include(p => p.Categoria).Include(p => p.Usuario);
            return View(pergunta.ToList());
        }

        // GET: Pergunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            
            var resposta = (from u in db.Resposta where u.PerguntaID == id select u).FirstOrDefault();

            if (resposta != null)
            {
                ViewBag.resposta = resposta.Texto;
            }
            else
            {
                ViewBag.resposta = "Sem resposta";
            }

            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // GET: Pergunta/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email");
            return View();
        }

        // POST: Pergunta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerguntaID,UsuarioID,CategoriaID,Imagem,Texto,Status,Data")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                pergunta.Status = "A";
                pergunta.Data = DateTime.Now;
                db.Pergunta.Add(pergunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", pergunta.CategoriaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", pergunta.UsuarioID);
            return View(pergunta);
        }

        // GET: Pergunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", pergunta.CategoriaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", pergunta.UsuarioID);
            return View(pergunta);
        }

        // POST: Pergunta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerguntaID,UsuarioID,CategoriaID,Imagem,Texto,Status,Data")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pergunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", pergunta.CategoriaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", pergunta.UsuarioID);
            return View(pergunta);
        }

        // GET: Pergunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // POST: Pergunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pergunta pergunta = db.Pergunta.Find(id);
            db.Pergunta.Remove(pergunta);
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
