using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace gema_curricular_estructura.clases.comun
{
    internal class BD
    {
        private SqlConnection conexion;

        public BD()
        {
            conexion = new SqlConnection(ConfigurationSettings.AppSettings["conexion"]);
        }

        public string Formatear_fecha(DateTime fecha)
        {
            return "'" + fecha.ToString("yyyyMMdd HH:mm:ss") + "'";
        }

        private void Abrir()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
        }

        public void Cerrar()
        {
            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
        }

        public void Ejecutar_comando(string consulta)
        {
            Abrir(); //en caso de que la conexion este cerrada, la abre para poder conectarse
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            comando.Dispose();
        }

        public DataTable Ejecutar_consulta(string consulta)
        {
            Abrir(); //en caso de que la conexion este cerrada, la abre para poder conectarse
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            adapter.Dispose();
            comando.Dispose();
            return dt;
        }
    }
}
