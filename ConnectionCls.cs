using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TaskAssignmentApp
{
    public class ConnectionCls
    {
        SqlConnection con;
        SqlCommand cmd;

        public ConnectionCls()
        {
            con = new SqlConnection(@"server=DESKTOP-8PBBHUD\SQLEXPRESS;database=TaskMgmtDB;integrated security=true;");
        }
        

        public int fn_ExecNonQuery(string Qry)
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(Qry, con);
            con.Open();
            int st= cmd.ExecuteNonQuery();
            con.Close();
            return st;
        }

        public string fn_ExecScalar(string qry)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(qry, con);
            con.Open();
            string val = cmd.ExecuteScalar().ToString();
            con.Close();
            return val;
        }

        public SqlDataReader fn_ExecReader(string qry)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DataSet fn_Adapter(string qry)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

    }
}