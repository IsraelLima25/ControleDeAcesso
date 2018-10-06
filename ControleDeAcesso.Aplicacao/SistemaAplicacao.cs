using ControleDeAcesso.Dominio;
using ControleDeAcesso.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Aplicacao
{
    public class SistemaAplicacao
    {
        private readonly IRepository<Sistema> repositorio;

        public SistemaAplicacao(IRepository<Sistema> repo)
        {
            repositorio = repo;
        }       

        public void Salvar(Sistema sistema)
        {
            repositorio.salvar(sistema);

        }
        public void Alterar(Sistema sistema)
        {
            repositorio.alterar(sistema);

        }

        public void Excluir(Sistema sistema)
        {
            repositorio.excluir(sistema);
        }

        public IEnumerable<Sistema> ListarTodos()
        {

            return repositorio.listarTodos();
        }


        public Sistema ListarPorId(Sistema sistema)
        {
            return repositorio.listarPorId(sistema);
        }
    }
}
