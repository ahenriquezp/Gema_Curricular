using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_estructura.entidades;

namespace gema_curricular_estructura.datos
{
    public class DAO_Carrera
    {
        BD bd;
        DAO_Nombre_Grupo dao_nombre_grupo;

        public DAO_Carrera()
        {
            bd = new BD();
            dao_nombre_grupo = new DAO_Nombre_Grupo();
        }
        
        public void Agregar(Carrera carrera)
        {
            if (!Existe(carrera))
            {
                if (!dao_nombre_grupo.Existe(carrera.Nombre_facultad.ID))
                {
                    throw new Exception("No se puede agregar la carrera porque la facultad a la que pertenece " +
                                        "no está registrada en el sistema");
                }

                if (!dao_nombre_grupo.Existe(carrera.Nombre_carrera.Nombre, carrera.Nombre_carrera.Categoria))
                {
                    carrera.Nombre_carrera.ID = dao_nombre_grupo.Agregar(carrera.Nombre_carrera);
                }

                string consulta = "insert into carrera(id_nombre_facultad, id_nombre_carrera) values (" +
                    carrera.Nombre_facultad.ID + ", " +
                    carrera.Nombre_carrera.ID + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La carrera ya está registrada en el sistema");
        }

        public void Modificar(Carrera carrera)
        {
            if (!Existe(carrera))
            {
                if (!dao_nombre_grupo.Existe(carrera.Nombre_facultad.ID))
                {
                    throw new Exception("No se puede modificar la carrera porque la nueva facultad a la que pertenece " +
                                        "no está registrada en el sistema");
                }

                if (!dao_nombre_grupo.Existe(carrera.Nombre_carrera.Nombre, carrera.Nombre_carrera.Categoria))
                {
                    carrera.Nombre_carrera.ID = dao_nombre_grupo.Agregar(carrera.Nombre_carrera);
                }


                string consulta = "update carrera set id_nombre_facultad=" + carrera.Nombre_facultad.ID +
                    ", id_nombre_carrera=" + carrera.Nombre_carrera.ID +
                    " where id=" + carrera.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La carrera ya está registrada en el sistema");
        }

        public void Eliminar(int id_carrera)
        {
            //eliminaciones en cascada
            DAO_Seccion dao_seccion = new DAO_Seccion();
            dao_seccion.Eliminar_por_carrera(id_carrera);


            
            string consulta = "delete from carrera where id=" + id_carrera;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        public void Eliminar_por_facultad(int id_facultad)
        {
            string consulta = "select id from carrera where id_nombre_facultad=" + id_facultad;
            DataTable dt = bd.Ejecutar_consulta(consulta);

            foreach (DataRow dr in dt.Rows)
            {
                Eliminar(Convert.ToInt32(dr["id"]));
            }
        }

        public Carrera Buscar(int id_carrera)
        {
            string consulta = "select " + 
                                "ng_fac.id as id_facultad, " + 
                                "ng_fac.nombre as nombre_facultad, " + 
                                "ng_carr.id as id_nombre_carrera, " + 
                                "ng_carr.nombre as nombre_carrera " + 
                                "from carrera carr " + 
                                "inner join nombre_grupo ng_fac on carr.id_nombre_facultad=ng_fac.id " + 
                                "inner join nombre_grupo ng_carr on carr.id_nombre_carrera=ng_carr.id " + 
                                "where carr.id=" + id_carrera;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Carrera a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                Nombre_Grupo nombre_facultad = new Nombre_Grupo(Convert.ToInt32(dr["id_facultad"]),
                                                                dr["nombre_facultad"].ToString(), 
                                                                Categorias_grupos.Facultad);

                Nombre_Grupo nombre_carrera = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_carrera"]),
                                                                dr["nombre_carrera"].ToString(),
                                                                Categorias_grupos.Carrera);


                a = new Carrera(id_carrera,
                                nombre_carrera,
                                nombre_facultad);
            }

            return a;
        }
 
        public List<Carrera> Listar()
        {
            string consulta =   "select " +
                                "carr.id, " + 
                                "ng_fac.id as id_facultad, " +
                                "ng_fac.nombre as nombre_facultad, " +
                                "ng_carr.id as id_nombre_carrera, " +
                                "ng_carr.nombre as nombre_carrera " +
                                "from carrera carr " +
                                "inner join nombre_grupo ng_fac on carr.id_nombre_facultad=ng_fac.id " +
                                "inner join nombre_grupo ng_carr on carr.id_nombre_carrera=ng_carr.id";

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Carrera> lista = new List<Carrera>();

            foreach (DataRow dr in dt.Rows)
            {
                Nombre_Grupo nombre_facultad = new Nombre_Grupo(Convert.ToInt32(dr["id_facultad"]),
                                                                dr["nombre_facultad"].ToString(),
                                                                Categorias_grupos.Facultad);

                Nombre_Grupo nombre_carrera = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_carrera"]),
                                                                dr["nombre_carrera"].ToString(),
                                                                Categorias_grupos.Carrera);




                lista.Add(new Carrera(Convert.ToInt32(dr["id"]),
                                nombre_carrera,
                                nombre_facultad));
            }

            return lista;
        }

        public bool Existe(int id_carrera)
        {
            string consulta = "select 1 from carrera where id=" + id_carrera;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            return dt.Rows.Count > 0;
        }

        private bool Existe(Carrera carrera)
        {
            string consulta = "select 1 from carrera where id_nombre_facultad=" + 
                                carrera.Nombre_facultad.ID + " and id_nombre_carrera=" + 
                                carrera.Nombre_carrera.ID + " and id<>" + 
                                carrera.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            return dt.Rows.Count > 0;
        }

    }
}
