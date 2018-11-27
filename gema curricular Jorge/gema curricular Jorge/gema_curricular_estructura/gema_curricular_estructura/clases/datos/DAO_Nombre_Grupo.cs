using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular_estructura.clases.comun;
using gema_curricular_estructura.clases.entidades;

namespace gema_curricular_estructura.clases.datos
{
    public class DAO_Nombre_Grupo
    {
        BD bd;


        public DAO_Nombre_Grupo()
        {
            bd = new BD();
        }
        
        public void Agregar(Nombre_Grupo nombre_grupo)
        {
            if (!Existe(nombre_grupo.ID, nombre_grupo.Nombre, nombre_grupo.Categoria))
            {
                string consulta = "insert into nombre_grupo(nombre, id_categoria) values ('" +
                    nombre_grupo.Nombre + "', " +
                    Convert.ToInt32(nombre_grupo.Categoria).ToString() + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else
            {
                throw new Exception("Ya existe un grupo con ese nombre");
            }
        }

        public void Modificar(Nombre_Grupo nombre_grupo)
        {
            if (!Existe(nombre_grupo.ID, nombre_grupo.Nombre, nombre_grupo.Categoria))
            {

                string consulta = "update nombre_grupo set nombre='" + nombre_grupo.Nombre +
                    "', id_categoria=" + Convert.ToInt32(nombre_grupo.Categoria).ToString() +
                    " where id=" + nombre_grupo.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else
            {
                throw new Exception("Ya existe un grupo con ese nombre");
            }
        }

        public void Eliminar(int id_nombre_grupo)
        {
            string consulta = "delete from nombre_grupo where id=" + id_nombre_grupo;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        public bool Existe(int id, string nombre, Categorias_grupos categoria)
        {
            string consulta = "select 1 from nombre_grupo where nombre='" + nombre +
                "' and id_categoria=" + Convert.ToInt32(categoria).ToString() + 
                " and id<>"+ id;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            return dt.Rows.Count > 0;
        }

        public bool Existe(string nombre, Categorias_grupos categoria)
        {
            return Existe(-1, nombre, categoria);
        }

        public Nombre_Grupo Buscar(int id_nombre_grupo)
        {
            string consulta = "select nombre, id_categoria from nombre_grupo where id=" + id_nombre_grupo;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Nombre_Grupo a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Nombre_Grupo(id_nombre_grupo, 
                                    dr["nombre"].ToString(), 
                                    (Categorias_grupos)Convert.ToInt32(dr["id_categoria"]));
            }

            return a;
        }
 
        public List<Nombre_Grupo> Listar()
        {
            string consulta = "select id, nombre, id_categoria from nombre_grupo";

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Nombre_Grupo> lista = new List<Nombre_Grupo>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Nombre_Grupo(Convert.ToInt32(dr["id"]), 
                                            dr["nombre"].ToString(), 
                                            (Categorias_grupos)Convert.ToInt32(dr["id_categoria"])));
            }

            return lista;
        }
    }
}
