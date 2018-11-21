using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_estructura.entidades
{
    public class Carrera
    {
        public int ID;
        public Nombre_Grupo Nombre_carrera;
        public Nombre_Grupo Nombre_facultad;



        public Carrera(int ID, Nombre_Grupo Nombre_carrera, Nombre_Grupo Nombre_facultad)
        {
            this.ID = ID;
            this.Nombre_carrera = Nombre_carrera;
            this.Nombre_facultad = Nombre_facultad;
        }
    }
}
