using System;
using EspacioPersonajes;
namespace EspacioEquipos
{
    class FabricaEquipos
    {

        private string[] equipos = new string[]
  {
    "Real Madrid",
    "Barcelona",
    "Manchester United",
    "Bayern Munich",
    "Juventus",
    "Paris Saint-Germain",
    "Liverpool",
    "Manchester City",
    "Chelsea",
    "Atletico Madrid",
    "Inter Milan",
    "AC Milan",
    "Arsenal",
    "Tottenham Hotspur",
    "Borussia Dortmund",
    "Ajax",
    "Roma",
    "Napoli",
    "Benfica",
    "Porto",
    "Sevilla",
    "Valencia",
    "Marseille",
    "Lyon",
    "Boca Juniors",
    "River Plate",
    "Sao Paulo",
    "Flamengo",
    "Corinthians",
    "Palmeiras",
    "Cruzeiro",
    "Santos",
    "Vasco da Gama",
    "Gremio",
    "Grasshopper Club Zurich",
    "Feyenoord",
    "PSV Eindhoven",
    "Anderlecht",
    "Club Brugge",
    "Celtic",
    "Rangers",
    "Galatasaray",
    "Fenerbahce",
    "Besiktas"
      // Puedes agregar más nombres de equipos si lo deseas
  };

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
            equipoCreado.NombreEquipo = equipos[rand.Next(0,equipos.Length)];
            return (equipoCreado);
        }
    }
}