using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosAcceso
{
    public class Customers
    {

        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }

    public class DataBase
    {
        public static string ConnectionString
        { 
            get
            {
                return ConfigurationManager.ConnectionStrings["NWConnectionString"].ConnectionString;
            }
        }

        public static SqlConnection GetSqlConnection() 
        { 
            SqlConnection conexion = new SqlConnection(ConnectionString);
            conexion.Open();
            return conexion;
        }

        
    }
}
