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
using Rotativa;
using System.Collections;

namespace FerramentaCadastroModelo.Controllers
{
    public class MetaGenericaController : Controller
    {
        private ContextoDeDados db = new ContextoDeDados();

        // GET: MetaGenerica
        public ActionResult Index()
        {
            var metaGenerica = db.MetaGenerica.Include(m => m.Modelo).Include(m => m.NivelCapacidade);
            return View(metaGenerica.ToList());
        }

        // GET: MetaGenerica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            if (metaGenerica == null)
            {
                return HttpNotFound();
            }
            return View(metaGenerica);
        }

        // GET: MetaGenerica/Create
        public ActionResult Create()
        {
            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla");
            ViewBag.IDNivelCapacidade = new SelectList(db.NivelCapacidade, "IDNivelCapacidade", "SiglaNivelCapacidade");
            return View();
        }

        // POST: MetaGenerica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMetaGenerica,Sigla,Nome,Descricao,IDModelo,IDNivelCapacidade")] MetaGenerica metaGenerica)
        {
            if (ModelState.IsValid)
            {
                string sigla = metaGenerica.Sigla;
                string nome = metaGenerica.Nome;
                int? idModelo = metaGenerica.IDModelo;
                   
                if (ValidaSigla(sigla, idModelo))
                {
                    ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla");
                    ViewBag.IDNivelCapacidade = new SelectList(db.NivelCapacidade, "IDNivelCapacidade", "SiglaNivelCapacidade");
                    ViewBag.Sigla = "Já existe essa SIGLA neste MODELO";
                    return View(metaGenerica);
                };

                if (ValidaNome(nome, idModelo))
                {
                    ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla");
                    ViewBag.IDNivelCapacidade = new SelectList(db.NivelCapacidade, "IDNivelCapacidade", "SiglaNivelCapacidade");
                    ViewBag.Nome = "Já existe esse NOME neste MODELO";
                    return View(metaGenerica);
                };

                db.MetaGenerica.Add(metaGenerica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla", metaGenerica.IDModelo);
            ViewBag.IDNivelCapacidade = new SelectList(db.NivelCapacidade, "IDNivelCapacidade", "SiglaNivelCapacidade", metaGenerica.IDNivelCapacidade);
            return View(metaGenerica);
        }

        // GET: MetaGenerica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            if (metaGenerica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla", metaGenerica.IDModelo);
            ViewBag.IDNivelCapacidade = new SelectList(db.NivelCapacidade, "IDNivelCapacidade", "SiglaNivelCapacidade", metaGenerica.IDNivelCapacidade);
            return View(metaGenerica);
        }

        // POST: MetaGenerica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMetaGenerica,Sigla,Nome,Descricao,IDModelo,IDNivelCapacidade")] MetaGenerica metaGenerica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metaGenerica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDModelo = new SelectList(db.Modelo, "IDModelo", "Sigla", metaGenerica.IDModelo);
            ViewBag.IDNivelCapacidade = new SelectList(db.NivelCapacidade, "IDNivelCapacidade", "SiglaNivelCapacidade", metaGenerica.IDNivelCapacidade);
            return View(metaGenerica);
        }

        // GET: MetaGenerica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            if (metaGenerica == null)
            {
                return HttpNotFound();
            }
            return View(metaGenerica);
        }

        // POST: MetaGenerica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetaGenerica metaGenerica = db.MetaGenerica.Find(id);
            db.MetaGenerica.Remove(metaGenerica);
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


        protected bool ValidaSigla( string sigla, int? id )
        {
            var existe = db.MetaGenerica
                    .Include(m => m.Modelo)
                    .Include(m => m.NivelCapacidade)
                    .Where(m => m.Sigla == sigla && m.IDModelo == id).Count();
            if (existe > 0)
            {
                return true;
            }
            else { 
                return false;
            };
        }

        protected bool ValidaNome(string nome, int? id)
        {
            var existe = db.MetaGenerica
                   .Include(m => m.Modelo)
                   .Include(m => m.NivelCapacidade)
                   .Where(m => m.Nome == nome && m.IDModelo == id).Count();
            if (existe > 0)
            {
                return true;
            }
            else
            {
                return false;
            };
        }



       
    }
}
