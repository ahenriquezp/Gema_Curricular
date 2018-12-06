using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_evaluaciones.entidades
{
    public class Respuesta
    {
        public int ID_estudiante;
        public int ID_pregunta;
        public string Respuesta; //es la alternativa que marcó. Se compara con la alternativa correcta de la pregunta a la que responde
        public float Nota; //si es binaria la nota es 0 o 1
        
        public Respuesta(int ID_estudiante, int ID_pregunta, string Respuesta, float Nota)
        {
            this.ID_estudiante = ID_estudiante;
            this.ID_pregunta = ID_pregunta;
            this.Respuesta = Respuesta;
            this.Nota = Nota;
        }
    }
}
