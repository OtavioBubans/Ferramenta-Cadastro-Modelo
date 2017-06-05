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
    public class MetaEspecificasController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: MetaEspecificas
        public ActionResult Index()
        {
            var metaEspecifica = db.MetaEspecifica.Include(m => m.AreaProcesso);
            return View(metaEspecifica.ToList());
        }

        // GET: MetaEspecificas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            if (metaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(metaEspecifica);
        }

        // GET: MetaEspecificas/Create
        public ActionResult Create()
        {
            ViewBag.IDAreaProcesso = new SelectList(db.AreaProcesso, "IDAreaProcesso", "Sigla");
            return View();
        }

        // POST: MetaEspecificas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMetaEspecifica,Sigla,Nome,Descricao,IDAreaProcesso")] MetaEspecifica metaEspecifica)
        {
            if (ModelState.IsValid)
            {
                db.MetaEspecifica.Add(metaEspecifica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAreaProcesso = new SelectList(db.AreaProcesso, "IDAreaProcesso", "Sigla", metaEspecifica.IDAreaProcesso);
            return View(metaEspecifica);
        }

        // GET: MetaEspecificas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            if (metaEspecifica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAreaProcesso = new SelectList(db.AreaProcesso, "IDAreaProcesso", "Sigla", metaEspecifica.IDAreaProcesso);
            return View(metaEspecifica);
        }

        // POST: MetaEspecificas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMetaEspecifica,Sigla,Nome,Descricao,IDAreaProcesso")] MetaEspecifica metaEspecifica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metaEspecifica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAreaProcesso = new SelectList(db.AreaProcesso, "IDAreaProcesso", "Sigla", metaEspecifica.IDAreaProcesso);
            return View(metaEspecifica);
        }

        // GET: MetaEspecificas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            if (metaEspecifica == null)
            {
                return HttpNotFound();
            }
            return View(metaEspecifica);
        }

        // POST: MetaEspecificas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetaEspecifica metaEspecifica = db.MetaEspecifica.Find(id);
            db.MetaEspecifica.Remove(metaEspecifica);
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
