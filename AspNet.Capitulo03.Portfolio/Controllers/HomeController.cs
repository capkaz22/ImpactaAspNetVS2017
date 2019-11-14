using AspNet.Capitulo03.Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet.Capitulo03.Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Deixe sua mensagem.";

            return View();
        }

        [HttpGet]//ja é get defaut, não precisa colocar os colchetes
        public ActionResult Contact()
        {
            ViewBag.Message = "Deixe sua mensagem.";

            return View();
        }

        //public ActionResult Contact(string nome, string email, string mensagem) 
        //public ActionResult Contact(FormCollection formulario)
        [HttpPost]//o colchetes muda o atributo//Esse método é de retorno
        public ActionResult Contact(ContatoViewModel contato) 
        {
            if (!ModelState.IsValid) 
            {
                return View(contato);///bloqueia o método postman
            }

            var stringConexao = ConfigurationManager.ConnectionStrings["portfolioConnectionString"].ConnectionString;

            using (var conexao = new SqlConnection(stringConexao)) 
            {
                conexao.Open();

                const string instrucao = @"INSERT INTO [dbo].[Contato]
                                   ([Nome]
                                   ,[Email]
                                   ,[Mensagem])
                             VALUES
                                   (@Nome
                                   ,@Email
                                   ,@Mensagem)";


                //ToDo: não esquecer do meu IDisposabel.
                using (var comando = new SqlCommand(instrucao,conexao)) 
                {
                    comando.Parameters.AddWithValue("Nome", contato.Nome);
                    comando.Parameters.AddWithValue("@Email", contato.Email);
                    comando.Parameters.AddWithValue(nameof(contato.Mensagem),contato.Mensagem);

                    comando.ExecuteNonQuery();

                }

                //conexao.Close(); é chamado ao final da instrução automaticamente
            }

            ViewBag.Sucesso = true;

            ModelState.Clear();


            return View();
        }

        public ActionResult Portfolio() //botão direito>>adicionar exibição
        {
            const string diretorioImagens = "/Content/Imagens/Portfolio";

            var caminhos = Directory.EnumerateFiles(Server.MapPath(diretorioImagens));

            var portfolioViewModel = new PortfolioViewModel();
            portfolioViewModel.CaminhoImagens = new List<string>();///é preciso instanciar a property, pois ela não é primitiva    

            foreach (var caminho in caminhos)
            {
                portfolioViewModel.CaminhoImagens.Add($"{diretorioImagens}/{Path.GetFileName(caminho)}");

            }

            return View(portfolioViewModel);
        }
    }
}