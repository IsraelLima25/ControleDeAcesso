using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso.Repositorio.Conexao
{
    public class Connection
    {
        private static SqlConnection connection = null;

        public static SqlConnection getConnection()
        {
            if (connection==null) {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
                connection.Open();
                return connection;
            }
            return connection;
        }

        public static void closeConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }
    }
}
