using ControleDeAcesso.Dominio;
using ControleDeAcesso.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly IRepository<Usuario> repositorio;

        public UsuarioAplicacao(IRepository<Usuario> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Usuario usuario)
        {
            repositorio.salvar(usuario);

        }
        public void Alterar(Usuario usuario)
        {
            repositorio.alterar(usuario);

        }

        public void Excluir(Usuario usuario)
        {
            repositorio.excluir(usuario);
        }

        public IEnumerable<Usuario> ListarTodos()
        {

            return repositorio.listarTodos();
        }


        public Usuario ListarPorId(Usuario usuario)
        {
            return repositorio.listarPorId(usuario);
        }

    }
}
