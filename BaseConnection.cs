using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
https://github.com/AfinMuhammed/HTML
namespace BlockchainWithFingerprint
{
    class BaseConnection
    {
        public SqlDataReader dr;
        public DataSet ds = new DataSet();
        public SqlConnection con()
        {
            SqlConnection con = new SqlConnection("server=localhost;database=BlockchainFingerprint;uid=sa;pwd=yuva");
            con.Open();
            return con;
        }
        public void exec(string str)
        {
            SqlCommand cmd = new SqlCommand(str, con());
            cmd.ExecuteNonQuery();
        }
        public int exec1(string str)
        {
            SqlCommand cmd = new SqlCommand(str, con());
            return cmd.ExecuteNonQuery();
        }
        public SqlDataReader ret_dr(string str)
        {
            SqlCommand cmd = new SqlCommand(str, con());
            return cmd.ExecuteReader();
        }
        public DataSet ret_ds(string str)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(str, con());
            sqlda.Fill(ds);
            return ds;
        }
    }
}
