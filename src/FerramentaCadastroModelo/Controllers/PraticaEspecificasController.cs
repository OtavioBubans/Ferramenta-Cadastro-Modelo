using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerramentaCadastroModelo.Dominio;
using FerramentaCadastroModelo.Repositorio;

namespace FerramentaCadastroModelo.Controllers
{
    public class PraticaEspecificasController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: PraticaEspecificas
        public ActionResult Index()
        {
            var praticaEspecifica = db.PraticaEspecifica.Include(p => p.MetaEspecifica);
            return View(praticaEspecifica.ToList());
        }

        // GET: PraticaEspecificas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            if (praticaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(praticaEspecifica);
        }

        // GET: PraticaEspecificas/Create
        public ActionResult Create()
        {
            ViewBag.IDMetaEspecifica = new SelectList(db.MetaEspecifica, "IDMetaEspecifica", "Sigla");
            ViewBag.IDProdutoTrabalho = new SelectList(db.ProdutoTrabalho, "IDProdutoTrabalho", "Nome");

            return View();
        }

        // POST: PraticaEspecificas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPraticaEspecifica,Sigla,Nome,Descricao,IDMetaEspecifica")] PraticaEspecifica praticaEspecifica, ProdutoTrabalho produto)
        {
            if (ModelState.IsValid)
            {

                db.PraticaEspecifica.Add(praticaEspecifica);
                db.SaveChanges();

                int? IdPratica = praticaEspecifica.IDPraticaEspecifica;
                int? IdProduto = produto.IDProdutoTrabalho;
                ProdutoTrabalhoXPraticaEspecifica prodPratica = new ProdutoTrabalhoXPraticaEspecifica()
                {
                    IDPraticaEspecifica = IdPratica,
                    IDProdutoTrabalho = IdProduto
                };
                db.ProdutoTrabalhoXPraticaEspecifica.Add(prodPratica);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMetaEspecifica = new SelectList(db.MetaEspecifica, "IDMetaEspecifica", "Sigla", praticaEspecifica.IDMetaEspecifica);
            return View(praticaEspecifica);
        }

        // GET: PraticaEspecificas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            if (praticaEspecifica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMetaEspecifica = new SelectList(db.MetaEspecifica, "IDMetaEspecifica", "Sigla", praticaEspecifica.IDMetaEspecifica);
            return View(praticaEspecifica);
        }

        // POST: PraticaEspecificas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPraticaEspecifica,Sigla,Nome,Descricao,IDMetaEspecifica")] PraticaEspecifica praticaEspecifica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(praticaEspecifica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMetaEspecifica = new SelectList(db.MetaEspecifica, "IDMetaEspecifica", "Sigla", praticaEspecifica.IDMetaEspecifica);
            return View(praticaEspecifica);
        }

        // GET: PraticaEspecificas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            if (praticaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(praticaEspecifica);
        }

        // POST: PraticaEspecificas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PraticaEspecifica praticaEspecifica = db.PraticaEspecifica.Find(id);
            db.PraticaEspecifica.Remove(praticaEspecifica);
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
