using System;
using EspacioPersonajes;
namespace EspacioEquipos
{
    class FabricaEquipos
    {

        public Equipos CreadorEquipos()
        {
            var equipoCreado = new Equipos();
            var rand = new Random();
            var creadorPersonajes = new fabricaPersonaje();
            equipoCreado.Delantero = new Personaje();
            equipoCreado.Mediocampo = new Personaje();
            equipoCreado.DefensaOArquero = new Personaje();
            equipoCreado.Delantero = creadorPersonajes.CrearPersonaje(4);
            equipoCreado.Mediocampo = creadorPersonajes.CrearPersonaje(3);
            equipoCreado.DefensaOArquero = creadorPersonajes.CrearPersonaje(rand.Next(1, 3));
            equipoCreado.Goles = 0;
            return (equipoCreado);
        }
    }
}