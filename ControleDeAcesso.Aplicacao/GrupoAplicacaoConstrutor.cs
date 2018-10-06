using ControleDeAcesso.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Aplicacao
{
    public class GrupoAplicacaoConstrutor
    {
        public static GrupoAplicacao grupoAp()
        {
            return new GrupoAplicacao(new GrupoAplicacaoAdo());
        }

    }
}
