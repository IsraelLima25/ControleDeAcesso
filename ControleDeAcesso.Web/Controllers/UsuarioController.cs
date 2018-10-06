using ControleDeAcesso.Aplicacao;
using ControleDeAcesso.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeAcesso.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeUsuario()
        {
            ViewBag.Titulo = "Manutenção de Usuários";
            var userAplication = UsuarioAplicacaoConstrutor.UsuarioAp();
            var listaDeTodosUsuarios = userAplication.ListarTodos();
            return View(listaDeTodosUsuarios);
        }

        public ActionResult CadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var apUser = UsuarioAplicacaoConstrutor.UsuarioAp();
                apUser.Salvar(usuario);
                return RedirectToAction("HomeUsuario");
            }

            return View();
        }
    }
}