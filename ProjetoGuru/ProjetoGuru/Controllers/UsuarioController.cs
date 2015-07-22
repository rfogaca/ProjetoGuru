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
    public class UsuarioController : Controller
    {
        private Conexao db = new Conexao();

        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.UsuarioTipo);
            return View(usuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioTipoID = new SelectList(db.UsuarioTipo, "UsuarioTipoID", "Tipo");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioID,Email,Nome,Imagem,Senha,DataNascimento,PaypalToken,UsuarioTipoID")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("../Usuario/Details");
            }

            ViewBag.UsuarioTipoID = new SelectList(db.UsuarioTipo, "UsuarioTipoID", "Tipo", usuario.UsuarioTipoID);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioTipoID = new SelectList(db.UsuarioTipo, "UsuarioTipoID", "Tipo", usuario.UsuarioTipoID);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioID,Email,Nome,Imagem,Senha,DataNascimento,PaypalToken,UsuarioTipoID")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioTipoID = new SelectList(db.UsuarioTipo, "UsuarioTipoID", "Tipo", usuario.UsuarioTipoID);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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

        public ActionResult Login(Usuario usuario)
        {
            var autenticacao = db.Usuario.Where(a => a.Email.Equals(usuario.Email) && a.Senha.Equals(usuario.Senha)).FirstOrDefault();
            if (autenticacao != null)
            {
                var id = Session["usuarioID"] = autenticacao.UsuarioID.ToString();
                var nome = Session["usuarioNome"] = autenticacao.Nome.ToString();
                var email = Session["usuarioEmail"] = autenticacao.Email.ToString();
                return RedirectToAction("../Usuario/Details/" + id);
            }
            return View(usuario);
        }

        public ActionResult Logoff(Usuario usuario)
        {
            var id = Session["usuarioID"] = null;
            var nome = Session["usuarioNome"] = null;
            var email = Session["usuarioEmail"] = null;
            
            return RedirectToAction("../Home");
        }

    }
}
