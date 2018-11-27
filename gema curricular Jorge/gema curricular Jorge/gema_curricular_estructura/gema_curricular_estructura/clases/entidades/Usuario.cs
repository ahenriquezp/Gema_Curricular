using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gema_curricular_estructura.clases.entidades
{
    public class Usuario
    {
        public int ID;
        public string Rut;
        public string Nombres;
        public string Apellido_paterno;
        public string Apellido_materno;
        public string Clave;
        public Perfil Perfil;
        public char Sexo;
        public DateTime Fecha_nacimiento;
        public DateTime Fecha_creacion;
        public bool Eliminado;

        public Usuario(int ID, string Rut, string Nombres, string Apellido_paterno, string Apellido_materno,
                       string Clave, Perfil Perfil, char Sexo, DateTime Fecha_nacimiento, DateTime Fecha_creacion, 
                       bool Eliminado)
        {
            this.ID = ID;
            this.Rut = Rut;
            this.Nombres = Nombres;
            this.Apellido_paterno = Apellido_paterno;
            this.Apellido_materno = Apellido_materno;
            this.Clave = Clave;
            this.Perfil = Perfil;
            this.Sexo = Sexo;
            this.Fecha_nacimiento = Fecha_nacimiento;
            this.Fecha_creacion = Fecha_creacion;
            this.Eliminado = Eliminado;
        }

    }

    public enum Perfil : int
    {
        Alumno = 1,
        Docente = 2,        
        Administrador = 3        
    }
}
