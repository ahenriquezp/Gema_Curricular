using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_estructura.entidades
{
    public class Nombre_Grupo : IComparable
    {
        public int ID;
        public string Nombre;
        public Categorias_grupos Categoria;

        public Nombre_Grupo(int ID, string Nombre, Categorias_grupos Categoria)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Categoria = Categoria;
        }

        public int CompareTo(object obj)
        {
            Nombre_Grupo entidad = obj as Nombre_Grupo;
            if (entidad == null)
                return 1;
            else
                return Nombre.CompareTo(entidad.Nombre);
        }
    }

}
