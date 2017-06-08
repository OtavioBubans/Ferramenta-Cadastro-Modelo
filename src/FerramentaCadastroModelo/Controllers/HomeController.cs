using FerramentaCadastroModelo.Aplicativo;
using FerramentaCadastroModelo.Dominio;
using FerramentaCadastroModelo.Models;
using FerramentaCadastroModelo.Repositorio;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FerramentaCadastroModelo.Controllers
{
    public class HomeController : Controller
    {

        private ContextoDeDados db = new ContextoDeDados();

        public ActionResult DadosCompletos()
        {
            // var studentName = db.Database.ExecuteSqlCommand("Select Modelo.Sigla as 'Sigla Modelo',Modelo.Nome as 'Nome Modelo',Modelo.Descricao as 'Descrição Modelo',metaGenerica.Sigla as 'Sigla Meta Generica',metaGenerica.Nome as 'Nome Meta Generica',metaGenerica.Descricao as 'Descrição Meta Generica',NivelCapacidade.SiglaNivelCapacidade as 'Sigla Nivel Capacidade',NivelCapacidade.Nome as 'Nome Nivel Capacidade',NivelCapacidade.Descricao as 'Descrição Nivel Capacidade'from Modelo full join metaGenerica on Modelo.IDModelo = metaGenerica.IDModelo full join NivelCapacidade on metaGenerica.IDNivelCapacidade = NivelCapacidade.IDNivelCapacidade");

           // OleDbConnection connection = new OleDbConnection(db.Database.Connection.ConnectionString);

            DataTable dt = new DataTable();
            string sSQL = "Select ";
            sSQL += "Modelo.Sigla as 'Sigla Modelo',";
            sSQL += "Modelo.Nome as 'Nome Modelo',";
            sSQL += "Modelo.Descricao as 'Descrição Modelo',";
            sSQL += "metaGenerica.Sigla as 'Sigla Meta Generica',";
            sSQL += "metaGenerica.Nome as 'Nome Meta Generica',";
            sSQL += "metaGenerica.Descricao as 'Descrição Meta Generica',";
            sSQL += "NivelCapacidade.SiglaNivelCapacidade as 'Sigla Nivel Capacidade',";
            sSQL += "NivelCapacidade.Nome as 'Nome Nivel Capacidade',";
            sSQL += "NivelCapacidade.Descricao as 'Descrição Nivel Capacidade'";
            sSQL += "from Modelo";
            sSQL += " full join metaGenerica on Modelo.IDModelo = metaGenerica.IDModelo";
            sSQL += " full join NivelCapacidade on metaGenerica.IDNivelCapacidade = NivelCapacidade.IDNivelCapacidade";

            SqlDataAdapter da = new SqlDataAdapter(sSQL, (db.Database.Connection.ConnectionString));

            da.Fill(dt);


           
            return View(dt);
           // return View(db.Modelo.OrderBy(s => s.Sigla).ToList());
        }

        public ActionResult Index()
        {
            return View(db.Modelo.OrderBy(s => s.Sigla).ToList());
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

        public ActionResult ExportarPDF()
        {
            return new ActionAsPdf("DadosCompletos")
            {
                FileName = Server.MapPath("~/Content/testePDF.PDF")
            };
        }



    }
}