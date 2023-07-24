using System;
using EspacioPersonajes;
using EspacioEquipos;
using EspacioPersistenciaDeDatos;
using System.Collections.Generic;

internal class Program
{

    private static void Main(string[] args)
    {
//PREPARO LOS DETALLES PREVIOS ANTES DE COMENZAR EL JUEGO
        //Creación personajes y equipos
        var persistencia = new PersonajesJSON();
        var creadorEquipos = new FabricaEquipos();
        string nombreArchivo = @"personajesJSON.json";
        List<Equipos> listadoEquipos = new List<Equipos>();
        var listadoJugadores = new List<Personaje>();

        // Creacion listado competiciones. GetCompetencias es un metodo que accede a la API, y me devuelve los datos leidos de la API
        var listadoCompeticiones = persistencia.GetCompetencias();

        //La primera vez que uso el juego, creo el archivo JSON con los equipos y personajes y los guardo en el archivo personajesJSON. Si ya usé el juego anteriormente, el archivo de personajes ya existirá, por lo tanto, jugaré siempre con los mismos equipos
        if (persistencia.Existe(nombreArchivo))
        {
            listadoEquipos = persistencia.LeerPersonajes(nombreArchivo);
        }
        else
        {
            var Equipo = new Equipos();
            //Creo 10 equipos cuyos nombres NO se repiten
            for (int i = 0; i < 10; i++)
            {
                //CreadorEquipos es un metodo que crea equipos con jugadores, de manera de que los jugadores no se repitan               
                Equipo = creadorEquipos.CreadorEquipos(listadoJugadores);
                foreach (var eq in listadoEquipos)
                {
                    //Realizo este control para evitar nombres de equipos repetidos
                    while (eq.Nombre() == Equipo.Nombre())
                    {
                        //Si se repiten los equipos, los elimino al delantero, mediocampo y defensa o arquero del listado de jugadores, ya que este jugador si puede ser utilizado en un futuro equipo y creo el equipo que reemplazará al repetido
                        listadoJugadores.Remove(Equipo.Delantero);
                        listadoJugadores.Remove(Equipo.DefensaOArquero);
                        listadoJugadores.Remove(Equipo.Mediocampo);
                        Equipo = creadorEquipos.CreadorEquipos(listadoJugadores);
                    }
                }
                //Cuando el equipo no está repetido lo agrego al listado
                listadoEquipos.Add(Equipo);
     
            }
            //Escribo el listado de los 10 equipos que se usarán en el juego en el archivo personajesJSON
            persistencia.GuardarPersonajes(listadoEquipos, nombreArchivo);
        }

//COMIENZA EL JUEGO

        Console.WriteLine("\tSe asignaran 2 equipos, los cuales jugarán entre ellos.\n Serán 3 enfrentamientos: Delantero vs Defensa o Arquero, Defensa o Arquero vs Delantero, Mediocampo vs Mediocampo. Cada enfrentamiento, será una jugada al azar, pueden ser jugadas de mucho o poco peligro, las cuales influirán en la efectividad o probabilidad de meter gol para el equipo que ataca, las jugadas mas efectivas, aumentarán mas el ataque que la defensa y las menos efectivas aumentaran mas la defensa que el ataque, si tiene mas puntos el que está atacando, se sumará un gol al equipo que ataca, si tiene mas goles el que defiende, no se sumará nada y si tienen igual de puntos, el equipo que defiende tiene la posibilidad de hacer un gol de contrataque y se evaluara cual de los 2 tiene mas puntos totales el que ataca o el que defiende. Si tiene mas puntos el que ataca, el equipo atacante frena el contrataque y no ocurrira nada, si tiene mas puntos el que defiende se le sumara un gol a este equipo, (gol de contrataque), si tienen igual, no pasara nada\n. Se realizarán 3 jugadas. En caso de empate, cada jugador tendrá una jugada de ataque, una de defensa y un enfrentamiento entre mediocampos hasta que uno marque y el otro falle que se terminará el partido. A medida que se van produciendo empates, tu equipo recibirá una indicacion del entrenador (aleatoria) que puede mejorar, disminuir o no modificar las estadistcas de los jugadores. \nEl ganador, será el equipo que termina con más goles. Cuando un equipo gana, pasa a jugar la siguiente ronda, pero con un aumento de nivel que aumentara las posibilidades de ganar. El juego termina cuando un equipo vence a todos los equipos de la lista");
        Console.WriteLine("\n=========================================EQUIPOS=====================================\n");
        int k = 1;
        Console.WriteLine("\n_______________________________________________________________\n");
        
        //Muestro la lista de equipos que apareceran en el juego y luego el menu de inicio
        foreach (var equipo in listadoEquipos)
        {
            Console.WriteLine("\t" + k + "-" + equipo.Nombre());
            k++;
        }
        Console.WriteLine("\n_______________________________________________________________\n");
        Console.WriteLine("\n\n\n///////////////////////////\tCOMIENZA EL JUEGO\t///////////////////////////\n");
        Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⣾⣿⣿⣾⣿⣭⣵⣖⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣵⣿⣿⠏⠁⢀⠀⠌⠁⠄⡉⠈⠉⠁⠉⠤⠱⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣌⣾⣿⣿⣧⠂⡌⠢⠑⡈⠄⠢⠐⠄⢂⠁⢃⠦⠹⣶⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⡱⣈⠅⡃⠔⠀⠄⠁⠀⠂⠄⠀⠄⣳⢎⢇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣽⣿⣿⡿⢋⠠⢁⠎⠴⢞⣷⣦⣤⣦⣧⣜⣦⣿⣶⣾⣾⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⡧⢀⠂⠌⣐⣿⢟⣋⣿⣿⠿⠏⠀⢺⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣞⠛⢿⡗⢢⡀⠀⠉⠁⢂⣈⣻⡽⠃⠔⠂⠈⣿⠩⣍⠒⣽⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⢃⣹⡌⢿⡀⠂⠁⠀⢀⠠⢉⠁⡀⢤⡌⡐⠀⡘⣷⢎⣽⡎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡚⣏⡁⢀⣷⠀⡀⠌⢠⡚⡤⠃⠔⡏⠸⠿⢿⣿⣿⣯⢷⣧⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢇⠘⠸⢻⣿⡄⣃⠄⡇⢧⠀⢃⠸⠀⣤⢿⣿⢿⣿⡿⣿⡼⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠹⣿⡗⣯⡐⢯⡜⡡⠌⠀⢰⣾⣻⣾⣿⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣟⠰⢹⣞⡵⣊⠅⠂⠀⠈⢱⣿⣿⣿⡿⢿⣹⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⠣⣜⢻⣷⣉⠆⡠⠀⡀⢳⣙⡿⠿⣡⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣧⢉⣮⠹⢿⣮⣱⡰⣩⣿⣿⣯⣷⣿⣿⢣⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣯⢁⢎⡡⢠⡙⣷⣿⣷⣿⣽⣿⣿⣿⣿⣏⢻⣟⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣼⢳⡌⠒⣧⢣⡝⢤⣿⣿⣿⣿⣿⣿⡿⣟⣾⣿⣿⣿⣳⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣴⣶⣿⡿⣽⢸⡇⡘⣷⠂⡜⣺⣿⢟⣿⣿⣿⣿⣝⣻⣿⣿⣿⣿⣿⡿⡷⣦⡤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣟⣿⣿⣿⣟⡷⣿⢿⣨⢻⡠⣿⡇⢸⣿⡏⠰⣨⢿⣿⣿⣾⣿⣿⣿⣿⣿⣻⢷⣻⡗⣿⣳⢗⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣾⣿⣿⣿⣿⣳⢯⣿⣻⣿⣥⠈⡧⣹⣏⠳⡍⢀⢲⣽⢿⣞⡿⣿⢿⡿⣿⣝⣳⣟⣯⣷⢻⣷⣹⣞⣯⣧⣶⣶⣦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣞⣯⢿⣽⣾⣿⣿⣟⣾⣽⣟⣷⣻⣽⢿⣦⣿⣸⣿⣵⣰⣾⣟⣯⢿⡾⣝⣳⢯⢷⣏⢿⡼⢧⣟⢾⣻⢞⣽⣻⡾⢯⣷⣛⢿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣯⢟⣶⡻⣞⣿⣿⣿⣿⡿⣾⡽⣾⡽⣾⡽⣯⡿⣯⣿⣽⣻⡾⣟⣯⡽⣞⣳⢯⢯⡽⣞⣻⢾⣏⣿⢯⣞⣯⣳⢟⣮⢿⣽⣻⢞⡽⣮⡹⢿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣟⣾⣻⢾⡽⣿⣿⡿⣿⣽⣿⣳⣟⣷⣻⢷⣻⢷⣻⣷⣟⡾⣯⢟⡾⣖⡿⣭⡟⣾⣫⢷⢯⣽⣻⢮⡽⣞⡮⢷⡭⣟⣾⣻⠶⣏⡿⣽⠶⣏⡷⣹⢟⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⢷⣯⣷⣯⢿⣽⣿⣿⣿⣿⣟⣷⣻⣞⡷⣯⢿⡽⣯⢷⣻⢾⣽⡳⣯⢟⡾⣵⣛⣾⢳⣽⣫⢟⡷⣿⣚⣿⣳⣽⣫⢾⣽⣟⣧⢿⣽⣹⢯⡿⣽⢞⣵⣫⢞⣣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣯⢿⣟⣯⣟⡿⣾⣿⣯⣿⢾⣽⣞⡷⣯⢿⡽⣯⢿⡽⣯⣟⣯⢾⣝⣳⢯⣟⠾⣝⣞⡯⣶⣯⡿⣽⣻⣽⣾⣽⢞⣳⢯⣾⣟⡾⣏⡾⣭⢷⣻⠽⣞⢧⢯⢿⡼⣹⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣽⣯⣿⣿⣞⣿⣿⢿⣽⣾⠛⠇⢸⡿⣽⢯⡿⣽⢯⣟⣷⣻⢯⡾⣭⣟⣳⢾⣻⢷⢛⣵⠷⠷⣭⣛⣯⡷⣯⣻⢞⡽⣚⣯⢿⡽⣯⡽⣏⣯⢷⣻⢯⣯⣟⣮⢳⢷⡺⣵⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡾⣷⣿⣿⣿⣾⣿⢿⢟⢶⣳⣾⣒⣿⢯⡿⣽⢯⣟⣾⣳⡯⣷⢫⡷⣾⢽⣻⣅⣹⡟⢸⣶⠔⣿⣤⣷⣟⡷⢯⣯⣽⢫⣿⡯⣟⣵⡻⣝⣾⢣⣿⣟⣮⣽⣾⣿⣾⣿⣿⠟⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣽⣻⣟⣯⢿⣻⣟⣯⢿⡽⣯⣟⣾⣳⡯⣟⡵⣯⣟⣞⣯⢷⣏⢛⣧⡜⣫⢜⣿⣢⣞⡾⣽⡻⣞⡼⣯⢷⡻⣝⣮⡽⡿⣭⣿⣷⣿⣿⣿⣿⣿⣿⡟⠀⢸⣯⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⢿⣿⣯⣿⣿⣿⣿⡷⣟⡾⣽⢯⣷⣻⣞⣯⣟⣷⣻⣞⡷⣿⡽⣹⢶⣻⢮⡽⣾⢽⣻⢯⣿⡾⣾⣻⡽⢾⣹⣳⡽⣭⠿⣽⣯⢻⡵⢾⣹⣟⣿⣿⣿⣿⣿⣟⣷⣿⣿⡄⡄⢸⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣯⣿⡽⣟⣷⣿⢿⣿⣿⣯⢿⣽⣻⣞⣷⣻⢾⡽⣞⡷⣯⣟⡷⣽⢫⣯⠷⣯⢟⣾⣫⣽⣛⣮⣽⢳⢧⡟⣯⣳⡽⣳⢯⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣿⣿⣷⡙⡄⠙⢹⠿⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣞⡿⣟⣿⡽⣿⣯⣷⣿⣟⣾⣳⣟⣾⣽⣿⡠⠤⠤⠭⠭⠭⢉⣿⣼⡻⣭⣟⡶⣛⣶⢻⡼⣞⡯⣟⣾⣳⢯⣿⡽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣾⣛⣿⣣⣏⢿⣺⣦⣵⣒⣒⣬⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣳⣟⣿⣷⣿⣿⣿⣿⢿⣽⣯⢉⡉⠉⠹⣧⠀⠀⠀⠀⢀⣜⣉⣋⡓⡛⠛⠓⢛⣹⣞⣷⣻⣷⣿⣽⣻⣾⣯⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢯⣻⣽⡿⣟⢿⡻⣜⢯⣻⡽⣿⢿⡿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢟⣿⡿⣽⣿⣿⣿⣿⣿⣿⣿⣿⠇⢰⠃⠀⠀⠀⠀⠀⠀⠤⠀⠈⠁⠀⠀⠀⢀⡜⠉⣹⣟⡾⣗⡿⣻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡽⢯⡷⣯⣿⢾⡷⣽⣞⣭⡷⣿⣹⣞⡷⢯⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠎⣷⠃⣹⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣘⣙⣉⣉⣹⠇⠀⠀⠀⠀⣸⣓⣚⣒⡒⠋⠀⣰⠿⣼⠿⣽⣳⢯⡿⣽⡻⣟⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣽⣷⣿⣾⢿⣷⢯⡿⣽⡷⠿⠚⢩⠻⢏⢆⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡎⣾⠿⣱⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣯⣟⡿⣿⣈⣉⣉⣙⣉⣙⣙⡿⣽⣳⣟⡻⢿⣹⡟⣧⢿⣻⡽⣯⣷⣯⣿⣿⣿⣿⣿⣿⢧⣿⠹⣿⠉⣿⣿⣿⣿⣿⣿⣻⣾⣟⣯⣟⡿⢋⡁⠰⣀⠃⢆⡙⢦⢉⢦⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣰⣿⢃⣾⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣾⣽⣿⡽⣯⣿⣽⣯⣟⣾⣱⣟⣳⡽⣾⣽⣏⡷⣽⢫⣟⣶⣿⣿⣿⣿⣿⣿⣿⡿⣿⡏⢸⣧⠘⣿⠀⣿⣿⣿⣿⣿⠛⠛⠿⠟⠻⣧⢒⠥⣊⠵⣌⠳⢄⠐⢂⠳⡌⢧⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠛⢧⣿⣽⡭⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⢸⣿⡇⢻⢹⣷⠸⢣⠃⡓⢦⢡⣷⢸⢸⣿⢰⣲⡆⢱⣿⣻⢾⡽⣷⣿⣿⣿⣿⡿⣯⣿⣿⡇⢸⡏⢸⡯⢠⣿⣿⢷⣯⠇⠀⠀⠀⠀⠀⠈⢻⡶⣡⠚⡌⠡⠌⡘⣦⠐⠤⣀⠑⢤⡀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡠⢊⡴⢡⢊⠻⣿⣼⣿⣿⣿⣿⣿⣿⣿⡟⠁⠀⠈⣿⣶⣾⣷⢿⣿⢿⣿⣿⣶⣳⢶⣞⡶⣞⡶⣶⢷⣻⢮⡷⣯⣿⣿⣿⣿⣟⣷⣻⣿⣿⢿⡇⢸⡇⢸⠇⢸⣿⢯⣟⡾⠀⠀⠀⠀⠀⠀⠀⠀⠙⣷⡷⣈⠒⠈⡔⣹⢌⠲⣁⠦⠀⠙⢄⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⡩⣔⡯⣿⣸⠃⠱⣈⢛⣿⣻⣿⣿⣿⣿⡿⠁⠀⠀⠀⢹⣿⣳⣯⣿⢾⡿⣿⣿⣷⢯⣟⡾⣽⣏⡿⣽⣻⢯⡿⣽⣿⣿⣿⣿⣳⠿⣼⣿⣿⣿⣿⠀⣿⠀⣾⠀⢸⣟⡿⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣧⡆⠨⠄⡸⣌⠲⡡⢎⡑⢢⡈⠣⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⡪⢔⠮⣵⢫⠾⢃⠋⢀⡡⢖⣿⣾⣿⣿⣯⣿⡿⠁⠀⠀⠀⠀⠈⣿⣷⣿⣾⣿⢿⣿⣽⣿⣻⢾⣽⣳⢾⡽⣯⣟⣽⣿⣿⡿⣟⡿⣜⣳⣿⣿⣿⣿⣾⡇⠀⣿⠀⣿⠀⢸⣯⢿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⡅⢢⠱⣎⠱⡡⣆⠸⡡⢄⠀⢣
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⡚⢤⢛⡴⢫⠞⠲⢉⠰⢀⢢⠱⣬⣟⢫⡾⣽⣿⣾⡿⠁⠀⠀⠀⠀⠀⠐⣿⣿⣷⣿⣿⣿⣿⡿⣾⣽⣻⢾⡽⣯⣟⡷⡽⣾⣳⣯⣽⣳⣿⣽⣿⣿⣿⣯⢿⡽⡇⠀⣿⠀⣿⠀⢸⣯⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢧⡓⠉⠉⠷⣱⣘⢆⠡⠂⡉⢼
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠔⡊⠔⡬⣘⠦⡍⠆⠓⡌⡱⢈⡔⣡⢞⣹⢳⣞⣿⣿⣿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⣿⣿⣯⣿⣿⣯⣿⣿⣯⢷⣯⢿⣽⣳⢯⣻⠵⣯⣷⣟⣾⣽⣷⣿⣿⣿⣿⣿⣿⣿⡇⠀⣿⠀⣹⠀⣸⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠉⠀⡄⠉⠠⢀⠉⢀⠀⠑⢢⣹
⠀⠀⣀⣀⢀⡀⣀⠖⠉⣈⢧⠀⠀⠀⠀⠀⠀⣀⢤⣒⢮⡙⡔⣪⠜⣊⠒⡡⢊⡔⡩⢖⡸⣡⢧⡺⣜⣮⣿⣿⣾⣿⡿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣟⣿⣿⣿⣿⣯⣿⣟⣾⣻⢾⣽⢻⣼⢻⣯⢷⣿⣿⡿⣿⣿⣿⣟⣷⡻⣞⣷⡇⠀⡿⢁⣿⢀⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣦⡁⠸⣴⣜⣴⡭⣶⡏⠾⡼⢶⠉
⡴⠉⡄⠀⢀⡰⢥⣠⣽⣿⣯⣷⢄⡠⠴⣒⣽⣼⣾⢿⣆⠳⡘⢡⣘⡤⣋⠴⣣⢼⡱⢯⣜⣧⣿⣽⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣯⣟⡾⣽⢯⡞⣧⣟⡿⣾⣿⣿⣟⣿⣿⣿⣟⡾⣧⣿⣟⣷⡳⣠⠁⣸⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⠀⣼⢁⡀⢠⢐⡀⣈⠐⡀⠠⢠
⢸⡷⣆⣡⣾⣇⠟⢚⣿⣿⣿⣿⣿⣾⣿⢿⣙⣫⣵⣮⢿⣷⣛⣯⣵⣶⣽⣿⣽⣿⣿⣿⣿⣿⣿⣿⠿⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣟⣿⣿⣿⣻⡝⣮⣽⣳⢯⣿⣿⣿⣟⣾⣿⣿⡟⣾⣻⣏⡷⡾⠋⣰⡇⢀⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢉⡟⠾⠷⢾⢿⡻⢿⡽⢿⡏
⠏⠐⡠⢉⠉⣹⣤⣼⣿⣿⣿⣿⣿⣿⣷⣻⣿⣯⣷⣾⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⠛⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣾⣿⣿⣏⡷⣽⣷⣯⣿⣿⣿⣿⣳⣿⣿⣿⣳⣿⣿⡿⣯⢿⠁⢰⣟⣠⣾⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢧⣮⡝⢯⢶⣧⢇⣶⣻⠇
⠛⡿⢳⡷⠾⠟⠛⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠟⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⢷⣿⣿⢟⣽⣿⣿⣟⣾⣿⣿⣟⣾⣿⢿⣽⣾⣿⣿⢯⡿⣽⠏⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⡤⣩⣍⣫⣌⣴⣿⠏⠀
⠀⠳⡶⣬⣓⣤⠿⠟⣋⣿⡿⣟⣫⣿⠿⠛⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⡿⣯⢿⣽⣾⣿⣿⡟⣧⣿⣿⣿⢯⣟⣿⣽⣾⣿⣿⣻⣞⣯⢿⡝⢀⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⠾⠷⠾⠟⠉⠀⠀
⠀⠀⢹⣀⠆⡴⣤⣾⣿⣿⡿⠟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡿⣽⣿⣿⣿⣿⡟⣧⢿⣿⣿⣟⣧⣿⣿⣿⡿⣿⡽⣞⣷⣻⣞⡟⣠⣿⣟⣾⡿⣯⢿⣿⣿⢿⣿⣿⣿⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠉⠛⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⣾⢿⣽⣿⣿⣛⣾⣿⣿⢿⣯⣟⣷⣻⡽⣾⢳⡟⢹⡏⢻⡇⠸⣽⣻⣿⢿⣽⣯⣿⣿⣿⢯⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢾⣿⣿⣿⣯⣿⣟⣯⣿⣿⣿⣾⣿⣿⣻⣽⣻⢾⡽⣞⡷⣻⢭⣏⢿⠀⢧⠈⢷⡀⠻⣟⡿⣯⣿⣿⢿⣻⣽⣿⣻⡦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⡟⣿⣷⣿⣿⣿⣿⣿⢻⣷⣯⡟⣾⣽⣯⠛⣷⣽⢹⣮⡟⣾⢣⠘⣷⡄⢹⣦⠈⣿⣽⣿⣾⣿⣿⣷⣿⣷⣿⣵⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⣿⣽⣿⡿⣿⣿⣿⢿⣻⣾⣿⣻⡽⣛⡷⣻⡼⣻⢵⣫⡟⣼⣿⢯⡿⡄⢸⣧⠀⣿⠀⢽⣻⣽⣯⢿⣽⡻⣟⣿⣻⣷⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⢿⣿⣿⡿⣟⢾⣱⣻⢭⢷⡻⣼⢏⣷⣻⣼⢿⣯⣿⣿⡇⣹⣿⢸⣿⠀⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣿⣿⡿⣿⣿⣟⣿⡿⣏⣷⢫⣯⢳⣭⡟⣾⣝⣷⢿⣻⣽⣾⣿⣿⣿⣿⡗⢻⣯⠀⣿⠀⢹⣟⣿⣻⢯⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣽⣿⣿⡿⣽⣟⣳⡽⣞⣻⣼⣛⣶⣻⢳⣯⣞⣯⣿⣿⣿⡟⣛⡿⣽⢇⠀⣿⠀⢹⡇⠈⣟⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣻⣿⣻⣯⣿⣽⣫⢾⣵⡻⣧⢯⣟⣶⣿⣻⢷⣯⣿⢿⣻⢽⡻⣝⣻⢮⣿⠀⠹⡇⠸⣷⠀⢿⣳⣯⢿⣽⣿⣿⣿⣿⣿⢿⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣾⣷⣯⣷⣾⡽⣿⣞⣿⡻⣟⣯⣷⣾⢿⡟⣿⣻⢯⡷⣯⠿⠙⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⢉⡠⣾⣿⣷⡟⠁⡏⠀⠀⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣯⢿⣟⣮⢷⣻⣶⣻⣶⣻⣽⣞⣳⣯⠿⠙⢗⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢤⣾⣭⢿⡟⣹⣿⡷⠀⡅⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⠋⠉⠉⠋⠉⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠚⠉⠀⠀⢻⡇⢹⣟⡿⠱⠁⢠⠐⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⡇⣿⣿⢃⠇⢠⠂⢨⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣰⣿⣿⢿⡿⠄⢠⠃⠠⡾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Random rand = new Random();
        int eq1;
        Console.WriteLine("\nElije un equipo del 1 al 10\n");
        //Selecciono un equipo del 1 al 10. Si ingreso un numero invalido, se me asignara uno aleatorio
        string? equipoEl = Console.ReadLine();
        if (int.TryParse(equipoEl, out eq1))
        {
            if (eq1 > 10 || eq1 < 0)
            {
                eq1 = rand.Next(1, 11);
            }

        }
        else
        {
            eq1 = rand.Next(1, 11);
        }
        //Asigno al equipo1, el equipo elegido (resto 1 porque debo tener en cuenta que en un arreglo comienza en la direccion 0)
        Equipos equipo1 = listadoEquipos[eq1 - 1];
        Console.WriteLine("EQUIPO ELEGIDO: " + equipo1.Nombre());
        //Elimino el equipo1 de la lista de equipos (ya que no puedo jugar contra mi mismo)
        listadoEquipos.Remove(equipo1);
        //Juego contra un equipo aleatorio
        int eq2;
        eq2 = rand.Next(0, (listadoEquipos.Count()));
        Equipos equipo2 = listadoEquipos[eq2];
        //Lo elimino de la lista, ya que no puedo jugar 2 veces con el mismo equipo
        listadoEquipos.Remove(equipo2);
        //JuegaPartida es la funcion que se encarga de jugar los partidos y devuelve el equipo ganador (con las estadisticas modificadas segun corresponda)
        Equipos ganador = JuegaPartida(equipo1, equipo2);
        //Juego partidas mientras gano y no haya vencido todos los equipos del juego, sigo jugando
        while (ganador == equipo1 && listadoEquipos.Count() > 0)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(@"
  _____ _____ _____ _    _ _____ ______ _   _ _______ ______   _____        _____ _______ _____ _____   ____  
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____| |  __ \ /\   |  __ \__   __|_   _|  __ \ / __ \ 
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__    | |__) /  \  | |__) | | |    | | | |  | | |  | |
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|   |  ___/ /\ \ |  _  /  | |    | | | |  | | |  | |
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |  / ____ \| | \ \  | |   _| |_| |__| | |__| |
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______| |_| /_/    \_\_|  \_\ |_|  |_____|_____/ \____/ 
                                                                                                               
