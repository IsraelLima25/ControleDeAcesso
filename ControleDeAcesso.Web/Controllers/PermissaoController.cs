using ControleDeAcesso.Aplicacao;
using ControleDeAcesso.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeAcesso.Web.Controllers
{
    public class PermissaoController : Controller
    {
        // GET: Permissao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HomePermissao()
        {
            ViewBag.Titulo = "Manutenção de Permissões";
            var permissionAplication = PermissaoAplicacaoConstrutor.PermissaoAp();
            var listaDeTodasPermissoes = permissionAplication.ListarTodos();
            return View(listaDeTodasPermissoes);
        }

        public ActionResult CadastrarPermissao()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPermissao(Permissao permissao)
        {
            if (ModelState.IsValid)
            {
                var permissionAplication = PermissaoAplicacaoConstrutor.PermissaoAp();
                permissionAplication.Salvar(permissao);

                return RedirectToAction("HomePermissao");
            }

            return View();
        }
    }
}