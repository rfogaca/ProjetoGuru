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
    public class RespostaController : Controller
    {
        private Conexao db = new Conexao();

        // GET: Resposta
        public ActionResult Index()
        {
            var resposta = db.Resposta.Include(r => r.Pergunta).Include(r => r.Usuario);
            return View(resposta.ToList());
        }

        // GET: Resposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Resposta.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // GET: Resposta/Create
        public ActionResult Create(int id)
        {
            ViewData["id"] = id;
            var pergunta = (from u in db.Pergunta where u.PerguntaID == id select u).FirstOrDefault();
            string textoPergunta = Convert.ToString(pergunta.Texto);

            ViewBag.Pergunta = textoPergunta;
            ViewBag.PerguntaID = new SelectList(db.Pergunta, "PerguntaID", "Imagem");

            return View();
        }

        // POST: Resposta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RespostaID,PerguntaID,UsuarioID,Texto,Data,Avaliacao")] Resposta resposta)
        {
            
            if (ModelState.IsValid)
            {
                var pergunta = (from u in db.Pergunta where u.PerguntaID == resposta.PerguntaID select u).FirstOrDefault();
                pergunta.Status = "R";
                //db.Pergunta.SqlQuery("UPDATE Pergunta SET Status='R' WHERE PerguntaID="+resposta.PerguntaID);
                resposta.Data = DateTime.Now;
                db.Resposta.Add(resposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PerguntaID = new SelectList(db.Pergunta, "PerguntaID", "Imagem", resposta.PerguntaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", resposta.UsuarioID);
            return View(resposta);
        }

        // GET: Resposta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Resposta.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerguntaID = new SelectList(db.Pergunta, "PerguntaID", "Imagem", resposta.PerguntaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", resposta.UsuarioID);
            return View(resposta);
        }

        // POST: Resposta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RespostaID,PerguntaID,UsuarioID,Texto,Data,Avaliacao")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PerguntaID = new SelectList(db.Pergunta, "PerguntaID", "Imagem", resposta.PerguntaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "Email", resposta.UsuarioID);
            return View(resposta);
        }

        // GET: Resposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Resposta.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // POST: Resposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resposta resposta = db.Resposta.Find(id);
            db.Resposta.Remove(resposta);
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
