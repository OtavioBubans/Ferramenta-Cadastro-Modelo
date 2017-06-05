using FerramentaCadastroModelo.Aplicativo;
using FerramentaCadastroModelo.Dominio;
using FerramentaCadastroModelo.Models;
using FerramentaCadastroModelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FerramentaCadastroModelo.Controllers
{
    public class HomeController : Controller
    {

        private ContextoDeDados db = new ContextoDeDados();

        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult CadastroModelo()
        {
            return View();
        }

        public ActionResult CadastroAreaProcesso()
        {
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Nome");
            ViewBag.IDNivelMaturidade = new SelectList(db.NivelMaturidade, "IDNivelMaturidDade", "Sigla");
            return View();
        }


        [HttpPost]
        public ActionResult SalvarModelo(ModeloModel model)
        {
            var aplicativo = new ModeloAplicativo();
            Modelo modelo = new Modelo()
            {
                IDModelo = model.IDModelo.HasValue ? model.IDModelo.Value : 0,
                Nome = model.Nome,
                Sigla = model.Sigla,
                Descricao = model.Descricao
            };
            aplicativo.Salvar(modelo);

            // return RedirectToAction("CadastroAreaProcesso");
            return RedirectToAction("CadastroAreaProcesso");
        }

        [HttpPost]
        public ActionResult SalvarAreaProcesso(AreaProcessoModel model)
        {
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Nome");
            ViewBag.IDNivelMaturidade = new SelectList(db.NivelMaturidade, "IDNivelMaturidade", "Nome");
            

            //  var idModelo = modelo.IDModelo;
            var aplicativo = new AreaProcessoAplicativo();
            AreaProcesso areaProcesso = new AreaProcesso()
            {
                IDAreaProcesso = model.IDAreaProcesso.HasValue ? model.IDAreaProcesso.Value : 0,
                Sigla = model.Sigla,
                Nome = model.Nome,
                Descricao = model.Descricao,
                IDModelo = model.IDModelo,
                IDCategoria = model.IDCategoria,
                IDNivelMaturidade = model.IDNivelMaturidade   
            };
            aplicativo.Salvar(areaProcesso);
            return RedirectToAction ("Index");
        }


    }
}