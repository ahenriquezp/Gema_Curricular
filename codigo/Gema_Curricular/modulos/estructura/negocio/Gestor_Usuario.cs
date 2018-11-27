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
    public class Gestor_Usuario
    {
        DAO_Usuario dao_usuario;
        
        public Gestor_Usuario()
        {
            dao_usuario = new DAO_Usuario();
        }
        
        public void Agregar(Usuario usuario)
        {
            dao_usuario.Agregar(usuario);
        }

        public void Modificar(Usuario usuario)
        {
            dao_usuario.Modificar(usuario);
        }

        public void Eliminar(int id_usuario)
        {
            dao_usuario.Eliminar(id_usuario);
        }

        public Usuario Buscar(int id_usuario)
        {
            return dao_usuario.Buscar(id_usuario);
        }

        public List<Usuario> Listar()
        {
            return dao_usuario.Listar();
        }

    }
}
