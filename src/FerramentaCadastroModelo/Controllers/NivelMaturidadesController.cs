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
    public class NivelMaturidadesController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: NivelMaturidades
        public ActionResult Index()
        {
            return View(db.NivelMaturidade.ToList());
        }

        // GET: NivelMaturidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            if (nivelMaturidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelMaturidade);
        }

        // GET: NivelMaturidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelMaturidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNivelMaturidDade,Sigla,Nome,Descricao")] NivelMaturidade nivelMaturidade)
        {
            if (ModelState.IsValid)
            {
                db.NivelMaturidade.Add(nivelMaturidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelMaturidade);
        }

        // GET: NivelMaturidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            if (nivelMaturidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelMaturidade);
        }

        // POST: NivelMaturidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNivelMaturidDade,Sigla,Nome,Descricao")] NivelMaturidade nivelMaturidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelMaturidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelMaturidade);
        }

        // GET: NivelMaturidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            if (nivelMaturidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelMaturidade);
        }

        // POST: NivelMaturidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NivelMaturidade nivelMaturidade = db.NivelMaturidade.Find(id);
            db.NivelMaturidade.Remove(nivelMaturidade);
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
