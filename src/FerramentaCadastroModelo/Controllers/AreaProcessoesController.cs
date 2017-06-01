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
    public class AreaProcessoesController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: AreaProcessoes
        public ActionResult Index()
        {
            var areaProcesso = db.AreaProcesso.Include(a => a.Categoria).Include(a => a.Modelo).Include(a => a.NivelMaturidade);
            return View(areaProcesso.ToList());
        }

        // GET: AreaProcessoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaProcesso areaProcesso = db.AreaProcesso.Find(id);
            if (areaProcesso == null)
            {
                return HttpNotFound();
            }
            return View(areaProcesso);
        }

        // GET: AreaProcessoes/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Nome");
            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla");
            ViewBag.IDNivelMaturidade = new SelectList(db.NivelMaturidade, "IDNivelMaturidDade", "Sigla");
            return View();
        }

        // POST: AreaProcessoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAreaProcesso,Sigla,Nome,Descricao,IDModelo,IDNivelMaturidade,IDCategoria")] AreaProcesso areaProcesso)
        {
            if (ModelState.IsValid)
            {
                db.AreaProcesso.Add(areaProcesso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Nome", areaProcesso.IDCategoria);
            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla", areaProcesso.IDModelo);
            ViewBag.IDNivelMaturidade = new SelectList(db.NivelMaturidade, "IDNivelMaturidDade", "Sigla", areaProcesso.IDNivelMaturidade);
            return View(areaProcesso);
        }

        // GET: AreaProcessoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaProcesso areaProcesso = db.AreaProcesso.Find(id);
            if (areaProcesso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Nome", areaProcesso.IDCategoria);
            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla", areaProcesso.IDModelo);
            ViewBag.IDNivelMaturidade = new SelectList(db.NivelMaturidade, "IDNivelMaturidDade", "Sigla", areaProcesso.IDNivelMaturidade);
            return View(areaProcesso);
        }

        // POST: AreaProcessoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAreaProcesso,Sigla,Nome,Descricao,IDModelo,IDNivelMaturidade,IDCategoria")] AreaProcesso areaProcesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaProcesso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Nome", areaProcesso.IDCategoria);
            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla", areaProcesso.IDModelo);
            ViewBag.IDNivelMaturidade = new SelectList(db.NivelMaturidade, "IDNivelMaturidDade", "Sigla", areaProcesso.IDNivelMaturidade);
            return View(areaProcesso);
        }

        // GET: AreaProcessoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaProcesso areaProcesso = db.AreaProcesso.Find(id);
            if (areaProcesso == null)
            {
                return HttpNotFound();
            }
            return View(areaProcesso);
        }

        // POST: AreaProcessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaProcesso areaProcesso = db.AreaProcesso.Find(id);
            db.AreaProcesso.Remove(areaProcesso);
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
