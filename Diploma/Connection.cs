using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Diploma
{
    /// <summary>
    /// Something like singleton
    /// </summary>
    class GlobalConnection
    {
        private static SqlConnection connection;
        private static GlobalConnection instance;

        public static SqlConnection Connection
        {
            get
            {
                if (instance == null)
                {
                    throw new NullReferenceException("Подключение не создано");
                }
                else
                {
                    return connection;
                }
            }
            private set
            {
                connection = value;
            }
        }
        public static SqlDataReader Reader { get; private set; }

        private GlobalConnection()
        { }

        public static void SetSQLConnection(SqlConnection con)
        {
            if (instance == null)
            {
                instance = new GlobalConnection();
                Connection = con;
            }
        }
        public static void ExecReader(string query)
        {
            //Connection.Close();
            //Connection.Open();
            //if(Reader != null)
            //    Reader.Close();
            SqlCommand cmd = new SqlCommand(query, Connection);
            Reader = cmd.ExecuteReader();

            //Reader.Close();
        }
        public static void CloseReader()
        {
            Reader.Close();
        }

    }
}
