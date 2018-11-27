using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_estructura.entidades;

namespace gema_curricular_estructura.datos
{
    public class DAO_Asignatura
    {
        BD bd;


        public DAO_Asignatura()
        {
            bd = new BD();
        }
        
        public void Agregar(Asignatura asignatura)
        {
            if (!Existe(asignatura))
            {
                string consulta = "insert into asignatura(nombre, peso) values ('" +
                    asignatura.Nombre + "', " +
                    asignatura.Peso + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La asignatura ya está registrada en el sistema");
        }

        public void Modificar(Asignatura asignatura)
        {
            if (!Existe(asignatura))
            {
                string consulta = "update asignatura set nombre='" + asignatura.Nombre + 
                    "', peso=" + asignatura.Peso + 
                    " where id=" + asignatura.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La asignatura ya está registrada en el sistema");
        }

        public void Eliminar(int id_asignatura)
        {   
            string consulta = "delete from asignatura where id=" + id_asignatura;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        public Asignatura Buscar(int id_asignatura)
        {
            string consulta = "select nombre, peso from asignatura where id=" + id_asignatura;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Asignatura a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Asignatura(id_asignatura, dr["nombre"].ToString(), Convert.ToSingle(dr["peso"]));
            }

            return a;
        }

        public List<Asignatura> Listar()
        {
            string consulta = "select id, nombre, peso from asignatura";

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Asignatura> lista = new List<Asignatura>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Asignatura(Convert.ToInt32(dr["id"]), 
                                    dr["nombre"].ToString(), 
                                    Convert.ToSingle(dr["peso"])));
            }

            return lista;
        }

        private bool Existe(Asignatura a)
        {
            string consulta = "select 1 from asignatura where nombre='" + a.Nombre + "' and id<>" + a.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            return dt.Rows.Count > 0;
        }
    }
}
