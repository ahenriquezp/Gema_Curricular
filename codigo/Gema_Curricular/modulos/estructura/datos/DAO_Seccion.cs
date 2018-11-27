using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_estructura.entidades;

namespace gema_curricular_estructura.datos
{
    public class DAO_Seccion
    {
        BD bd;
        DAO_Nombre_Grupo dao_nombre_grupo;
        DAO_Carrera dao_carrera;

        public DAO_Seccion()
        {
            bd = new BD();
            dao_nombre_grupo = new DAO_Nombre_Grupo();
            dao_carrera = new DAO_Carrera();
        }

        public void Agregar(Seccion seccion)
        {
            if (!Existe(seccion))
            {
                if (!dao_nombre_grupo.Existe(seccion.Nombre_sede.ID))
                {
                    throw new Exception("No se puede agregar la sección porque la sede a la que pertenece "+
                                        "no está registrada en el sistema");
                }

                if (!dao_carrera.Existe(seccion.Carrera.ID))
                {
                    throw new Exception("No se puede agregar la sección porque la carrera a la que pertenece " +
                                        "no está registrada en el sistema");
                }

                if (!dao_nombre_grupo.Existe(seccion.Nombre.Nombre, seccion.Nombre.Categoria))
                {
                    seccion.Nombre.ID = dao_nombre_grupo.Agregar(seccion.Nombre);
                }
                
                string consulta = "insert into seccion(id_nombre, id_nombre_sede, id_entidad_carrera, anno, nivel, id_periodo) " + 
                                  "values (" +  seccion.Nombre.ID + 
                                  ", " + seccion.Nombre_sede.ID + 
                                  ", " + seccion.Carrera.ID + 
                                  ", " + seccion.Anno +
                                  ", " + seccion.Nivel + 
                                  ", " + Convert.ToInt32(seccion.Periodo).ToString() + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La sección ya está registrada en el sistema");
        }

        public void Modificar(Seccion seccion)
        {
            if (!Existe(seccion))
            {
                if (!dao_nombre_grupo.Existe(seccion.Nombre_sede.ID))
                {
                    throw new Exception("No se puede modificar la sección porque la nueva sede a la que pertenece " +
                                        "no está registrada en el sistema");
                }

                if (!dao_carrera.Existe(seccion.Carrera.ID))
                {
                    throw new Exception("No se puede agregmodificarar la sección porque la nueva carrera a la que pertenece " +
                                        "no está registrada en el sistema");
                }

                if (!dao_nombre_grupo.Existe(seccion.Nombre.Nombre, seccion.Nombre.Categoria))
                {
                    seccion.Nombre.ID = dao_nombre_grupo.Agregar(seccion.Nombre);
                }

                string consulta = "update seccion set " +
                                    "id_nombre=" + seccion.Nombre.ID + " ," +
                                    "id_nombre_sede=" + seccion.Nombre_sede.ID + " ," +
                                    "id_entidad_carrera=" + seccion.Carrera.ID + " ," +
                                    "anno=" + seccion.Anno + " ," +
                                    "nivel=" + seccion.Nivel + " ," +
                                    "id_periodo=" + Convert.ToInt32(seccion.Periodo).ToString() + " " +
                                    "where id=" + seccion.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La sección ya está registrada en el sistema");
        }

        public void Eliminar(int id_seccion)
        {
            string consulta = "delete from seccion where id=" + id_seccion;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }



        public void Eliminar_por_carrera(int id_carrera)
        {
            string consulta = "select id from seccion where id_entidad_carrera=" + id_carrera;
            DataTable dt = bd.Ejecutar_consulta(consulta);

            foreach (DataRow dr in dt.Rows)
            {
                Eliminar(Convert.ToInt32(dr["id"]));
            }
        }

        public void Eliminar_por_sede(int id_sede)
        {
            string consulta = "select id from seccion where id_nombre_sede=" + id_sede;
            DataTable dt = bd.Ejecutar_consulta(consulta);

            foreach (DataRow dr in dt.Rows)
            {
                Eliminar(Convert.ToInt32(dr["id"]));
            }
        }




        public Seccion Buscar(int id_seccion)
        {
            string consulta =   "select  " + 

                                "sec.id, " + 
                                 
                                "ng_sec.id as id_nombre_seccion, " + 
                                "ng_sec.nombre as nombre_seccion, " + 

                                "ng_sede.id as id_nombre_sede, " + 
                                "ng_sede.nombre as nombre_sede, " + 
                                 
                                "car.id as id_carrera, " + 
                                "ng_carr.id as id_nombre_carrera, " + 
                                "ng_carr.nombre as nombre_carrera, " + 
                                 
                                "sec.anno, " + 
                                "sec.nivel, " + 
                                "sec.id_periodo" + 
                                 
                                "from seccion sec " + 
                                "inner join nombre_grupo ng_sec on sec.id_nombre=ng_sec.id " + 
                                "inner join nombre_grupo ng_sede on sec.id_nombre_sede=ng_sede.id " + 
                                "inner join carrera car on sec.id_entidad_carrera=car.id " + 
                                "inner join nombre_grupo ng_carr on car.id_nombre_carrera=ng_carr.id " + 

                                "where sec.id=" + id_seccion;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Seccion a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                Nombre_Grupo nombre_seccion = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_seccion"]),
                                                                dr["nombre_seccion"].ToString(), 
                                                                Categorias_grupos.Seccion);

                Nombre_Grupo nombre_sede = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_sede"]),
                                                                dr["nombre_sede"].ToString(),
                                                                Categorias_grupos.Sede);

                Nombre_Grupo nombre_carrera = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_carrera"]),
                                                                dr["nombre_carrera"].ToString(),
                                                                Categorias_grupos.Carrera);

