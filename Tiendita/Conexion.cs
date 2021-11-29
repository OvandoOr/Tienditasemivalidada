using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tiendita
{
    public class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection();
            conectar.ConnectionString = "Server=localhost;Database=examen; Uid=root;Pwd=mysqlpasswordspringday0635.;";
            conectar.Open();
            return conectar;
        }
    }
}
