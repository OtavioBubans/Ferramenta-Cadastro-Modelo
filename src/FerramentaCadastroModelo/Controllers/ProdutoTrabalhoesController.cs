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
    public class ProdutoTrabalhoesController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: ProdutoTrabalhoes
        public ActionResult Index()
        {
            return View(db.ProdutoTrabalho.ToList());
        }

        // GET: ProdutoTrabalhoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            if (produtoTrabalho == null)
            {
                return HttpNotFound();
            }
            return View(produtoTrabalho);
        }

        // GET: ProdutoTrabalhoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoTrabalhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProdutoTrabalho,Nome,Tamplate")] ProdutoTrabalho produtoTrabalho)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoTrabalho.Add(produtoTrabalho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtoTrabalho);
        }

        // GET: ProdutoTrabalhoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            if (produtoTrabalho == null)
            {
                return HttpNotFound();
            }
            return View(produtoTrabalho);
        }

        // POST: ProdutoTrabalhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProdutoTrabalho,Nome,Tamplate")] ProdutoTrabalho produtoTrabalho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoTrabalho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtoTrabalho);
        }

        // GET: ProdutoTrabalhoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            if (produtoTrabalho == null)
            {
                return HttpNotFound();
            }
            return View(produtoTrabalho);
        }

        // POST: ProdutoTrabalhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);
            db.ProdutoTrabalho.Remove(produtoTrabalho);
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
