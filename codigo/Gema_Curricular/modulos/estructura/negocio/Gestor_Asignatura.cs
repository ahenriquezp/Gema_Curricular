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
    public class Gestor_Asignatura
    {
        DAO_Asignatura dao_asignatura;


        public Gestor_Asignatura()
        {
            dao_asignatura = new DAO_Asignatura();
        }
        
        public void Agregar(Asignatura asignatura)
        {
            dao_asignatura.Agregar(asignatura);
        }

        public void Modificar(Asignatura asignatura)
        {
            dao_asignatura.Modificar(asignatura);
        }

        public void Eliminar(int id_asignatura)
        {   
            dao_asignatura.Eliminar(id_asignatura);
        }

        public Asignatura Buscar(int id_asignatura)
        {
            return dao_asignatura.Buscar(id_asignatura);
        }

        public List<Asignatura> Listar()
        {
            return dao_asignatura.Listar();
        }
    }
}
