using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_evaluaciones.entidades
{
    public class Pregunta
    {
        public int ID;
        public string Texto;
        public string Alternativa_correcta;
        public float Peso;
        public int ID_pauta;
        
        public List<Categoria> Lista_de_categorias;
        
        public Pregunta(int ID, string Texto, string Alternativa_correcta, float Peso, int ID_pauta)
        {
            this.ID = ID;
            this.Texto = Texto;
            this.Alternativa_correcta = Alternativa_correcta;
            this.Peso = Peso;
            this.ID_pauta = ID_pauta;
            
            this.Lista_de_categorias = new List<Categoria>();
        }
    }
}
