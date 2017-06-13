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
using System.IO;
using System.Web.UI;

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
               ViewBag.IDPraticaEspecifica = new SelectList(db.PraticaEspecifica, "IDPraticaEspecifica","Sigla","Nome");

            return View();
        }

        // POST: ProdutoTrabalhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProdutoTrabalho,Nome,NomeArquivo,Tamplate")] ProdutoTrabalho produtoTrabalho, PraticaEspecifica praticaEspecifica, HttpPostedFileBase file)
       {
            
                if (file != null && file.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        produtoTrabalho.Tamplate = reader.ReadBytes(file.ContentLength);
                        produtoTrabalho.NomeArquivo = file.FileName;
                    }
                }



                string nomeProduto = produtoTrabalho.Nome;
                string nomeArquivo = produtoTrabalho.NomeArquivo;

                if (db.ProdutoTrabalho.FirstOrDefault(p => p.Nome.Equals(nomeProduto)) != null)
                {
                    ViewBag.Mensagem = "Já existe um Produto com esse nome - Tente outro";
                    return View(produtoTrabalho);
                };

                if (db.ProdutoTrabalho.FirstOrDefault(p => p.NomeArquivo.Equals(nomeArquivo)) != null)
                {
                    ViewBag.Mensagem = "Já existe um Arquivo com esse nome - Tente outro arquivo";
                    return View(produtoTrabalho);
                };



                db.ProdutoTrabalho.Add(produtoTrabalho);
                db.SaveChanges();


                int? IdProduto = produtoTrabalho.IDProdutoTrabalho;
                int? IdPratica = praticaEspecifica.IDPraticaEspecifica;

                ProdutoTrabalhoXPraticaEspecifica praticaProd = new ProdutoTrabalhoXPraticaEspecifica()
                {
                    IDPraticaEspecifica = IdPratica,
                    IDProdutoTrabalho = IdProduto
                };

                db.ProdutoTrabalhoXPraticaEspecifica.Add(praticaProd);

                db.SaveChanges();

                return RedirectToAction("Index");
            

           // return View(produtoTrabalho);
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


        public void Download(int? id)
        {
            ProdutoTrabalho produtoTrabalho = db.ProdutoTrabalho.Find(id);



            Response.AddHeader("Content-Disposition", "attachment; filename=" + produtoTrabalho.NomeArquivo);

            if (produtoTrabalho.Tamplate != null)

                Response.BinaryWrite(produtoTrabalho.Tamplate.ToArray());




        }
    }
}