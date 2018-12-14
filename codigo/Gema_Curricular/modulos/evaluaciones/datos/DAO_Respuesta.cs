using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_evaluaciones.entidades;

namespace gema_curricular_evaluaciones.datos
{
    public class DAO_Respuesta
    {
        BD bd;


        public DAO_Respuesta()
        {
            bd = new BD();
        }
        
        
        
        public void Registrar_respuesta(Respuesta respuesta)
        {
            string consulta = "select 1 from respuesta where id_pauta_respondida=" + respuesta.ID_pauta_respondida + 
                              " and id_pregunta=" + respuesta.ID_pregunta;
                              
            DataTable dt = bd.Ejecutar_comando(consulta);
            
            if(dt.Rows.Count == 0)
            {
                Agregar(respuesta);
            }
            else
            {
                Modificar(respuesta);
            }    
        }
        
        
        private void Agregar(Respuesta respuesta)
        {
            if (!Existe(respuesta))
            {
                string consulta = "insert into respuesta(id_pauta_respondida, id_pregunta, respuesta, nota) " +
                                  "values (" + respuesta.ID_pauta_respondida + ", " + respuesta.ID_pregunta + ", '" + 
                                  respuesta.Respuesta + "', " + respuesta.Nota + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La respuesta ya está registrada en el sistema");
        }
        
        private void Modificar(Respuesta respuesta)
        {
            if (!Existe(respuesta))
            {
                string consulta =   "update respuesta " +
                                    "set respuesta='" + respuesta.Respuesta + "', " +
                                    "nota=" + respuesta.Nota + " " +
                                    "where id_pauta_respondida=" + respuesta.ID_pauta_respondida + " " +
                                    "and id_pregunta=" + respuesta.ID_pregunta;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La respuesta ya está registrada en el sistema");
        }
        
        public void Eliminar(int id_pauta_respondida, int id_pregunta)
        {   
            string consulta = "delete from respuesta where id_pauta_respondida=" + id_pauta_respondida + " " +
                                    "and id_pregunta=" + id_pregunta;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }
        
        public void Eliminar_por_pauta_respondida(int id_pauta_respondida)
        {
            string consulta = "select id_pregunta from respuesta where id_pauta_respondida=" + id_pauta_respondida;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            
            foreach(DataRow dr in dt.Rows)
            {
                Eliminar(id_pauta_respondida, Convert.ToInt32(dr["id_pregunta"]));
            }
        }
        
        public Respuesta Buscar(int id_pauta_respondida, int id_pregunta)
        {
            string consulta = "select respuesta, nota from respuesta where id_pauta_respondida=" + 
                              id_pauta_respondida + " and id_pregunta=" + id_pregunta;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Respuesta a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Respuesta(id_pauta_respondida, 
                                  id_pregunta, 
                                  dr["respuesta"].ToString(), 
                                  Convert.ToSingle(dr["nota"]));
            }

            return a;
        }
        
        public List<Respuesta> Listar(int id_pauta_respondida)
        {
            string consulta = "select respuesta, nota, id_pregunta from respuesta where id_pauta_respondida=" + 
                              id_pauta_respondida;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Respuesta> lista = new List<Respuesta>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Respuesta(id_pauta_respondida, 
                                  Convert.ToInt32(dr["id_pregunta"]), 
                                  dr["respuesta"].ToString(), 
                                  Convert.ToSingle(dr["nota"])));
            }

            return lista;
        }
        
        
        public bool Verificar_si_pregunta_tiene_respuestas(int id_pregunta)
        {
            string consulta = "select 1 from respuesta where id_pregunta=" + id_pregunta;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            
            return dt.Rows.Count > 0;
        }
    }
}
