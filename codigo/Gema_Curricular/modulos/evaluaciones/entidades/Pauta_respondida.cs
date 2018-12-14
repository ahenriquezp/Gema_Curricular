using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_evaluaciones.entidades
{
    public class Pauta_respondida
    {
        public int ID;
        public int ID_pauta;
        public int ID_estudiante;
        public DateTime Fecha_respuesta;
        
        public List<Respuesta> Lista_respuestas;
        
        public Pauta(int ID, int ID_pauta, int ID_estudiante, DateTime Fecha_respuesta)
        {
            this.ID = ID;
            this.ID_pauta = ID_pauta;
            this.ID_estudiante = ID_estudiante;
            this.Fecha_respuesta = Fecha_respuesta;
            
            this.Lista_respuestas = new List<Respuesta>();
        }
    }
}
