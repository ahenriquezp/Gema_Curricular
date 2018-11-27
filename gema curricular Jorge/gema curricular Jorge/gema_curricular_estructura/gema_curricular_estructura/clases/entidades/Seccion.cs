using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_estructura.clases.entidades
{
    public class Seccion
    {
        public int ID;
        public int ID_nombre;
        public int ID_nombre_sede;
        public int ID_facultad;
        public int ID_entidad_carrera;
        public int Anno;
        public int Nivel;
        public Periodos Periodo;

        public Seccion() { }

        public Seccion(int ID, int ID_nombre, int ID_nombre_sede,
            int ID_entidad_carrera, int Anno, Periodos Periodo, int Nivel)
        {
            this.ID = ID;
            this.ID_nombre = ID_nombre;
            this.ID_nombre_sede = ID_nombre_sede;
            this.ID_entidad_carrera = ID_entidad_carrera;
            this.Anno = Anno;
            this.Periodo = Periodo;
            this.Nivel = Nivel;
        }
    }
}
