using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_evaluaciones.entidades;

namespace gema_curricular_evaluaciones.datos
{
    public class DAO_Pregunta
    {
        BD bd;


        public DAO_Pregunta()
        {
            bd = new BD();
        }
        
        public void Agregar(Pregunta pregunta)
        {
            if (!Existe(pregunta))
            {
                string consulta = "insert into pregunta(texto, alternativa_correcta, peso, id_pauta) " + 
                                  "values ('" + pregunta.Texto + "', '" + pregunta.Alternativa_correcta + "', " + 
                                  pregunta.Peso + ", " + pregunta.ID_pauta + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La pregunta ya está registrada en el sistema");
        }
        
        public void Modificar(Pregunta pregunta)
        {
            if (!Existe(pregunta))
            {
                string consulta =   "update pregunta set " + 
                                    "texto='" + pregunta.Texto + "', " + 
                                    "alternativa_correcta='" + pregunta.Alternativa_correcta + "', " + 
                                    "peso=" + pregunta.Peso + " " + 
                                    "where id=" + pregunta.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La pregunta ya está registrada en el sistema");
        }
  
        public void Eliminar(int id_pregunta)
        {   
            //verificando relaciones
            DAO_Respuesta dao_respuesta = new DAO_Respuesta();
            if(dao_respuesta.Verificar_si_pregunta_tiene_respuestas(id_pregunta))
                throw new Exception("No se puede eliminar la pregunta porque tiene respuestas asociadas");
            
            
            string consulta = "delete from pregunta where id=" + id_pregunta;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }
        
        public void Eliminar_por_pauta(int id_pauta)
        {
            string consulta = "select id from pregunta where id_pauta=" + id_pauta;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            
            foreach(DataRow dr in dt.Rows)
            {
                Eliminar(Convert.ToInt32(dr["id"]));
            }
        }
        
        public Pregunta Buscar(int id_pregunta)
        {
            string consulta = "select texto, alternativa_correcta, peso, id_pauta from pregunta where id=" + id_pregunta;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Pregunta a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Pregunta(id_pregunta, 
                                 dr["texto"].ToString(), 
                                 dr["alternativa_correcta"].ToString(), 
                                 Convert.ToSingle(dr["peso"]), 
                                 Convert.ToInt32(dr["id_pauta"]));
            }

            return a;
        }

        public List<Pregunta> Listar(int id_pauta)
        {
            string consulta = "select id, texto, alternativa_correcta, peso from pregunta where id_pauta=" + id_pauta;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Pregunta> lista = new List<Pregunta>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Pregunta(  Convert.ToInt32(dr["id"]), 
                                         dr["texto"].ToString(), 
                                         dr["alternativa_correcta"].ToString(), 
                                         Convert.ToSingle(dr["peso"]), 
                                         id_pauta));
            }

            return lista;
        }

        private bool Existe(Pregunta a)
        {
            string consulta =   "select 1 from pregunta where texto='" + a.Texto + 
                                "' and id_pauta=" + a.ID_pauta + " and id<>" + a.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            return dt.Rows.Count > 0;
        }
    }
}
