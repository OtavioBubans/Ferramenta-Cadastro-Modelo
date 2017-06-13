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
    public class NivelCapacidadesController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: NivelCapacidades
        public ActionResult Index()
        {
            return View(db.NivelCapacidade.ToList());
        }

        // GET: NivelCapacidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            if (nivelCapacidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelCapacidade);
        }

        // GET: NivelCapacidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelCapacidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNivelCapacidade,SiglaNivelCapacidade,Nome,Descricao")] NivelCapacidade nivelCapacidade)
        {
            if (ModelState.IsValid)
            {
                
                string nome = nivelCapacidade.Nome;
                string sigla = nivelCapacidade.SiglaNivelCapacidade;


                if (db.NivelCapacidade.FirstOrDefault(s => s.SiglaNivelCapacidade.Equals(sigla)) != null)
                {
                    ViewBag.Sigla = "Já existe um Nivel de Capacidade com essa SIGLA!";
                    return View(nivelCapacidade);
                };

                if (db.NivelCapacidade.FirstOrDefault(n => n.Nome.Equals(nome)) != null)
                {
                    ViewBag.Nome = "Já existe um Nivel de Capacidade com esse NOME!";
                    return View(nivelCapacidade);
                };

                db.NivelCapacidade.Add(nivelCapacidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelCapacidade);
        }

        // GET: NivelCapacidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            if (nivelCapacidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelCapacidade);
        }

        // POST: NivelCapacidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNivelCapacidade,SiglaNivelCapacidade,Nome,Descricao")] NivelCapacidade nivelCapacidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelCapacidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelCapacidade);
        }

        // GET: NivelCapacidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            if (nivelCapacidade == null)
            {
                return HttpNotFound();
            }
            return View(nivelCapacidade);
        }

        // POST: NivelCapacidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NivelCapacidade nivelCapacidade = db.NivelCapacidade.Find(id);
            db.NivelCapacidade.Remove(nivelCapacidade);
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
