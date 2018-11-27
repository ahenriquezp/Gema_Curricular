using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular_estructura.entidades;
using gema_curricular_estructura.negocio;

namespace gema_curricular.web
{
    public class COM_Usuarios
    {
        Gestor_Usuario gestor;
        Page pagina;

        public COM_Usuarios(Page pagina)
        {
            this.pagina = pagina;
            gestor = new Gestor_Usuario();
        }
        
        
        
        public void Buscar()
        {
            int id = Convert.ToInt32(pagina.Request["id"]);
            Usuario u = gestor.Buscar(id);
            pagina.Response.Write("0\n" + Empaquetar(u));
        }
        
        public void Listar()
        {
            List<Usuario> lista = gestor.Listar();

            StringBuilder paquete = new StringBuilder("0");
            foreach (Usuario u in lista)
            {
                paquete.Append(                    
                            "\n" + u.ID + 
                            "\t" + u.Rut +  
                            "\t" + u.Nombres +  
                            "\t" + u.Apellido_paterno +  
                            "\t" + u.Apellido_materno +  
                            "\t" + Convert.ToInt32(u.Perfil).ToString() + 
                            "\t" + Convert.ToInt32(u.Eliminado).ToString()
                    );
            }

            pagina.Response.Write(paquete.ToString());
        }
        
        public void Adicionar()
        {
            Usuario u = Desempaquetar(pagina.Request["paquete"]);
            gestor.Agregar(u);
            pagina.Response.Write("0");
        }
        
        public void Modificar()
        {
            Usuario u = Desempaquetar(pagina.Request["paquete"]);
            gestor.Modificar(u);
            pagina.Response.Write("0");
        }
        
        public void Eliminar()
        {
            int id = Convert.ToInt32(pagina.Request["id"]);
            gestor.Eliminar(id);
            pagina.Response.Write("0");
        }




        private string Empaquetar(Usuario u)
        {
            string paquete = 
                
                u.ID +                 
                "\t" + u.Rut + 
                "\t" + u.Nombres + 
                "\t" + u.Apellido_paterno + 
                "\t" + u.Apellido_materno + 
                "\t" + u.Clave +
                "\t" + Convert.ToInt32(u.Perfil).ToString() + 
                "\t" + u.Sexo + 
                "\t" + Utiles.DateTime_to_String(u.Fecha_nacimiento) +
                 "\t" + Convert.ToInt32(u.Eliminado).ToString();

            return paquete;
        }

        private Usuario Desempaquetar(string paquete)
        {
            string[] partes = paquete.Split('\t');
            
            int i = 0;


            int ID = Convert.ToInt32(partes[i++]);
            string Rut = partes[i++];
            string Nombres = partes[i++];
            string Apellido_paterno = partes[i++];
            string Apellido_materno = partes[i++];
            string Clave = partes[i++];
            Perfil Perfil = (Perfil)Convert.ToInt32(partes[i++]);
            char Sexo = Convert.ToChar(partes[i++]);
            DateTime Fecha_nacimiento = Utiles.String_to_DateTime(partes[i++]);
            DateTime Fecha_creacion = DateTime.Now;
            bool Eliminado = Convert.ToBoolean(partes[i++]);


            Usuario u = new Usuario(ID, Rut, Nombres, Apellido_paterno, Apellido_materno,
                       Clave, Perfil, Sexo, Fecha_nacimiento, Fecha_creacion, 
                       Eliminado);

            return u;
        }
    }
}
