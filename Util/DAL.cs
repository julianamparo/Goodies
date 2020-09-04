using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Goodies.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "dbcliente";
        private static string user = "root";
        private static string Password = "burger";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={Database};Uid={user};Pwd={Password};sslmode=Required;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        public void ExecutarComandoSQL(string comando)
        {
            MySqlCommand command = new MySqlCommand(comando, Connection);
            command.ExecuteNonQuery();


        }

        public DataTable RetornarDatatable(string comando)
        {
            MySqlCommand command = new MySqlCommand(comando, Connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dados = new DataTable();
            dataAdapter.Fill(dados);
            return dados;
        }

    }
}