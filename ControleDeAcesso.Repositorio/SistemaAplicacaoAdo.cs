using ControleDeAcesso.Dominio;
using ControleDeAcesso.Dominio.Contrato;
using ControleDeAcesso.Repositorio.Conexao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Repositorio
{
    public class SistemaAplicacaoAdo : IRepository<Sistema>
    {

        private void salvar(Sistema sistema)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_sistema_ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nome", sistema.Nome);
            cmd.Parameters.AddWithValue("@descricao", sistema.Descricao);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private void alterar(Sistema sistema)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_sistema_upd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idSistema", sistema.Codigo);
            cmd.Parameters.AddWithValue("@nome", sistema.Nome);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private void excluir(Sistema sistema)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_sistema_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idSistema", sistema.Codigo);
            int qtdLinhasAfetadas = cmd.ExecuteNonQuery();
            Connection.closeConnection();

        }

        private ICollection<Sistema> listarTodos()
        {
            ICollection<Sistema> listSistemas = new List<Sistema>();
            Sistema sistema;
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_sistema_sel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                sistema = new Sistema();
                sistema.Codigo = Convert.ToInt32(reader["idSistema"]);
                sistema.Nome = reader["nome"].ToString();
                sistema.Descricao = reader["descricao"].ToString();

                listSistemas.Add(sistema);
            }
            reader.Close();

            return listSistemas;
        }

        private Sistema listarPorId(Sistema sistema)
        {
            Sistema sistemaSearch = new Sistema();
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_sistema_sel_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToInt32(reader["idSistema"]) == sistema.Codigo)
                {
                    sistemaSearch.Codigo = Convert.ToInt32(reader["idSistema"]);
                    sistemaSearch.Nome = reader["nome"].ToString();
                }
            }
            reader.Close();

            return sistemaSearch;
        }

        //Implementação da Interface

        void IRepository<Sistema>.salvar(Sistema entity)
        {
            salvar(entity);
        }

        void IRepository<Sistema>.alterar(Sistema entity)
        {
            alterar(entity);
        }

        void IRepository<Sistema>.excluir(Sistema entity)
        {
            excluir(entity);
        }

        ICollection<Sistema> IRepository<Sistema>.listarTodos()
        {
            return listarTodos();
        }

        Sistema IRepository<Sistema>.listarPorId(Sistema entity)
        {
            return listarPorId(entity);
        }
    }
}
