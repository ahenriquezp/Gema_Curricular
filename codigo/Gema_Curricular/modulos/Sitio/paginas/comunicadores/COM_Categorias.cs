using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular_estructura.entidades;
using gema_curricular_estructura.negocio;
using gema_curricular_malla.entidades;
using gema_curricular_malla.negocio;

namespace gema_curricular.web
{
    public class COM_Categorias
    {
        Gestor_Categoria gestor;
        Page pagina;

        public COM_Categorias(Page pagina)
        {
            this.pagina = pagina;
            gestor = new Gestor_Categoria();
        }
        
        
        
        public void Buscar()
        {
            int id = Convert.ToInt32(pagina.Request["id"]);
            Categoria u = gestor.Buscar(id);
            pagina.Response.Write("0\n" + Empaquetar(u));
        }

        private string Empaquetar(Categoria u)
        {
            throw new NotImplementedException();
        }
        
        public void Listar()
        {
            List<Categoria> lista = gestor.Listar();

            StringBuilder paquete = new StringBuilder("0");
            foreach (Categoria u in lista)
            {

                paquete.Append(                    
                            "\n" + u.ID + 
                            "\t" + u.Nombre +  
                            "\t" + u.Tipo +
                            "\t" + u.Peso +
                            "\t" + u.Lista_hijas.Count +
                            "\t" + u.Lista_padres.Count
                    );
            }

            pagina.Response.Write(paquete.ToString());
        }
        
        public void Adicionar()
        {
            Categoria u = Desempaquetar(pagina.Request["paquete"]);
            gestor.Agregar(u);
            pagina.Response.Write("0");
        }
        
        public void Modificar()
        {
            Categoria u = Desempaquetar(pagina.Request["paquete"]);
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

        private Categoria Desempaquetar(string paquete)
        {
            string[] partes = paquete.Split('\t');
            
            int i = 0;


            int ID = Convert.ToInt32(partes[i++]);
            string nombre = partes[i++];
            Tipo_categoria tipoCategoria = (Tipo_categoria) Convert.ToInt32(partes[i++]);
            float peso = Convert.ToSingle(partes[i++]);


            Categoria u = new Categoria(ID, nombre, tipoCategoria, peso);

            return u;
        }
    }
}
