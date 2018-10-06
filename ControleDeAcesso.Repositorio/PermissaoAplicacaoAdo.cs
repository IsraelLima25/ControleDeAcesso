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
    public class PermissaoAplicacaoAdo : IRepository<Permissao>
    {
        private void salvar(Permissao permissao)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_permissao_ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nome", permissao.nome);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private void alterar(Permissao permissao)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_permissao_upd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPermissao", permissao.idPermissao);
            cmd.Parameters.AddWithValue("@nome", permissao.nome);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();

        }

        private void excluir(Permissao permissao)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_permissao_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPermissao", permissao.idPermissao);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private ICollection<Permissao> listarTodos()
        {
            ICollection<Permissao> listPermissao = new List<Permissao>();
            Permissao permissao;
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_permissao_sel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                permissao = new Permissao();
                permissao.idPermissao = Convert.ToInt32(reader["idPermissao"]);
                permissao.nome = reader["nome"].ToString();
                listPermissao.Add(permissao);
            }
            reader.Close();
            return listPermissao;

        }

        private Permissao listarPorId(Permissao permissao)
        {
            Permissao permissaoSearch = new Permissao();
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_permissao_sel_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (Convert.ToInt32(reader[0]) == permissao.idPermissao)
                {
                    permissaoSearch.idPermissao = Convert.ToInt32(reader["idPermissao"]);
                    permissaoSearch.nome = reader["nome"].ToString();
                }
            }
            reader.Close();
            return permissaoSearch;
        }

        //Implementação da Interface

        void IRepository<Permissao>.salvar(Permissao entity)
        {
            salvar(entity);
        }

        void IRepository<Permissao>.alterar(Permissao entity)
        {
            alterar(entity);
        }

        void IRepository<Permissao>.excluir(Permissao entity)
        {
            excluir(entity);
        }

        ICollection<Permissao> IRepository<Permissao>.listarTodos()
        {
            return listarTodos();
        }

        Permissao IRepository<Permissao>.listarPorId(Permissao entity)
        {
            return listarPorId(entity);
        }
    }
}
