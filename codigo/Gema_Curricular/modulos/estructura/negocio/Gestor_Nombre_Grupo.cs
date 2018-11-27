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
    public class Gestor_Nombre_Grupo
    {
        DAO_Nombre_Grupo dao_nombre_grupo;


        public Gestor_Nombre_Grupo()
        {
            dao_nombre_grupo = new DAO_Nombre_Grupo();
        }
        
        public int Agregar(Nombre_Grupo nombre_grupo)
        {
            return dao_nombre_grupo.Agregar(nombre_grupo);
        }

        public void Modificar(Nombre_Grupo nombre_grupo)
        {
            dao_nombre_grupo.Modificar(nombre_grupo);
        }

        public void Eliminar(int id_nombre_grupo)
        {
            dao_nombre_grupo.Eliminar(id_nombre_grupo);
        }

        public Nombre_Grupo Buscar(int id_nombre_grupo)
        {
            return dao_nombre_grupo.Buscar(id_nombre_grupo);
        }
 
        public List<Nombre_Grupo> Listar()
        {
            return dao_nombre_grupo.Listar();
        }
    }
}
