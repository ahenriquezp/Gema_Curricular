using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_evaluaciones.entidades;

namespace gema_curricular_evaluaciones.datos
{
    public class DAO_Pauta_respondida
    {
        BD bd;


        public DAO_Pauta_respondida()
        {
            bd = new BD();
        }
        
        public void Agregar(Pauta_respondida pauta)
        {   
            string consulta = "insert into pauta_respondida(id_pauta, id_estudiante, fecha_respuesta) " +
                              "values (" + pauta.ID_pauta + ", " + pauta.ID_estudiante + ", " + 
                              bd.Formatear_fecha(pauta.Fecha_respuesta) + ")";

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }
        
        public void Eliminar(int id_pauta_respondida)
        {   
            //eliminaciones en cascada
            DAO_Respuesta dao_respuesta = new DAO_Respuesta();
            dao_respuesta.Eliminar_por_pauta_respondida(id_pauta_respondida);
            
            
            string consulta = "delete from pauta_respondida where id=" + id_pauta_respondida;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }
        
        public Pauta_respondida Buscar(int id_pauta_respondida)
        {
            string consulta = "select id_pauta, id_estudiante, fecha_respuesta from pauta_respondida where id=" + id_pauta_respondida;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Pauta_respondida a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Pauta_respondida(id_pauta_respondida, 
                                         Convert.ToInt32(dr["id_pauta"]), 
                                         Convert.ToInt32(dr["id_estudiante"]), 
                                         Convert.ToDateTime(dr["fecha_respuesta"]));
                                         
                DAO_Respuesta dao_respuesta = new DAO_Respuesta();
                a.Lista_respuestas = dao_respuesta.Listar(id_pauta_respondida);
            }

            return a;
        }

        public List<Pauta_respondida> Listar(int id_estudiante)
        {
            string consulta = "select id, id_pauta, fecha_respuesta from pauta_respondida where id_estudiante=" + id_estudiante;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Pauta_respondida> lista = new List<Pauta_respondida>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Pauta_respondida(Convert.ToInt32(dr["id"]), 
                                               Convert.ToInt32(dr["id_pauta"]), 
                                               id_estudiante, 
                                               Convert.ToDateTime(dr["fecha_respuesta"])));
            }

            return lista;
        }
        
        public bool Verificar_si_pauta_tiene_respuestas(int id_pauta)
        {
            string consulta = "select 1 from pauta_respondida where id_pauta=" + id_pauta;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            
            return dt.Rows.Count > 0;
        }
    }
}
