using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_estructura.entidades
{
    public class Seccion
    {
        public int ID;
        public Nombre_Grupo Nombre;
        public Nombre_Grupo Nombre_sede;
        public Carrera Carrera;
        public int Anno;
        public int Nivel;
        public Periodos Periodo;

        public Seccion() { }

        public Seccion(int ID, Nombre_Grupo Nombre, Nombre_Grupo Nombre_sede,
            Carrera Carrera, int Anno, Periodos Periodo, int Nivel)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Nombre_sede = Nombre_sede;
            this.Carrera = Carrera;
            this.Anno = Anno;
            this.Periodo = Periodo;
            this.Nivel = Nivel;
        }
    }
}
