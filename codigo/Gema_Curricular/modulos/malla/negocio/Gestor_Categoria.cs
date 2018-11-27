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
    public class Gestor_Categoria
    {
        DAO_Categoria dao_categoria;


        public Gestor_Categoria()
        {
            dao_categoria = new DAO_Categoria();
        }
        
        public void Agregar(Categoria categoria)
        {
            dao_categoria.Agregar(categoria);
        }

        public void Modificar(Categoria categoria)
        {
            dao_categoria.Modificar(categoria);
        }

        public void Eliminar(int id_categoria)
        {
            dao_categoria.Eliminar(id_categoria);
        }

        public Categoria Buscar(int id_categoria)
        {
            return dao_categoria.Buscar(id_categoria);
        }

        public List<Categoria> Listar()
        {
            return dao_categoria.Listar();
        }

    }
}
