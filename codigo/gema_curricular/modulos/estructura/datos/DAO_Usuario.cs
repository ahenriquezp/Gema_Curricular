using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_estructura.entidades;

namespace gema_curricular_estructura.datos
{
    public class DAO_Usuario
    {
        BD bd;


        public DAO_Usuario()
        {
            bd = new BD();
        }
        
        public void Agregar(Usuario usuario)
        {
            if (!Existe(usuario))
            {
                string consulta = "insert into usuario (rut, nombres, apellido_paterno, apellido_materno, clave, id_perfil, sexo, " +
                                    "fecha_nacimiento, fecha_creacion, eliminado) values ('" +
                                    usuario.Rut + "', '" +
                                    usuario.Nombres + "', '" +
                                    usuario.Apellido_paterno + "', '" +
                                    usuario.Apellido_materno + "', '" +
                                    usuario.Clave + "', " +
                                    Convert.ToInt32(usuario.Perfil).ToString() + ", '" +
                                    usuario.Sexo + "', " +
                                    bd.Formatear_fecha(usuario.Fecha_nacimiento) + ", " +
                                    bd.Formatear_fecha(usuario.Fecha_creacion) + ", " +
                                    Convert.ToInt32(usuario.Eliminado).ToString() + ")";

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La persona ya está registrada en el sistema");
        }

        public void Modificar(Usuario usuario)
        {
            if (!Existe(usuario))
            {
                string consulta = "update usuario set " +
                                    "rut='" + usuario.Rut + "', " +
                                    "nombres='" + usuario.Nombres + "', " +
                                    "apellido_paterno='" + usuario.Apellido_paterno + "', " +
                                    "apellido_materno='" + usuario.Apellido_materno + "', " +
                                    "clave='" + usuario.Clave + "', " +
                                    "id_perfil=" + Convert.ToInt32(usuario.Perfil).ToString() + ", " +
                                    "sexo='" + usuario.Sexo + "', " +
                                    "fecha_nacimiento=" + bd.Formatear_fecha(usuario.Fecha_nacimiento) + ", " +
                                    "eliminado=" + Convert.ToInt32(usuario.Eliminado).ToString() + " " +
                                    "where id= " + usuario.ID;

                bd.Ejecutar_comando(consulta);
                bd.Cerrar();
            }
            else throw new Exception("La persona ya está registrada en el sistema");
        }

        public void Eliminar(int id_usuario)
        {
            string consulta = "delete from usuario where id=" + id_usuario;

            bd.Ejecutar_comando(consulta);
            bd.Cerrar();
        }

        public Usuario Buscar(int id_usuario)
        {
            string consulta = "select rut, nombres, apellido_paterno, apellido_materno, clave, id_perfil, sexo, " +
                              "fecha_nacimiento, fecha_creacion, eliminado from usuario where id=" + id_usuario;

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            Usuario a = null;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                a = new Usuario(id_usuario, 
                                dr["rut"].ToString(), 
                                dr["nombres"].ToString(), 
                                dr["apellido_paterno"].ToString(), 
                                dr["apellido_materno"].ToString(), 
                       
                                dr["clave"].ToString(), 
                                (Perfil)Convert.ToInt32(dr["id_perfil"]), 
                                Convert.ToChar(dr["sexo"]),
                                Convert.ToDateTime(dr["fecha_nacimiento"]),
                                Convert.ToDateTime(dr["fecha_creacion"]), 
                                Convert.ToBoolean(dr["eliminado"]));
            }

            return a;
        }

        public List<Usuario> Listar()
        {
            string consulta = "select id, rut, nombres, apellido_paterno, apellido_materno, clave, id_perfil, sexo, " +
                              "fecha_nacimiento, fecha_creacion, eliminado from usuario";

            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            List<Usuario> lista = new List<Usuario>();

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Usuario(Convert.ToInt32(dr["id"]),
                                dr["rut"].ToString(),
                                dr["nombres"].ToString(),
                                dr["apellido_paterno"].ToString(),
                                dr["apellido_materno"].ToString(),

                                dr["clave"].ToString(),
                                (Perfil)Convert.ToInt32(dr["id_perfil"]),
                                Convert.ToChar(dr["sexo"]),
                                Convert.ToDateTime(dr["fecha_nacimiento"]),
                                Convert.ToDateTime(dr["fecha_creacion"]),
                                Convert.ToBoolean(dr["eliminado"])));
            }

            return lista;
        }

        private bool Existe(Usuario u)
        {
            string consulta = "select 1 from usuario "+
                "where (rut='" + u.Rut + "' "+
                "or (nombres='" + u.Nombres + "' and apellido_paterno='" + u.Apellido_paterno + "' and apellido_materno='" + u.Apellido_materno + "')) " +
                "and id<>" + u.ID;
            DataTable dt = bd.Ejecutar_consulta(consulta);
            bd.Cerrar();

            return dt.Rows.Count > 0;
        }
    }
}
