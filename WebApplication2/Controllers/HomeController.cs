using Serviço.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
         private CategoriaServico produtoServico = new CategoriaServico();
        private HomeClass home = new HomeClass();
        // GET: Home
        public ActionResult Index()
        {
            home.listaprodutoDestaque = produtoServico.ObterDestaques();
            home.listaprodutoLançamentos = produtoServico.ObterUltimosProdutos();
            return View(home);
        }
    }
}