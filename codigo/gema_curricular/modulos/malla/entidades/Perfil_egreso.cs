using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace gema_curricular_malla.entidades
{
    public class Perfil_egreso
    {
        public int ID;
        public string Nombre;
        public string Descripcion;
        public float Peso;
        public List<string> Lista_ambitos_desempeño;
        public List<Categoria> Lista_competencias;

        public Perfil_egreso(int id, string nombre, string descripcion, float peso)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Peso = peso;
            this.Lista_ambitos_desempeño = new List<string>();
            this.Lista_competencias = new List<Categoria>();
        }
    }
}