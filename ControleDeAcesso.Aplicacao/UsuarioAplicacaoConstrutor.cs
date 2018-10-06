using ControleDeAcesso.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ControleDeAcesso.Aplicacao
{
    public class UsuarioAplicacaoConstrutor
    {
        public static UsuarioAplicacao UsuarioAp()
        {
            return new UsuarioAplicacao(new UsuarioAplicacaoAdo());
        }
    }
}
