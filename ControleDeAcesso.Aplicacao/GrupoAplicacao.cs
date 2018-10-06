using ControleDeAcesso.Dominio;
using ControleDeAcesso.Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Aplicacao
{
    public class GrupoAplicacao
    {

        private readonly IRepository<Grupo> repositorio;

        public GrupoAplicacao(IRepository<Grupo> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Grupo grupo)
        {
            repositorio.salvar(grupo);

        }
        public void Alterar(Grupo grupo)
        {
            repositorio.alterar(grupo);

        }

        public void Excluir(Grupo grupo)
        {
            repositorio.excluir(grupo);
        }

        public IEnumerable<Grupo> ListarTodos()
        {

            return repositorio.listarTodos();
        }


        public Grupo ListarPorId(Grupo grupo)
        {
            return repositorio.listarPorId(grupo);
        }
    }
}
