using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace gema_curricular.web
{
    public partial class Comunicador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string opcion = Request["opcion"];
                
                Procesar_opciones_usuarios(opcion);
                Procesar_opciones_categorias(opcion);

            }
            catch(Exception error)
            {
                Response.Write(error.Message);
            }
        }

        private void Procesar_opciones_usuarios(string opcion)
        {
            COM_Usuarios com = new COM_Usuarios(this);
            
            switch (opcion)
            {
                case "1":
                    com.Adicionar();
                    break;

                case "2":
                    com.Modificar();
                    break;

                case "3":
                    com.Eliminar();
                    break;
                
                case "4":
                    com.Buscar();
                    break;

                case "5":
                    com.Listar();
                    break;
                
            }
        }

        private void Procesar_opciones_categorias(string opcion)
        {
            //COM_Categorias com = new COM_Categorias(this);

            //switch (opcion)
            //{
            //    case "1001":
            //        com.Adicionar();
            //        break;

            //    case "1002":
            //        com.Modificar();
            //        break;

            //    case "1003":
            //        com.Eliminar();
            //        break;

            //    case "1004":
            //        com.Buscar();
            //        break;

            //    case "1005":
            //        com.Listar();
            //        break;

            //}
        }
    }
}