                                                                                                               ");
            Console.WriteLine(@"
                                                                                        ,/)
                                                                                        |_|
        _        _        _        _        _        _        _        _        _       ].[       ,~,
       |.|      |.|      |.|      |.|      |.|      |.|      |.|      |.|      |.|    /~`-'~\     |_|
       ]^[      ]^[      ]^[      ]^[      ]^[      ]^[      ]^[      ]^[      ]^[   (<|   |>)    ]0[
     /~/^\~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  \|___|/   ,-`^'~\
    {<| $ |>}{<| 8 |>}{<| 6 |>}{<| , |>}{<| 3 |>}{<| 7 |>}{<| 9 |>}{<| , |>}{<| 2 |>} {/   \}  {<|   |>}
     \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  /__1__\   \|,__|/
    /\    \    /   \    /   \    /   \    /   \    /   \    /   \    /   \    /   \   | / \ |   {/ \  /
    |/>/|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  |/   \|   /__|\/\
    |)   \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  {}   {}   | / \ |
   (_|    \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  |)   (|   (/   \)
   / \    (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  ||   ||  _|)   (|_
.,.\_/,..,|,)(.|,.,|,)(,|,.,|.)(.|,.,|,)(,|,.,|.)(.|,.,|,)(,|,.,|.)(.|,.,|,)(,|,.,|.)(.|.,.|,)(.,|.,.|,.),.,.");
//Restablezco los goles del equipo despues de cada partido
            equipo1.ReestableceGoles();
// Elijo un nuevo equipo para enfrentar que aún no alla enfrentado
            eq2 = rand.Next(0, (listadoEquipos.Count()));
            equipo2 = listadoEquipos[eq2];
            listadoEquipos.Remove(equipo2);
            //ganador es el equipo1 si gane el partido anterior, por lo tanto, aumento su nivel y juego la partida
            ganador.aumentaNivel();
            ganador = JuegaPartida(equipo1, equipo2);
        }
// Si ya venci todos los equipos, gane, sino quiere decir que salgo del while porque perdí
        if (listadoEquipos.Count() == 0)
        {
            Console.WriteLine(@"
   _____          __  __ _____  ______ ____  _   _ _ _ 
  / ____|   /\   |  \/  |  __ \|  ____/ __ \| \ | | | |
 | |       /  \  | \  / | |__) | |__ | |  | |  \| | | |
 | |      / /\ \ | |\/| |  ___/|  __|| |  | | . ` | | |
 | |____ / ____ \| |  | | |    | |___| |__| | |\  |_|_|
  \_____/_/    \_\_|  |_|_|    |______\____/|_| \_(_|_)
                                                       
                                                       ");
            Console.WriteLine(@"
        ____
       ( () )
        \  /
         ||
         ||
        [__]
       /)  (\
      (( () ))
       \\__//
        `..'
         ||
         ||    
        //\\__
     _ ((  `--'
    (_) \)
");
            Console.WriteLine("\nGANADOR: ");
            Console.WriteLine(equipo1.Mostrar());
        }
        else
        {
            Console.WriteLine(@"
  _____  ______ _____  _____ _____  _____ _______ ______ _ _ 
 |  __ \|  ____|  __ \|  __ \_   _|/ ____|__   __|  ____| | |
 | |__) | |__  | |__) | |  | || | | (___    | |  | |__  | | |
 |  ___/|  __| |  _  /| |  | || |  \___ \   | |  |  __| | | |
 | |    | |____| | \ \| |__| || |_ ____) |  | |  | |____|_|_|
 |_|    |______|_|  \_\_____/_____|_____/   |_|  |______(_|_)
                                                             
                                                            ");
            Console.WriteLine(@"
         _
        |.|
        ]^[
      ,-|||~\
     {<|||||>}
      \|||||/
      {/   \}
      /__9__\
      | / \ |
      (<   >)
     _|)   (|_
,.,.(  |.,.|  ).,.,.");
        }


    }
    public enum Jugada
    {
        penal = 1,
        tiroLibre = 2,
        frenteAFrente = 3,
        saqueDelMedio = 4,
        saqueDelArco = 5,
        corner = 6,
        otra = 7
    }
    public static double Efectividad(Jugada jugada)
    {
        double efectividad;
        switch (jugada)
        {
            case Jugada.penal:
                efectividad = 75;
                break;
            case Jugada.frenteAFrente:
                efectividad = 70;
                break;
            case Jugada.saqueDelArco:
                efectividad = 25;
                break;
            case Jugada.saqueDelMedio:
                efectividad = 30;
                break;
            case Jugada.tiroLibre:
                efectividad = 60;
                break;
            case Jugada.corner:
                efectividad = 40;
                break;
            default:
                efectividad = 50;
                break;
        }
        return (efectividad);
    }
    public static string JugadaAleatoria(Jugada jugada)
    {
        string jugadaSTR;
        switch (jugada)
        {
            case Jugada.penal:
                jugadaSTR = "Penal\n";
                jugadaSTR += @"      ,
     -   \O                                     ,  .-.___
   -     /\                                   O/  /xx\XXX\
  -   __/\ `                                  /\  |xx|XXX|
     `    \, ()                              ` << |xx|XXX|
 jgs^^^^^^^^`^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
                break;
            case Jugada.frenteAFrente:
                jugadaSTR = "Frente a frente\n";
                jugadaSTR += @"
                     ___
 o__        o__     |   |\
/|          /\      |   |X\
/ > o        <\     |   |XX\";
                break;
            case Jugada.saqueDelArco:
                jugadaSTR = "Saque del arco";
                jugadaSTR += @"  -                              ___
         |.|                          . /\_/\
       __]-[_________ /             .  (-<_>-)
      /        _____|<_          .   .  \/_\/
     / _   &  /               .   .
    / / \_ __|            .
  _/_/  / X   \
 <_/   /   ____\
      /___/|  /             
      |  / ( <                
      ( <   \ |
       \ |   >\
       _>|  (_/
      (__|";
                break;
            case Jugada.saqueDelMedio:
                jugadaSTR = "Saque del medio\n";
                jugadaSTR += @"
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣿⣿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣾⣿⡿⠿⢿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⠁⠀⠚⠛⠉⢻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢛⣿⠀⠀⠀⠀⢀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⠴⠶⢶⣏⠙⣇⠀⠀⢀⣾⡟⢳⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠞⠋⠀⠀⠀⠀⠉⠙⠝⠷⠶⠛⣉⡴⠾⠇⠀⠈⢣⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⠾⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠴⠚⠁⠀⠀⢠⡄⢠⣤⣝⣦⣀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡏⠀⠀⠀⣀⣀⣀⣤⣶⣶⡶⠤⠤⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⣸⣿⣿⣯⢻⣦⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠏⠀⣠⣴⠿⠋⠉⠉⣽⣏⠙⠛⠲⠤⠄⡀⠀⠀⠀⠀⠀⠘⣦⣿⣿⣿⣿⣿⠀⠙⢷⡀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡾⠁⢀⡼⠋⠁⠀⠀⠀⠀⣿⣿⡿⢦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡿⠉⠉⠻⣇⠀⠀⢰⡇
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⠁⠀⢸⠃⠀⠀⠀⠀⠀⠀⣿⡇⠙⠒⠬⠉⠑⠂⠀⠀⠀⠀⠀⠀⣿⠃⠀⠀⠀⠙⠷⣦⡾⠃
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⠄⠀⠀⠀⠀⠀⠀⠙⢿⣤⡤⠀⠀⣄⠀⠀⠀⠀⠀⠀⢰⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⣸⡿⠂⢠⣤⣼⣷⣄⠀⠀⠀⠀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠟⠀⠀⠀⠀⠀⠈⠻⣿⣦⣤⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⣠⠄⠀⠀⢈⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣆⠀⢀⣾⠁⠀⢠⡾⠛⠉⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠛⠛⢷⣾⡇⠀⢠⡟⠀⠀⠀⠈⢻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠁⠀⠀⠀⢹⣿⣷⣾⡶⠀⠀⠀⢀⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠛⠛⠻⣦⠀⠀⣻⣿⠋⠁⠀⠰⣦⣴⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣰⠟⠀⠀⠀⣀⣹⣷⣾⣿⠇⠀⠀⢀⣴⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡶⣶⠛⠋⠉⠀⠀⣴⡞⠙⠛⠋⠙⣿⡄⢀⣴⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠟⠁⠀⢀⡄⠀⣀⣤⣼⣿⠇⢠⣾⣦⠀⢿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢀⣤⣤⣤⣤⣴⠟⠁⠀⠀⠀⣸⣿⠟⠉⠀⠸⣇⣄⡀⠛⠋⢀⣀⣼⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢠⡟⠀⣈⠉⠀⣀⣀⡤⠶⠞⠛⠋⠉⠀⠀⠀⢤⡿⠿⣿⣦⣰⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⣠⡾⠃⠀⣹⣷⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⣄⡈⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣾⠋⠀⢀⡼⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢷⣴⠾⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
                break;
            case Jugada.tiroLibre:
                jugadaSTR = "Tiro Libre";
                jugadaSTR += @"
           _
         /_`\
         /-\ )
       __7_/_(_______ _
      /        _____|<_\
     /        /
    / /|__ __/    
  _/_/ /     |      
 <_/  /_     |
     /  \-___|
    ( )'  |  /      ___
     \ |  ( )      /\_/\
      >\  | /     (-<_>-)
     (_/  |/       \/_\/    
         (_)";

                break;
            case Jugada.corner:
                jugadaSTR = "Corner\n";
                jugadaSTR += @"
                              +---------------------------+    
                              |\                          |\   
                              | \    @ \_    /            | \
                              |  \  /  \_o--<_/           | o\
______________________________|___|/______________________|-|\|__________________
         /                   /    /              _ o     / /|_                /
        /                   /  _o'------------- / / \ ----/                  /
       /                   /  /|_                /\    /                    /
      /                   /_ /\ _______________ / / __/                    /
     /                      / /                                           /
    /                                                                    /
   /                                                                    /
  /                                                                    /
 /____________________________________________________________________/";
                break;
            default:
                jugadaSTR = "Otro\n";
                jugadaSTR += @"
                ⠀⠀⠀⣀⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢠⣾⢽⣍⣹⠾⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢸⣷⢼⡁⢘⠗⢳⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠈⠻⣦⣯⣹⣶⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢀⣰⠀⠀⠀⣼⣥⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢸⡏⠀⠀⠀⠻⣿⣿⣿⣿⠛⠳⢤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠈⣧⠀⠀⠀⠀⠈⠁⠉⢿⣷⣤⣄⠀⠉⠑⢲⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠘⣆⠀⠀⠀⠀⠀⠀⠀⠉⠀⠈⠙⢦⣠⣾⠏⠈⠙⠲⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠘⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠳⢤⣀⠀⠀⠀⠑⢦⣀⣀⡤⢤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣶⣦⣀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠈⠳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣄⠀⢀⣼⣿⣿⣦⣤⠬⣍⡑⠒⠒⡎⠉⠉⠉⠙⠒⢤⡴⠋⠀⠈⣻⣿⣿⡆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⠳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⣿⣿⣿⣿⣿⣿⣧⣄⠉⠳⢴⣇⡀⠀⠀⠀⢠⢞⠀⠀⠀⠐⣿⣿⡟⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠓⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣿⡷⠖⠚⠉⠀⠀⠀⠀⠘⠮⢕⣒⣂⣼⠛⠁⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⢦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⡇⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠲⢤⣀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠹⣆⠀⠀⠀⠀⢿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⣀⡼⠋⠙⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠀⠀⠀⠈⣧⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠔⠋⠹⣷⠀⠀⣹⣿⣿⣿⣿⠧⠴⠒⠒⠒⠒⠒⠒⠒⠦⣄⡀⠀⠀⠀⢽⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣔⣞⠉⣀⣀⣀⡤⠛⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠣⡀⠀⠈⢿⣆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣶⣿⣿⡿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢲⡋⠉⢧⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⡀⠘⡆⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠳⡀⢹⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⠘⡆⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⣜⡦⣄⡀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠃";
                break;
        }
        return (jugadaSTR);
    }


    public static void JuegaJugadaDelanteroVsDefensa(Equipos equipo1, Equipos equipo2, Competition competicion)
    {
        //Presiono enter y se juega una jugada aleatoria (de 8 posibilidades de jugada).
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        Jugada jugada = (Jugada)rand.Next(0, 8);
        //Se determina la efectividad de la jugada seleccionada. Efectividad es una funcion que le paso la jugada y segun que tipo de jugada sea me devuelve la efectividad de la misma para ataque
        double efectividad1 = Efectividad(jugada);
        //La efectividad para defensa sera mayor si es menor la efectividad para ataque
        double efectividad2 = 100 - efectividad1;
        //MejoraLiga, es un metodo que si el area de la competicion coincide con el area del equipo, su efectividad (para atacar o defender) aumenta en un 25%
        efectividad1 = equipo1.MejoraLiga(competicion, efectividad1);
        efectividad2 = equipo2.MejoraLiga(competicion, efectividad2);
        Console.WriteLine("\nEfectividad ataque: " + efectividad1);
        //JugadaAleatoria es una funcion que nos devuelve una cadena con el nombre de la jugada y una descripcion grafica de la misma
        Console.WriteLine("\t\tJugada: " + JugadaAleatoria(jugada));
        //Ataque es un metodo que calcula los puntos de ataque de un jugador segun la efectividad
        double ataque = equipo1.Delantero.Ataque(efectividad1);
        Console.WriteLine("\nATACA: " + equipo1.Delantero.Nombre() + " puntos de ataque para esta jugada:  " + ataque);
        //Defensa es un metodo que calcula los puntos de defensa de un jugador segun la efectividad
        double defensa = equipo2.DefensaOArquero.Defensa(efectividad2);
        Console.WriteLine("DEFIENDE: " + equipo2.DefensaOArquero.Nombre() + " puntos de defensa para esta jugada:  " + defensa);
        Console.WriteLine("\n- Presiona una tecla para avanzar: ");
        tecla = Console.ReadLine();
        //Si el equipo que ataca tiene mas puntos que el que defiende, sera gol y se sumara un gol al equipo que ataca, si el equipo que defiende tiene mas puntos, no se suman goles. Si tienen igual puntos, quiere decir que el equipo que defiende tiene una posibilidad de hacer gol de contrataque. Si los puntos totales del equipo que defiende son mayores, entonces es gol de contrataque, sino no ocurre nada
        if (ataque > defensa)
        {
            Console.WriteLine(@"
   _____  ____  _      _ _ 
  / ____|/ __ \| |    | | |
 | |  __| |  | | |    | | |
 | | |_ | |  | | |    | | |
 | |__| | |__| | |____|_|_|
  \_____|\____/|______(_|_)
                           
                           ");
            Console.WriteLine("GOL DEL DELANTERO DE " + equipo1.Nombre() + "\n");
            equipo1.Goles += 1;
        }
        else
        {
            if (ataque < defensa)
            {
                Console.WriteLine(@"
  _____  ______ ______ ______ _   _  _____         _ _ 
 |  __ \|  ____|  ____|  ____| \ | |/ ____|  /\   | | |
 | |  | | |__  | |__  | |__  |  \| | (___   /  \  | | |
 | |  | |  __| |  __| |  __| | . ` |\___ \ / /\ \ | | |
 | |__| | |____| |    | |____| |\  |____) / ____ \|_|_|
 |_____/|______|_|    |______|_| \_|_____/_/    \_(_|_)
                                                       
                                                       ");
                Console.WriteLine("No fue gol, gana el defensa");
            }
            else
            {
                ataque = equipo2.DefensaOArquero.Ataque((efectividad2));
                defensa = equipo1.Delantero.Defensa(efectividad1);
                if (ataque < defensa)
                {
                    Console.WriteLine(@"
   _____  ____  _      _ _ 
  / ____|/ __ \| |    | | |
 | |  __| |  | | |    | | |
 | | |_ | |  | | |    | | |
 | |__| | |__| | |____|_|_|
  \_____|\____/|______(_|_)
                           
                           ");
                    Console.WriteLine("GOL DEL DEFENSOR (contrataque)" + equipo2.Nombre() + "\n");
                    equipo2.Goles += 1;
                }
                else
                {
                    Console.WriteLine(@"
  _____  ______ ______ ______ _   _  _____         _ _ 
 |  __ \|  ____|  ____|  ____| \ | |/ ____|  /\   | | |
 | |  | | |__  | |__  | |__  |  \| | (___   /  \  | | |
 | |  | |  __| |  __| |  __| | . ` |\___ \ / /\ \ | | |
 | |__| | |____| |    | |____| |\  |____) / ____ \|_|_|
 |_____/|______|_|    |______|_| \_|_____/_/    \_(_|_)
                                                       
                                                       ");
                    Console.WriteLine("No fue gol, pero el delantero frena el contrataque");
                }
            }
        }
    }
    public static void JuegaJugadaMediocampoVsMediocampo(Equipos equipo1, Equipos equipo2, Competition competicion)
    {
        double efectividad1 = equipo1.MejoraLiga(competicion, 50);
        double efectividad2 = equipo2.MejoraLiga(competicion, 50);
        double ataque1 = equipo1.Mediocampo.Ataque(efectividad1);
        double ataque2 = equipo2.Mediocampo.Ataque(efectividad2);
        //Determino quien ataca, que sera el de mas puntos, si tienen igual, ataca el de mas puntos de defensa, tienen igual, no ocurre nada
        if (ataque1 > ataque2)
        {
            Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
            Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre());
            Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre());
            //La funcion mediovsMedio se encarga de simular el enfrentamiento entre los 2 mediocampos. En este caso ataca el equipo1 ataca y el 2 defiende. Funciona igual que la delanterovsDefensa, pero como ahora tengo el atributo Mediocampo de equipos en vez de delantero y defensa, creo una funcion diferente
            MediovsMedio(equipo1, equipo2, competicion);

        }
        else
        {
            if (ataque2 > ataque1)
            {
                Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                Console.WriteLine("Ataca: " + equipo2.Mediocampo.Nombre());
                Console.WriteLine("Defiende: " + equipo1.Mediocampo.Nombre());
                //Ataca equipo2
                MediovsMedio(equipo2, equipo1, competicion);
            }
            else
            {
                double defensa1 = equipo1.Mediocampo.Defensa(efectividad1);
                double defensa2 = equipo2.Mediocampo.Defensa(efectividad2);
                if (defensa1 > defensa2)
                {
                    Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
                    Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre());
                    Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre());
                    MediovsMedio(equipo1, equipo2, competicion);
                }
                else
                {
                    if (defensa2 > defensa1)
                    {
                        Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                        Console.WriteLine("Ataca: " + equipo2.Mediocampo.Nombre());
                        Console.WriteLine("Defiende: " + equipo1.Mediocampo.Nombre());
                        MediovsMedio(equipo2, equipo1, competicion);
                    }
                    else
                    {
                        Console.WriteLine("\nNingun jugador pudo generar una ocación, por lo tanto, competirán otros 2 jugadores");
                    }
                }
            }
        }

    }
    public static void MediovsMedio(Equipos equipo1, Equipos equipo2, Competition competicion)
    {
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        //Selecciono la jugada
        Jugada jugada = (Jugada)rand.Next(0, 8);
        // Determino la efectividad de ataque y defensa
        double efectividad1 = Efectividad(jugada);
        double efectividad2 = 100 - efectividad1;
        //Determino si hay mejora por area
        efectividad2 = equipo2.MejoraLiga(competicion, efectividad2);
        efectividad1 = equipo1.MejoraLiga(competicion, efectividad1);
        Console.WriteLine("\nEfectividad ataque: " + efectividad1);
        Console.WriteLine("\n\t\tJugada: " + JugadaAleatoria(jugada));
        double ataque = equipo1.Mediocampo.Ataque(efectividad1);
        //Determino puntos de ataque del atacante
        Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre() + " puntos de ataque para esta jugada:  " + ataque);
        double defensa = equipo2.Mediocampo.Defensa(efectividad2);
        // Putnos de defensa
        Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre() + " puntos de defensa para esta jugada:  " + defensa);
        Console.WriteLine("\n- Presiona una tecla para avanzar: ");
        tecla = Console.ReadLine();
        //Si tiene mas puntos de ataque, gol del equipo que ataca, si tiene mas puntos el que defiende, no pasa nada (no es gol), si tienen igual, el equipo de defensa puede hacer un gol de contrataque si es que tiene mas puntos de ataque que los puntos de defensa del que defiende
        if (ataque > defensa)
        {
            Console.WriteLine("GOL DEL DELANTERO DE " + equipo1.Nombre() + "\n");
            equipo1.Goles += 1;
        }
        else
        {
            if (ataque < defensa)
            {
                Console.WriteLine("No fue gol, gana el defensa");
            }
            else
            {
                ataque = equipo2.Mediocampo.Ataque((efectividad2));
                defensa = equipo1.Mediocampo.Defensa(efectividad1);
                if (ataque < defensa)
                {
                    Console.WriteLine("GOL DEL DEFENSOR (contrataque)" + equipo2.Nombre() + "\n");
                    equipo2.Goles += 1;
                }
                else
                {
                    Console.WriteLine("No fue gol, pero el delantero frena el contrataque");
                }
            }
        }
    }

    public static Equipos JuegaPartida(Equipos equipo1, Equipos equipo2)
    {
        //Elijo la competicion en la que se jugara mi partida. Si el area de la competicion coincide con el area de mi equipo, mi equipo tendrá mas posibilidades de ganar (este dato lo saco de la API)
        var buscadorLiga = new PersonajesJSON();
        string? avanzar;
        int factor;
        int aumentaONo;
        Random rand = new Random();
        var competicion = new Competencias();
        //Obtengo las competencias de la API
        competicion = buscadorLiga.GetCompetencias();
        int cant = competicion.competitions.Count();
        //Obtengo una liga aleatoria de la API
        int indiceLiga = rand.Next(0,cant);
        while (competicion.competitions[indiceLiga] == null)
        {
            indiceLiga = rand.Next(0, competicion.competitions.Count());
        }
        var liga = competicion.competitions[indiceLiga];
        //Muestro en que competencia se dara el enfrentamiento
        Console.WriteLine("\n" + liga.Mostrar() + "\n");

        //Muestro los equipos que jugaran entre si con sus jugadores
        Console.WriteLine("\t\t\t---Equipo 1:  " + equipo1.Nombre() + "\n");
        Console.WriteLine(equipo1.Mostrar());
        Console.WriteLine("\n....................................................................................\n");
        Console.WriteLine("\t\t\t---Equipo2:" + equipo2.Nombre() + "\n");
        Console.WriteLine(equipo2.Mostrar());
        //Comienzo a jugar las distintas jugadas (seran al menos 3)
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

        Console.WriteLine("\n\nATACA: " + equipo1.Nombre() + ",\nDEFIENDE: " + equipo2.Nombre());
        //JuegaJugadaDelanteroVsDefensa es una funcion que se encarga de realizar el enfrentamiento entre delanteros de un equipo y defensores del otro y modifica (si es que se necesita) las estadisticas del equipo, aumenta los goles si es que hay gol,etc.
        JuegaJugadaDelanteroVsDefensa(equipo1, equipo2, liga);
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

        Console.WriteLine("\n\nATACA " + equipo2.Nombre() + ", \nDEFIENDE: " + equipo1.Nombre());
        //Ahora defiende el otro equipo y ataca el mio
        JuegaJugadaDelanteroVsDefensa(equipo2, equipo1, liga);
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

        Console.WriteLine("\n\nSe enfrentan mediocampos");
        //Enfrentamiento entre los mediocampos de ambos equipos. Primero, se evalua cual de los dos mediocampos (el del equipo1 o 2) tiene mas puntos de ataque. El que tiene mas puntos ataca, el que tiene menos defiende. Si tienen igual, ataca el que mas puntos de defensa tiene, si tienen igual, no ocurre nada.
        JuegaJugadaMediocampoVsMediocampo(equipo1, equipo2, liga);
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");
        //si el equipo 1 despues de las 3 jugadas iniciales tiene mas goles, es el ganador y  pasa la siguiente ronda
        if (equipo1.GolesMarcados() > equipo2.GolesMarcados())
        {
            Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo1.Nombre());
            Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
            return (equipo1);
        }
        else
        //Si tiene mas goles el equipo2 al cabo de las 3 jugadas iniciales será el ganador
        {
            if (equipo2.GolesMarcados() > equipo1.GolesMarcados())
            {
                Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo2.Nombre());
                Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                return (equipo2);
            }
            else
            //Si tienen igual, iran a un desempate. Para lo cual, mientras esten empatados, se daran indicaciones aleatorias las cuales pueden aumentar, disminuir o no modificar las estadisticas del equipo elegido
            {
                Console.WriteLine("\n\nDESEMPATE: ");
                while (equipo1.GolesMarcados() == equipo2.GolesMarcados())
                {
                    Console.WriteLine("RESULTADO PARCIAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + " - " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    Console.WriteLine("Presiona una tecla para dar indicaciones aleatorias al equipo: Si las indicaciones son:\n\tMuy buenas → aumentan en 2 todas las estadisticas de tus jugadores\n\tBuenas →aumentan en 1 todas las estadísticas de tus jugadores\n\tNeutrales, no modifcan el juego de tus jugadores\n\tMalas → Disminuyen 1 las estadisticas de tus jugadores\n\tMuy malas → Disminuyenn 2 puntos las estadisticas de tus jugadores");
                    avanzar = Console.ReadLine();
                    //Determina el factor en que aumentan o disminuyen las estadisticas si lo hacen
                    factor = rand.Next(1, 3);
                    // Determina si aumentan, disminuyen o no se modifican las estadisticas (0 no se modifican, 1 aumentan, 2 disminuyen)
                    aumentaONo = rand.Next(0, 3);
                    switch (aumentaONo)
                    {
                        case 0:
                            Console.WriteLine("No se modifican las estadisticas de tus jugadores");
                            break;
                        case 1:
                            Console.WriteLine("Buenas indicaciones, aumentan las estadisticas de tus jugadores en un factor: " + factor);
                            //Aumenta Estadisticas es un Metodo de la clase personajes que aumenta las estadisticas de los jugadores 1 0 2 puntos dependiendo del factor
                            equipo1.AumentaEstadisticas(factor);
                            break;
                        case 2:
                            Console.WriteLine("Malas indicaciones, disminuyen las estadisticas de tus jugadores en un factor " + factor);
                            //Disminuye Estadisticas es un Metodo de la clase personajes que disminuye las estadisticas de los jugadores 1 0 2 puntos dependiendo del factor
                            equipo1.DisminuyeEstadisticas(factor);
                            break;
                        default:
                            break;
                    }
                    //Mientras sea empate, juego varias veces la jugada
                    Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

                    JuegaJugadaDelanteroVsDefensa(equipo1, equipo2, liga);
                    Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

                    JuegaJugadaDelanteroVsDefensa(equipo2, equipo1, liga);
                    Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

                    JuegaJugadaMediocampoVsMediocampo(equipo1, equipo2, liga);
                    switch (aumentaONo)
                    {
                        case 0:
                            break;
                        case 1:
                            equipo1.DisminuyeEstadisticas(factor);
                            break;
                        case 2:
                            equipo2.AumentaEstadisticas(factor);
                            break;
                        default:
                            break;
                    }
                }
                //Si los goles marcados son mayores que los del otro equipo, quiere decir que gane, sino perdi
                if (equipo1.GolesMarcados() > equipo2.GolesMarcados())
                {
                    Console.WriteLine(@"
   _____              _   _               _____   _______   ______   _   _ 
  / ____|     /\     | \ | |     /\      / ____| |__   __| |  ____| | | | |
 | |  __     /  \    |  \| |    /  \    | (___      | |    | |__    | | | |
 | | |_ |   / /\ \   | . ` |   / /\ \    \___ \     | |    |  __|   | | | |
 | |__| |  / ____ \  | |\  |  / ____ \   ____) |    | |    | |____  |_| |_|
  \_____| /_/    \_\ |_| \_| /_/    \_\ |_____/     |_|    |______| (_) (_)
                                                                           
                                                                          ");
                    Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo1.Nombre());
                    Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    return (equipo1);
                }
                else
                {
                    
                    Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo2.Nombre());
                    Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    return (equipo2);

                }
            }

        }

    }


}
