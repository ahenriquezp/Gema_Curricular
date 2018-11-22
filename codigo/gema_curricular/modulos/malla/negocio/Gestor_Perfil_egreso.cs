using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gema_curricular.comun;
using gema_curricular_malla.entidades;
using gema_curricular_malla.datos;

namespace gema_curricular_malla.negocio
{
    public class Gestor_Perfil_egreso
    {
        DAO_Perfil_egreso dao_perfil_egreso;


        public Gestor_Perfil_egreso()
        {
            dao_perfil_egreso = new DAO_Perfil_egreso();
        }

        public void Agregar(Perfil_egreso perfil)
        {
            dao_perfil_egreso.Agregar(perfil);
        }

        public void Modificar(Perfil_egreso perfil)
        {
            dao_perfil_egreso.Modificar(perfil);
        }

        public void Eliminar(int id_perfil)
        {
            dao_perfil_egreso.Eliminar(id_perfil);
        }

        public Perfil_egreso Buscar(int id_perfil)
        {
            return dao_perfil_egreso.Buscar(id_perfil);
        }

        public List<Perfil_egreso> Listar()
        {
            return dao_perfil_egreso.Listar();
        }
    }
}
