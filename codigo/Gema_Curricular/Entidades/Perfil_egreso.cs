using System.Collections.Generic;


namespace Gema_Curricular.Entidades 
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