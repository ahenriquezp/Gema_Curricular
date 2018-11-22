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
    public class Gestor_Seccion
    {
        DAO_Seccion dao_seccion;


        public Gestor_Seccion()
        {
            dao_seccion = new DAO_Seccion();
        }

        public void Agregar(Seccion seccion)
        {
            dao_seccion.Agregar(seccion);
        }

        public void Modificar(Seccion seccion)
        {
            dao_seccion.Modificar(seccion);
        }

        public void Eliminar(int id_seccion)
        {
            dao_seccion.Eliminar(id_seccion);
        }

        public Seccion Buscar(int id_seccion)
        {
            return dao_seccion.Buscar(id_seccion);
        }
        
    }
}
