using ControleDeAcesso.Aplicacao;
using ControleDeAcesso.Dominio;
using System.Collections.Generic;
using System.Web.Mvc;


namespace ControleDeAcesso.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

       
        public ActionResult HomeSistema()
        {
            ViewBag.Titulo = "Manutenção de Sistemas";
            return View();
        }
        public ActionResult HomePermissao()
        {
            ViewBag.Titulo = "Manutenção de Permissões";
            return View();
        }
        public ActionResult HomeGrupo()
        {
            ViewBag.Titulo = "Manutenção de Grupos";
            return View();
        }


    }
}