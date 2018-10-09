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
    public class GrupoAplicacaoAdo : IRepository<Grupo>
    {
        private void salvar(Grupo grupo)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_grupo_ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nome", grupo.Nome);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private void alterar(Grupo grupo)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_grupo_upd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idGrupo", grupo.Codigo);
            cmd.Parameters.AddWithValue("@nome", grupo.Nome);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();

        }

        private void excluir(Grupo grupo)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_grupo_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idGrupo", grupo.Codigo);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private ICollection<Grupo> listarTodos()
        {
            ICollection<Grupo> listGrupo = new List<Grupo>();
            Grupo grupo;
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_grupo_sel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                grupo = new Grupo();
                grupo.Codigo = Convert.ToInt32(reader["idGrupo"]);
                grupo.Nome = reader["nome"].ToString();
                listGrupo.Add(grupo);
            }
            reader.Close();
            return listGrupo;
        }

        private Grupo listarPorId(Grupo grupo)
        {
            Grupo grupoBusca = new Grupo();
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_grupo_sel_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario",grupo.Codigo);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToInt32("idUsuario") == grupo.Codigo)
                {
                    grupoBusca.Codigo = Convert.ToInt32("idGrupo");
                    grupoBusca.Nome = reader["nome"].ToString();
                }
            }
            reader.Close();
            return grupoBusca;
        }

        //Implementação da Interface

        void IRepository<Grupo>.salvar(Grupo entity)
        {
            salvar(entity);
        }

        void IRepository<Grupo>.alterar(Grupo entity)
        {
            alterar(entity);
        }

        void IRepository<Grupo>.excluir(Grupo entity)
        {
            excluir(entity);
        }

        ICollection<Grupo> IRepository<Grupo>.listarTodos()
        {
            return listarTodos();
        }

        Grupo IRepository<Grupo>.listarPorId(Grupo entity)
        {
            return listarPorId(entity);
        }
    }
}
