using System;
namespace EspacioPersonajes
{
       enum Tipo{
        delantero = 4,
        mediocampo = 3,
        defensa = 2,
        arquero = 1

    }
    public class Datos
    {
        private Tipo tipoPersonaje;
        private string nombre;
        private string apodo;
        private DateTime fechaNacimiento;
        private int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        internal Tipo TipoPersonaje { get => tipoPersonaje; set => tipoPersonaje = value; }

    }
}