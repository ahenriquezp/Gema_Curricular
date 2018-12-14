using System;
using System.Collections.Generic;
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
    public class Categoria
    {
        public int ID;
        public string Nombre;
        public Tipo_categoria Tipo;
        public float Peso;
        public List<Categoria> Lista_hijas;
        public List<Categoria> Lista_padres;

        public Categoria(int id, string nombre, Tipo_categoria tipo, float peso)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Peso = peso;
            this.Lista_hijas = new List<Categoria>();
            this.Lista_padres = new List<Categoria>();
        }
    }


    public enum Tipo_categoria : int
    {};
}
