using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_malla.entidades;

namespace gema_curricular_malla.datos
{
    public class DAO_Categoria
    {
        BD bd;


        public DAO_Categoria()
        {
            bd = new BD();
        }
        
        public void Agregar(Categoria categoria)
        {
            if (!Existe(categoria))
            {
                string consulta = "insert into categoria(nombre, id_tipo_categoria, peso) values ('" + 
                    categoria.Nombre + "', " + 
                    Convert.ToInt32(categoria.Tipo).ToString() + ", " + 
                    categoria.Peso + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();

                categoria.ID = Buscar_id(categoria);
                Asociar_categorias(categoria, categoria.Lista_padres);
            }
            else throw new Exception("Ya está registrada en el sistema");
        }

        public void Modificar(Categoria categoria)
        {
            if (!Existe(categoria))
            {
                string consulta =   "update categoria set " + 
                                    "nombre='" + categoria.Nombre + "', " + 
                                    "id_tipo_categoria=" + Convert.ToInt32(categoria.Tipo).ToString() + "," + 
                                    "peso=" + categoria.Peso + " " + 
                                    "where id=" + categoria.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();

                Desasociar_categorias_padres(categoria.ID);
                Asociar_categorias(categoria, categoria.Lista_padres);
            }
            else throw new Exception("Ya está registrada en el sistema");
        }

        public void Eliminar(int id_categoria)
        {
            Desasociar_categorias_padres(id_categoria);
            Desasociar_categorias_hijas(id_categoria);
            
            string consulta = "delete from categoria where id=" + id_categoria;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        public Categoria Buscar(int id_categoria)
        {
            string consulta = "select nombre, id_tipo_categoria, peso from categoria where id=" + id_categoria;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Categoria a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Categoria(id_categoria, 
                                  dr["nombre"].ToString(),
                                  (Tipo_categoria)Convert.ToInt32(dr["id_tipo_categoria"]), 
                                  Convert.ToSingle(dr["peso"]));

                a.Lista_padres = Listar_padres(a.ID);
            }

            return a;
        }

        public List<Categoria> Listar()
        {
            string consulta = "select id, nombre, id_tipo_categoria, peso from categoria";

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Categoria> lista = new List<Categoria>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Categoria(  Convert.ToInt32(dr["id"]), 
                                          dr["nombre"].ToString(),
                                          (Tipo_categoria)Convert.ToInt32(dr["id_tipo_categoria"]), 
                                          Convert.ToSingle(dr["peso"])));
            }

            return lista;
        }

        public List<Categoria> Listar_por_ids(int[] ids)
        {
            List<Categoria> lista = new List<Categoria>();

            string consulta = "";
            
            for (int i = 0; i < ids.Length; i++)
            {
                if (consulta != "")
                {
                    consulta += ",";
                }
                consulta += ids[i];
                
                if(i % 990 == 0)
                {
                    consulta = "select id, nombre, id_tipo_categoria, peso from categoria where id in (" + consulta + ")";
                
                    DataTable dt = bd.Ejecutar_consulta(consulta);

                    consulta = "";

                    foreach (DataRow dr in dt.Rows)
                    {
                        lista.Add(new Categoria(Convert.ToInt32(dr["id"]),
                                                  dr["nombre"].ToString(),
                                                  (Tipo_categoria)Convert.ToInt32(dr["id_tipo_categoria"]),
                                                  Convert.ToSingle(dr["peso"])));
                    }
                }
            }
            
            bd.Cerrar();

            return lista;
        }

        private bool Existe(Categoria a)
        {
            string consulta = "select 1 from categoria where nombre='" + a.Nombre + 
                "' and id_tipo_categoria=" + Convert.ToInt32(a.Tipo).ToString() + 
                " and id<>" + a.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();
            return dt.Rows.Count > 0;
        }

        private int Buscar_id(Categoria a)
        {
            string consulta = "select id from categoria where nombre='" + a.Nombre +
                "' and id_tipo_categoria=" + Convert.ToInt32(a.Tipo).ToString();
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

        //------------------ RELACIONES ENTRE CATEGORÍAS  -------------------------------

        private void Asociar_categorias(Categoria categoria_hija, List<Categoria> lista_categorias_padres)
        {
            string consulta = "";

            for(int i = 0; i < lista_categorias_padres.Count; i++)
            {
                consulta = "insert into relacion_categorias(id_padre, id_hija) values (" + 
                    lista_categorias_padres[i].ID + ", " + categoria_hija.ID + ")";
                bd.Ejecutar_comando(consulta.ToString());
            }

            bd.Cerrar();
        }

        private void Desasociar_categorias_padres(int id_categoria_hija)
        {
            string consulta = "delete from relacion_categorias where id_hija=" + id_categoria_hija;
            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        private void Desasociar_categorias_hijas(int id_categoria_padre)
        {
            string consulta = "delete from relacion_categorias where id_padre=" + id_categoria_padre;
            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        private List<Categoria> Listar_padres(int id_categoria)
        {
            string consulta = "select id_padre from relacion_categorias where id_hija=" + id_categoria;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            int[] lista = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lista[i] = Convert.ToInt32(dt.Rows[i]["id"]);
            }

            return Listar_por_ids(lista);
        }

        private List<Categoria> Listar_hijas(int id_categoria)
        {
            string consulta = "select id_hija from relacion_categorias where id_padre=" + id_categoria;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            int[] lista = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lista[i] = Convert.ToInt32(dt.Rows[i]["id"]);
            }

            return Listar_por_ids(lista);
        }
    }
}
