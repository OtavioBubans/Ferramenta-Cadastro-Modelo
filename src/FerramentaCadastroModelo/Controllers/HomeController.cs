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

            DataSet Ds = new DataSet();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            string sSQL = "Select " +
                          "Modelo.Sigla as 'Sigla Modelo'," +
                          "Modelo.Nome as 'Nome Modelo'," +
                          "Modelo.Descricao as 'Descrição Modelo'," +
                          //"metaGenerica.Sigla as 'Sigla Meta Generica'," +
                          "metaGenerica.Nome as 'Nome Meta Generica'," +
                          "metaGenerica.Descricao as 'Descrição Meta Generica'," +
                          //"NivelCapacidade.SiglaNivelCapacidade as 'Sigla Nivel Capacidade'," +
                          "NivelCapacidade.Nome as 'Nome Nivel Capacidade'," +
                          "NivelCapacidade.Descricao as 'Descrição Nivel Capacidade'" +
                          "from Modelo" +
                          " full join metaGenerica on Modelo.IDModelo = metaGenerica.IDModelo" +
                          " full join NivelCapacidade on metaGenerica.IDNivelCapacidade = NivelCapacidade.IDNivelCapacidade";

            SqlDataAdapter da1 = new SqlDataAdapter(sSQL, (db.Database.Connection.ConnectionString));
           

            da1.Fill(dt1);
            Ds.Tables.Add(dt1);


            sSQL = "select AreaProcesso.Nome as 'Area de Processos', " +
                "Categoria.Nome as 'Categoria', " +
                "NivelMaturidade.Nome as 'Nivel Maturidade', "+
                "MetaEspecifica.Nome as 'Meta Especifica', "+
                "PraticaEspecifica.Nome as 'Pratica Especifica', "+
                "ProdutoTrabalho.Nome as 'Produto de Trabaho' from Modelo"+
                    " inner join AreaProcesso" +
                    " on modelo.IDModelo = AreaProcesso.IDModelo" +
                    " inner join Categoria" +
                    " on Categoria.IDCategoria = AreaProcesso.IDCategoria" +
                    " inner join NivelMaturidade" +
                    " on NivelMaturidade.IDNivelMaturidade = AreaProcesso.IDNivelMaturidade" +
                    " inner join MetaEspecifica" +
                    " on MetaEspecifica.IDAreaProcesso = AreaProcesso.IDAreaProcesso" +
                    " inner join PraticaEspecifica" +
                    " on PraticaEspecifica.IDMetaEspecifica = MetaEspecifica.IDMetaEspecifica" +
                    " inner join ProdutoTrabalho" +
                    " on ProdutoTrabalho.IDProdutoTrabalho = PraticaEspecifica.ProdutoTrabalho_IDProdutoTrabalho";

            SqlDataAdapter da2 = new SqlDataAdapter(sSQL, (db.Database.Connection.ConnectionString));

            da2.Fill(dt2);
                    Ds.Tables.Add(dt2);

            return View(Ds);
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
            ViewBag.IDNivelMaturidade = new SelectList(db.NivelMaturidade, "IDNivelMaturidade", "Sigla");
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