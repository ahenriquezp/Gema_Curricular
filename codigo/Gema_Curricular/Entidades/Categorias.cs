using System.Collections.Generic;


namespace Gema_Curricular.Entidades 
{
    public class Categoria 
    {
        public int Id;
        public string Nombre;
        public Tipo_categoria Tipo;
        public float Peso;
        public List<Categoria> Lista_hijas;
        public List<Categoria> Lista_padres;

        public Categoria(int id, string nombre, Tipo_categoria tipo, float peso) 
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Peso = peso;
            this.Lista_hijas = new List<Categoria>();
            this.Lista_padres = new List<Categoria>();
        }
    }


    public enum Tipo_categoria { };
}