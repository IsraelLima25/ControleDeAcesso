using ControleDeAcesso.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Aplicacao
{
    public class PermissaoAplicacaoConstrutor
    {

        public static PermissaoAplicacao PermissaoAp()
        {
            return new PermissaoAplicacao(new PermissaoAplicacaoAdo());
        }

    }
}
