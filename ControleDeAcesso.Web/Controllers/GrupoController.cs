using ControleDeAcesso.Aplicacao;
using ControleDeAcesso.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeAcesso.Web.Controllers
{
    public class GrupoController : Controller
    {
        // GET: Grupo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeGrupo()
        {
            ViewBag.Titulo = "Manutenção de Grupos";
            var groupAplication = GrupoAplicacaoConstrutor.grupoAp();
            var listaDeTodosGrupos = groupAplication.ListarTodos();
            return View(listaDeTodosGrupos);
        }

        public ActionResult CadastrarGrupo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarGrupo(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                var groupAplication = GrupoAplicacaoConstrutor.grupoAp();
                groupAplication.Salvar(grupo);
                return RedirectToAction("HomeGrupo");
            }

            return View();
        }
    }
}