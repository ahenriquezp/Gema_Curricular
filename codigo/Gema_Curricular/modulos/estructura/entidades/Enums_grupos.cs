using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_estructura.entidades
{
    public enum Categorias_grupos : int
    {
        Universidad = 1,
        Facultad = 2,
        Carrera = 3,
        Sede = 4,
        Grupo = 5,
        Seccion = 6,
        Asignatura = 7
    }

    public enum Periodos : int
    {
        Otoño = 1,
        Primavera = 2,
        Verano = 3,
        Invierno = 4
    }

    public enum Jornadas_grupos : int
    {
        Diurno = 1,
        Vespertino = 2,
        Ambos = 3
    }

    public enum Alumnos_Eliminados : int
    {
        Eliminado = 1,
        No_eliminado = 2,
        Ambos = 3
    }

}
