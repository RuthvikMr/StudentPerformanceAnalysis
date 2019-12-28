using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Analysis
{

    class DB
    {
         private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=login");
        //private SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\Ruthvik m r\documents\visual studio 2015\Projects\Student Performance Analysis\Student Performance Analysis\spa.mdf';Integrated Security = True");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }



        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
        