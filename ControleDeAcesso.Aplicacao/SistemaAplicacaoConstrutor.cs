using ControleDeAcesso.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Aplicacao
{
    public static class SistemaAplicacaoConstrutor
    {
        public static SistemaAplicacao sistemaAp()
        {
            return new SistemaAplicacao(new SistemaAplicacaoAdo());
        }
    }
}
