using ControleDeAcesso.Dominio;
using ControleDeAcesso.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Aplicacao
{
    public class PermissaoAplicacao
    {
        private readonly IRepository<Permissao> repositorio;

        public PermissaoAplicacao(IRepository<Permissao> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Permissao permissao)
        {
            repositorio.salvar(permissao);

        }
        public void Alterar(Permissao permissao)
        {
            repositorio.alterar(permissao);

        }

        public void Excluir(Permissao permissao)
        {
            repositorio.excluir(permissao);
        }

        public IEnumerable<Permissao> ListarTodos()
        {

            return repositorio.listarTodos();
        }


        public Permissao ListarPorId(Permissao permissao)
        {
            return repositorio.listarPorId(permissao);
        }
    }
}
