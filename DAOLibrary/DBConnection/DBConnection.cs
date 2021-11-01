using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary.DBConnection
{
    public class DBConnection
    {
        public MySqlConnection Connection;
        private DBConnection(string ConnectionString)
        {
            try
            {
                Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
            }
            catch (MySqlException expp)
            {

            }
        }
    }
}