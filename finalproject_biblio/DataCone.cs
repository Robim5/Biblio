using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace finalproject_biblio
{
    internal class DataCone
    {
        private MySqlConnection connection;

        public DataCone()
        {
            string conectionstring = "Server=localhost; Database = biblio; Uid = root; Pwd= mysql";

            connection = new MySqlConnection(conectionstring);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
