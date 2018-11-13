using System.Collections.Generic;


namespace Gema_Curricular.Entidades 
{
    public class Perfil_egreso()
    {
        public string Nombre;
        public string Descripcion;
        public List<string> Lista_ambitos_desempeño;
        public List<Categoria> Lista_competencias;

        public Perfil_egreso(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Lista_ambitos_desempeño = new List<string>();
            this.Lista_competencias = new List<Categoria>();
        }
    }
}