                Carrera carrera = new Carrera(Convert.ToInt32(dr["id_carrera"]), nombre_carrera, null);


                a = new Seccion(Convert.ToInt32(dr["id"]), 
                                nombre_seccion, 
                                nombre_sede,
                                carrera, 
                                Convert.ToInt32(dr["anno"]),
                                (Periodos)Convert.ToInt32(dr["id_periodo"]), 
                                Convert.ToInt32(dr["nivel"]));
            }

            return a;
        }

        //este método se debe descomentariar cuando se definan los parámetros que debe llevar
 
        //public List<Seccion> Listar()
        //{
        //    string consulta = "select  " +

        //                        "sec.id, " +

        //                        "ng_sec.id as id_nombre_seccion, " +
        //                        "ng_sec.nombre as nombre_seccion, " +

        //                        "ng_sede.id as id_nombre_sede, " +
        //                        "ng_sede.nombre as nombre_sede, " +

        //                        "car.id as id_carrera, " +
        //                        "ng_carr.id as id_nombre_carrera, " +
        //                        "ng_carr.nombre as nombre_carrera, " +

        //                        "sec.anno, " +
        //                        "sec.nivel, " +
        //                        "sec.id_periodo" +

        //                        "from seccion sec " +
        //                        "inner join nombre_grupo ng_sec on sec.id_nombre=ng_sec.id " +
        //                        "inner join nombre_grupo ng_sede on sec.id_nombre_sede=ng_sede.id " +
        //                        "inner join carrera car on sec.id_entidad_carrera=car.id " +
        //                        "inner join nombre_grupo ng_carr on car.id_nombre_carrera=ng_carr.id";

        //    DataTable dt = bd.Ejecutar_consulta(consulta);
        //    bd.Cerrar();

        //    List<Seccion> lista = new List<Seccion>();

        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        Nombre_Grupo nombre_seccion = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_seccion"]),
        //                                                        dr["nombre_seccion"].ToString(),
        //                                                        Categorias_grupos.Seccion);

        //        Nombre_Grupo nombre_sede = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_sede"]),
        //                                                        dr["nombre_sede"].ToString(),
        //                                                        Categorias_grupos.Sede);

        //        Nombre_Grupo nombre_carrera = new Nombre_Grupo(Convert.ToInt32(dr["id_nombre_carrera"]),
        //                                                        dr["nombre_carrera"].ToString(),
        //                                                        Categorias_grupos.Carrera);

        //        Carrera carrera = new Carrera(Convert.ToInt32(dr["id_carrera"]), nombre_carrera, null);


        //        Seccion a = new Seccion(Convert.ToInt32(dr["id"]),
        //                                nombre_seccion,
        //                                nombre_sede,
        //                                carrera,
        //                                Convert.ToInt32(dr["anno"]),
        //                                (Periodos)Convert.ToInt32(dr["id_periodo"]),
        //                                Convert.ToInt32(dr["nivel"]));

        //        lista.Add(a);
        //    }

        //    return lista;
        //}


        private bool Existe(Seccion s)
        {
            string consulta =   "select 1 from seccion " +
                                "where id_nombre=" + s.Nombre.ID + " " +
                                "and id_nombre_sede=" + s.Nombre_sede.ID + " " +
                                "and id_entidad_carrera=" + s.Carrera.ID + " " +
                                "and anno=" + s.Anno + " " +
                                "and nivel=" + s.Nivel + " " +
                                "and id_periodo=" + Convert.ToInt32(s.Periodo).ToString() + " " +
                                "and id<>" + s.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            return dt.Rows.Count > 0;
        }
    }
}
