using ControleDeAcesso.Dominio;
using System.Data.SqlClient;
using ControleDeAcesso.Repositorio.Conexao;
using System.Data;
using System.Collections.Generic;
using System;
using ControleDeAcesso.Dominio.Contrato;

namespace ControleDeAcesso.Repositorio
{
    public class UsuarioAplicacaoAdo : IRepository<Usuario>
    {
        private void salvar(Usuario usuario)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_usuario_ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }
        private void alterar(Usuario usuario)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_usuario_upd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Codigo);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            int qtdLinhasAfetadas = cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private void excluir(Usuario usuario)
        {
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_usuario_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Codigo);
            cmd.ExecuteNonQuery();
            Connection.closeConnection();
        }

        private ICollection<Usuario> listarTodos()
        {
            ICollection<Usuario> listUsuarios = new List<Usuario>();
            Usuario user;
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_usuario_sel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                user = new Usuario();
                user.Codigo = Convert.ToInt32(reader["idUsuario"]);
                user.Email = reader["email"].ToString();
                user.Senha = reader["senha"].ToString();
                listUsuarios.Add(user);
            }
            reader.Close();

            return listUsuarios;
        }

        private Usuario listarPorId(Usuario usuario)
        {
            Usuario usuarioBusca = new Usuario();
            SqlConnection con = Connection.getConnection();
            SqlCommand cmd = new SqlCommand("sp_usuario_sel_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", usuario.Codigo);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarioBusca.Codigo = Convert.ToInt32(reader["idUsuario"]);
                usuarioBusca.Email = reader["email"].ToString();
                usuarioBusca.Senha = reader["senha"].ToString();

            }

            reader.Close();

            return usuarioBusca;
        }

        //Implementação da Interface

        void IRepository<Usuario>.salvar(Usuario entity)
        {
            salvar(entity);
        }

        void IRepository<Usuario>.alterar(Usuario entity)
        {
            alterar(entity);
        }

        void IRepository<Usuario>.excluir(Usuario entity)
        {
            excluir(entity);
        }

        ICollection<Usuario> IRepository<Usuario>.listarTodos()
        {
            return listarTodos();
        }

        Usuario IRepository<Usuario>.listarPorId(Usuario entity)
        {
            return listarPorId(entity);
        }
    }
}
