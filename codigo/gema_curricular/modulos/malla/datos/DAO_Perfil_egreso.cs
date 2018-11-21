using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_malla.entidades;

namespace gema_curricular_malla.datos
{
    public class DAO_Perfil_egreso
    {
        BD bd;


        public DAO_Perfil_egreso()
        {
            bd = new BD();
        }

        public void Agregar(Perfil_egreso perfil)
        {
            if (!Existe(perfil))
            {
                string consulta = "insert into perfil_egreso(nombre, descripcion, peso) values ('" + perfil.Nombre + 
                    "', '" + perfil.Descripcion + "', " + perfil.Peso + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();

                perfil.ID = Buscar_id(perfil);
                
                Guardar_ambitos_desempenno(perfil.ID, perfil.Lista_ambitos_desempeño.ToArray());
                Asociar_categorias(perfil.ID, perfil.Lista_competencias);
            }
            else throw new Exception("Ya está registrado en el sistema");
        }

        public void Modificar(Perfil_egreso perfil)
        {
            if (!Existe(perfil))
            {
                string consulta =   "update perfil_egreso set " +
                                    "nombre='" + perfil.Nombre + "', " +
                                    "descripcion='" + perfil.Descripcion + "', " +
                                    "peso=" + perfil.Peso + " " +
                                    "where id=" + perfil.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();

                Borrar_ambitos_desempenno(perfil.ID);
                Guardar_ambitos_desempenno(perfil.ID, perfil.Lista_ambitos_desempeño.ToArray());

                Desasociar_categorias(perfil.ID);
                Asociar_categorias(perfil.ID, perfil.Lista_competencias);
            }
            else throw new Exception("Ya está registrado en el sistema");
        }

        public void Eliminar(int id_perfil)
        {
            Borrar_ambitos_desempenno(id_perfil);
            
            
            string consulta = "delete from perfil_egreso where id=" + id_perfil;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        public Perfil_egreso Buscar(int id_perfil)
        {
            string consulta = "select nombre, descripcion, peso from perfil_egreso where id=" + id_perfil;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Perfil_egreso a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Perfil_egreso(id_perfil, 
                                  dr["nombre"].ToString(),
                                  dr["descripcion"].ToString(),
                                  Convert.ToSingle(dr["peso"]));

                a.Lista_ambitos_desempeño = Listar_ambitos_desempenno(a.ID).ToList();
                a.Lista_competencias = Listar_categorias_asociadas(a.ID);
            }

            return a;
        }

        public List<Perfil_egreso> Listar()
        {
            string consulta = "select id, nombre, descripcion, peso from perfil_egreso";

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Perfil_egreso> lista = new List<Perfil_egreso>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Perfil_egreso(Convert.ToInt32(dr["id"]),
                                          dr["nombre"].ToString(),
                                          dr["descripcion"].ToString(),
                                          Convert.ToSingle(dr["peso"])));
            }

            return lista;
        }

        private bool Existe(Perfil_egreso a)
        {
            string consulta = "select 1 from perfil_egreso where nombre='" + a.Nombre + 
                "' and descripcion='" + a.Descripcion + 
                "' and id<>" + a.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            return dt.Rows.Count > 0;
        }

        private int Buscar_id(Perfil_egreso a)
        {
            string consulta = "select id from perfil_egreso where nombre='" + a.Nombre +
                "' and descripcion='" + a.Descripcion + "'";
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            if(dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["id"]);
            }
            else
            {
                return -1;
            }
        }


        //---------------------------  MÉTODOS DE RELACIONES  -------------------------------------------

        private void Guardar_ambitos_desempenno(int id_perfil_egreso, string[] lista_ambitos)
        {
            string consulta = "";

            foreach (string ambito in lista_ambitos)
            {
                consulta = "insert into rel_perf_eg_amb_des(id_perfil_egreso, ambito) values (" + 
                    id_perfil_egreso + ", '" + ambito + "')";
                bd.Ejecutar_comando(consulta);
            }

            bd.Cerrar();
        }

        private void Borrar_ambitos_desempenno(int id_perfil_egreso)
        {
            string consulta = "delete from rel_perf_eg_amb_des where id_perfil_egreso=" + id_perfil_egreso;
            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        private string[] Listar_ambitos_desempenno(int id_perfil_egreso)
        {
            string consulta = "select ambito from rel_perf_eg_amb_des where id_perfil_egreso=" + id_perfil_egreso;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            string[] lista = new string[dt.Rows.Count];

            for (int i = 0; i < lista.Length; i++)
			{
                lista[i] = dt.Rows[i]["ambito"].ToString();
			}

            return lista;
        }


        private void Asociar_categorias(int id_perfil_egreso, List<Categoria> lista_categorias)
        {
            string consulta = "";

            for (int i = 0; i < lista_categorias.Count; i++)
            {
                consulta = "insert into rel_perf_eg_cat(id_perfil, id_categoria) values (" +
                    id_perfil_egreso + ", " + lista_categorias[i].ID + ")";
                bd.Ejecutar_comando(consulta);
            }

            bd.Cerrar();
        }

        private void Desasociar_categorias(int id_perfil_egreso)
        {
            string consulta = "delete from rel_perf_eg_cat where id_perfil=" + id_perfil_egreso;
            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        private List<Categoria> Listar_categorias_asociadas(int id_perfil_egreso)
        {
            string consulta = "select id_categoria from rel_perf_eg_cat where id_perfil=" + id_perfil_egreso;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            int[] lista = new int[dt.Rows.Count];

            for (int i = 0; i < lista.Length; i++)
            {
                lista[i] = Convert.ToInt32(dt.Rows[0]["id_categoria"]);
            }

            DAO_Categoria dao_categoria = new DAO_Categoria();
            return dao_categoria.Listar_por_ids(lista);
        }
    }
}
