using ControleDeAcesso.Aplicacao;
using ControleDeAcesso.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeAcesso.Web.Controllers
{
    public class SistemaController : Controller
    {
        // GET: Sistema
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeSistema()
        {
            ViewBag.Titulo = "Manutenção de Sistemas";
            var systemAplication = SistemaAplicacaoConstrutor.sistemaAp();
            var listaDeTodosSistemas = systemAplication.ListarTodos();
            return View(listaDeTodosSistemas);
        }

        public ActionResult CadastrarSistema()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CadastrarSistema(Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                var systemAplication = SistemaAplicacaoConstrutor.sistemaAp();
                systemAplication.Salvar(sistema);

                return RedirectToAction("HomeSistema");
            }

            return View();
        }

    }
}