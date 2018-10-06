using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Dominio.Contrato
{
    public interface IRepository<T> where T : class
    {
        void salvar(T entity);
        void alterar(T entity);
        void excluir(T entity);
        ICollection<T> listarTodos();
        T listarPorId(T entity);

    }
}
