using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace agenda
{
    public class Conexion
    {
        string connectionString;
        public Conexion()
        {
            connectionString = ConfigurationManager.ConnectionStrings["agenda"].ConnectionString;
            //connectionString = ConfigurationManager.ConnectionStrings["localCASA"].ConnectionString;
            //connectionString = ConfigurationManager.ConnectionStrings["Connection175"].ConnectionString;
            //connectionString = ConfigurationManager.ConnectionStrings["Connection176"].ConnectionString;
        }

        public DataTable getDataTable(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();
            reader = cmd.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            return dataTable;
        }

        public int insertQuery(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();

            Int32 newId = (Int32)cmd.ExecuteScalar();
            con.Close();

            return newId;
        }

        public void updateQuery(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int getCount(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();

            Int32 count = (Int32)cmd.ExecuteScalar();
            con.Close();

            return count;
        }
    }
}