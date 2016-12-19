using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXT.SQLDBDataAccess
{
    public abstract class DBAccess
    {
        // Constructor
        public DBAccess(string connectionString)
        {
            SqlConConnectionString = connectionString;
        }

        private string SqlConConnectionString { get; set; }

        // Used for select statements, to return a list of data. 
        // The ExecReader function executes the SQL query and returns the results.
        public DataTable ExecReader(SqlCommand sqlcomm)
        {
            SqlConnection m_SqlCon = new SqlConnection();
            m_SqlCon.ConnectionString = SqlConConnectionString;

            sqlcomm.Connection = m_SqlCon;

            DataTable dt = new DataTable();
            m_SqlCon.Open();

            dt.Load(sqlcomm.ExecuteReader());

            m_SqlCon.Close();

            return dt;
        }

        // Used for returning a single value from a query. 
        // Useful when inserting to a table using an Identity column as the Primary Key.
        public object ExecScalar(SqlCommand sqlcomm)
        {
            SqlConnection m_SqlCon = new SqlConnection();
            m_SqlCon.ConnectionString = SqlConConnectionString;

            sqlcomm.Connection = m_SqlCon;

            m_SqlCon.Open();

            object o = sqlcomm.ExecuteScalar();

            m_SqlCon.Close();

            return o;
        }

        // Used for executing statements with no return value, such as Update or Delete statements.
        public void ExecNonQuery(SqlCommand sqlcomm)
        {
            SqlConnection m_SqlCon = new SqlConnection();
            m_SqlCon.ConnectionString = SqlConConnectionString;

            sqlcomm.Connection = m_SqlCon;

            m_SqlCon.Open();

            sqlcomm.ExecuteNonQuery();

            m_SqlCon.Close();
        }
    }
}
