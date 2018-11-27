using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_estructura.entidades
{
    public class Asignatura
    {
        public int ID;
        public string Nombre;
        public float Peso;

        public Asignatura(int ID, string Nombre, float Peso)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Peso = Peso;
        }

    }
}
