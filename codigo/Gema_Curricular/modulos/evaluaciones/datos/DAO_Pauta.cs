using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_evaluaciones.entidades;

namespace gema_curricular_evaluaciones.datos
{
    public class DAO_Pauta
    {
        BD bd;


        public DAO_Pauta()
        {
            bd = new BD();
        }
        
        public void Agregar(Pauta pauta)
        {
            if (!Existe(pauta))
            {
                string consulta = "insert into pauta(nombre, descripcion, peso, fecha_creacion) " + 
                                    " values ('" + pauta.Nombre + "', '" + pauta.Descripcion + "', " + 
                                    pauta.Peso + ", " + bd.Formatear_fecha(pauta.Fecha_creacion) + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La pauta ya está registrada en el sistema");
        }
        
        public void Modificar(Pauta pauta)
        {
            if (!Existe(pauta))
            {
                string consulta =   "update pauta " + 
                                    "set nombre='" + pauta.Nombre + "', " + 
                                    "descripcion='" + pauta.Descripcion + "', " + 
                                    "peso=" + pauta.Peso + " " + 
                                    "where id=" + pauta.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La pauta ya está registrada en el sistema");
        }

        public void Eliminar(int id_pauta)
        {   
            //verificando relaciones
            DAO_Pauta_respondida dao_pauta_respondida = new DAO_Pauta_respondida();
            if(dao_pauta_respondida.Verificar_si_pauta_tiene_respuestas(id_pauta))
                throw new Exception("No se puede eliminar la pauta porque tiene respuestas asociadas");
                
            //eliminaciones en cascada
            DAO_Pregunta dao_pregunta = new DAO_Pregunta();
            dao_pregunta.Eliminar_por_pauta(id_pauta);
            
            
            string consulta = "delete from pauta where id=" + id_pauta;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        public Pauta Buscar(int id_pauta)
        {
            string consulta = "select nombre, descripcion, peso, fecha_creacion from pauta where id=" + id_pauta;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Pauta a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Pauta(id_pauta, 
                              dr["nombre"].ToString(), 
                              dr["descripcion"].ToString(), 
                              Convert.ToSingle(dr["peso"]), 
                              Convert.ToDateTime(dr["fecha_creacion"]));
            }

            return a;
        }

        public List<Pauta> Listar()
        {
            string consulta = "select id, nombre, descripcion, peso, fecha_creacion from pauta";

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Pauta> lista = new List<Pauta>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Pauta(  Convert.ToInt32(dr["id"]), 
                                      dr["nombre"].ToString(), 
                                      dr["descripcion"].ToString(), 
                                      Convert.ToSingle(dr["peso"]), 
                                      Convert.ToDateTime(dr["fecha_creacion"])));
            }

            return lista;
        }

        private bool Existe(Pauta a)
        {
            string consulta = "select 1 from pauta where nombre='" + a.Nombre + "' and id<>" + a.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            return dt.Rows.Count > 0;
        }
    }
}
