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
    public class ModeloesController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: Modeloes
        public ActionResult Index()
        {
            return View(db.Modelo.ToList());
        }

        // GET: Modeloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: Modeloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modeloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDModelo,Sigla,Nome,Descricao")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {

                string nome = modelo.Nome;
                string sigla = modelo.Sigla;

                if (db.Modelo.FirstOrDefault(x => x.Nome.Equals(nome)) != null )
                {
                    ViewBag.Mensagem = "Esse Nome ja existe!";
                    return View(modelo);
                };

                if (db.Modelo.FirstOrDefault(x => x.Sigla.Equals(sigla)) != null)
                {
                    ViewBag.Mensagem = "Essa Sigla já existe!";
                    return View(modelo);
                };

                db.Modelo.Add(modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Modeloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modeloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDModelo,Sigla,Nome,Descricao")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Modeloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelo.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo modelo = db.Modelo.Find(id);
            db.Modelo.Remove(modelo);
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
