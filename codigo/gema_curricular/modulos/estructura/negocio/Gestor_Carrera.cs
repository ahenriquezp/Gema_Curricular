using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_estructura.entidades;
using gema_curricular_estructura.datos;

namespace gema_curricular_estructura.negocio
{
    public class Gestor_Carrera
    {
        DAO_Carrera dao_carrera;

        public Gestor_Carrera()
        {
            dao_carrera = new DAO_Carrera();
        }
        
        public void Agregar(Carrera carrera)
        {
            dao_carrera.Agregar(carrera);
        }

        public void Modificar(Carrera carrera)
        {
            dao_carrera.Modificar(carrera);
        }

        public void Eliminar(int id_carrera)
        {
            dao_carrera.Eliminar(id_carrera);
        }

        public Carrera Buscar(int id_carrera)
        {
            return dao_carrera.Buscar(id_carrera);
        }
 
        public List<Carrera> Listar()
        {
            return dao_carrera.Listar();
        }
    }
}
