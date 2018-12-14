using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_evaluaciones.entidades
{
    public class Respuesta
    {
        public int ID_pauta_respondida;
        public int ID_pregunta;
        public string Respuesta; //es la alternativa que marcó. Se compara con la alternativa correcta de la pregunta a la que responde
        public float Nota; //si es binaria la nota es 0 o 1
        
        public Respuesta(int ID_pauta_respondida, int ID_pregunta, string Respuesta, float Nota)
        {
            this.ID_pauta_respondida = ID_pauta_respondida;
            this.ID_pregunta = ID_pregunta;
            this.Respuesta = Respuesta;
            this.Nota = Nota;
        }
    }
}
