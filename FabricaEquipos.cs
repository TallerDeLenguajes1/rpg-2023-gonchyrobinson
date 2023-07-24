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
 private string[] areas = new string[]
{
    "Spain",                // Real Madrid
    "Spain",                // Barcelona
    "England",              // Manchester United
    "Germany",              // Bayern Munich
    "Italy",                // Juventus
    "France",               // Paris Saint-Germain
    "England",              // Liverpool
    "England",              // Manchester City
    "England",              // Chelsea
    "Spain",                // Atletico Madrid
    "Italy",                // Inter Milan
    "Italy",                // AC Milan
    "England",              // Arsenal
    "England",              // Tottenham Hotspur
    "Germany",              // Borussia Dortmund
    "Netherlands",          // Ajax
    "Italy",                // Roma
    "Italy",                // Napoli
    "Portugal",             // Benfica
    "Portugal",             // Porto
    "Spain",                // Sevilla
    "Spain",                // Valencia
    "France",               // Marseille
    "France",               // Lyon
    "Argentina",            // Boca Juniors
    "Argentina",            // River Plate
    "Brazil",               // Sao Paulo
    "Brazil",               // Flamengo
    "Brazil",               // Corinthians
    "Brazil",               // Palmeiras
    "Brazil",               // Cruzeiro
    "Brazil",               // Santos
    "Brazil",               // Vasco da Gama
    "Brazil",               // Gremio
    "Switzerland",          // Grasshopper Club Zurich
    "Netherlands",          // Feyenoord
    "Netherlands",          // PSV Eindhoven
    "Belgium",              // Anderlecht
    "Belgium",              // Club Brugge
    "Scotland",             // Celtic
    "Scotland",             // Rangers
    "Turkey",               // Galatasaray
    "Turkey",               // Fenerbahce
    "Turkey"                // Besiktas
};

        public Equipos CreadorEquipos(List<Personaje> ListadoJugadores)
        {
            var equipoCreado = new Equipos();
            var rand = new Random();
            var creadorPersonajes = new fabricaPersonaje();
            equipoCreado.Delantero = new Personaje();
            equipoCreado.Mediocampo = new Personaje();
            equipoCreado.DefensaOArquero = new Personaje();
            //Creo un equipo con 1 delantero, 1 mediocampo y un defensa o arquero. Delanteros se representan con 4, mediocampos con 3, defensas con 2 y arqueros con 1
            equipoCreado.Delantero = creadorPersonajes.CrearPersonaje(4);
            equipoCreado.Mediocampo = creadorPersonajes.CrearPersonaje(3);
            equipoCreado.DefensaOArquero = creadorPersonajes.CrearPersonaje(rand.Next(1, 3));

            //Esta funcion recorre la lista de jugadores y verifica que no esté repetido. Si lo está, no agrega el personaje creado al equipo, sino que crea un nuevo jugador hasta que no esté repetido
            while (EncuentraIgualNombre(ListadoJugadores, equipoCreado.Delantero))
            {
                equipoCreado.Delantero = creadorPersonajes.CrearPersonaje(4);
            }
            while (EncuentraIgualNombre(ListadoJugadores, equipoCreado.Mediocampo))
            {
            equipoCreado.Mediocampo = creadorPersonajes.CrearPersonaje(3);
            }
            while (EncuentraIgualNombre(ListadoJugadores, equipoCreado.DefensaOArquero))
            {
            equipoCreado.DefensaOArquero = creadorPersonajes.CrearPersonaje(2);
            }
            equipoCreado.Goles = 0;
            //Equipos es un arreglo que contiene los nombres de los equipos que pueden aparecer el juego y ares contiene las areas. Es importante destacar que las areas de los equipos, coinciden con el campo de areas de la API, porque este detalle se usa en el juego
            var indice = rand.Next(0,equipos.Length);

            //Hago coincidir los Nombres con sus areas
            equipoCreado.NombreEquipo = equipos[indice];
            equipoCreado.Area=areas[indice];

            //Agrego los jugadores a la lista de jugadores de manera de que en el proximo equipo, no puedan estar repetidos
            ListadoJugadores.Add(equipoCreado.Delantero);
            ListadoJugadores.Add(equipoCreado.DefensaOArquero);
            ListadoJugadores.Add(equipoCreado.Mediocampo);

            //Retorno el equipo creado
            return (equipoCreado);
        }
        private bool EncuentraIgualNombre(List<Personaje> listaPersonajes, Personaje personajeCreado){
            bool encontrado = false;
            foreach (var personaje in listaPersonajes)
            {
                if (personaje.Nombre() == personajeCreado.Nombre())
                {
                    encontrado=true;
                }
            }
            return(encontrado);
        }
    }
}