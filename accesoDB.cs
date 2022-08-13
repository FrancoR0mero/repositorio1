using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace TUP_PI_Recuperatorio_1W4B
{
    internal class accesoDB
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=138.99.7.66,1433;Initial Catalog=Consultorio;User ID=tup1_consultorio;Password=5@tUp1");
        SqlCommand comando = new SqlCommand();


        public void conectar()
        {
            conexion.Open();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;

        }
        public void desconectar()
        {
            conexion.Close();
        }


        public DataTable consultaDB(string consulta)
        {
            DataTable tabla = new DataTable();
            conectar();
            comando.CommandText = consulta;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
        
        public void OBD(string SQL)
        {
            conectar();
            comando.CommandText = SQL;
            comando.ExecuteNonQuery();
            desconectar();
            
        }






    }
}
