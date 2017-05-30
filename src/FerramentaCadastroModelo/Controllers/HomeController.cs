using FerramentaCadastroModelo.Aplicativo;
using FerramentaCadastroModelo.Dominio;
using FerramentaCadastroModelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FerramentaCadastroModelo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult CadastroModelo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SalvarModelo(ModeloModel model)
        {
            var aplicativo = new ModeloAplicativo();
            Modelo dificuldade = new Modelo()
            {
                Id = model.Id.HasValue ? model.Id.Value : 0,
                Nome = model.Nome,
                Sigla = model.Sigla,
                Descricao = model.Descricao
            };
            aplicativo.Salvar(dificuldade);

            return RedirectToAction("Index");

        }
    }
}