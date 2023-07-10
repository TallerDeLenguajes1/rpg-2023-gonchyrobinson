using System;
using System.Globalization;
namespace EspacioPersonajes

{
    public class fabricaPersonaje
    {
        private static string[] nombresDelanteros = {
        "Diego Maradona",
        "Lionel Messi",
        "Cristiano Ronaldo",
        "Ronaldo Nazário",
        "Emilio Butragueño",
        "Alfredo Di Stéfano",
        "Edinson Cavani",
        "Carlos Tevez",
        "Hugo Sánchez",
        "Radamel Falcao",
        "Alessandro Del Piero",
        "Sergio Aguero",
        "Javier Hernández",
        "Giacomo Bulgarelli",
        "Christian Vieri",
        "Hristo Stoichkov"
    };

        private static string[] apodosDelanteros = {
        "El Diego",
        "La Pulga",
        "CR7",
        "El Fenómeno",
        "El Buitre",
        "La Saeta Rubia",
        "El Matador",
        "El Apache",
        "El Tanque",
        "La Cobra",
        "El Príncipe",
        "El Kun",
        "El Chicharito",
        "Il Bambino d'Oro",
        "El Búfalo",
        "El Puma"
    };
        private static string[] fechaNacimientoDelanteros = {
    "30-10-1960",
    "24-06-1987",
    "05-02-1985",
    "22-09-1976",
    "22-08-1963",
    "04-01-1926",
    "14-02-1987",
    "05-02-1984",
    "11-02-1958",
    "10-02-1986",
    "09-11-1974",
    "02-06-1988",
    "01-06-1988",
    "19-07-1935",
    "23-07-1968",
    "08-08-1972"

};
        public static string[] nombresMediocampos = {
    "Andrés Iniesta",
    "Xavi Hernández",
    "Luka Modric",
    "Kevin De Bruyne",
    "Toni Kroos",
    "Paul Pogba",
    "N'Golo Kanté",
    "Frenkie de Jong",
    "Christian Eriksen",
    "Bruno Fernandes", 
    "Marco Verratti"
    // Agrega más nombres de mediocampistas aquí
};

        public static string[] apodosMediocampos = {
    "El Cerebro",
    "El Maestro",
    "El Mago",
    "El Cerebro",
    "El Metrónomo",
    "El Pogboom",
    "La Roca",
    "El Salvador",
    "El Genio", 
    "Bruno", 
    "Il Professore" 
    // Agrega más apodos de mediocampistas aquí
};

        public static string[] fechasNacimientoMediocampos = {
    "11-05-1984",
    "25-01-1980",
    "09-09-1985",
    "28-06-1991",
    "04-01-1990",
    "15-03-1993",
    "29-03-1991",
    "12-05-1997",
    "14-02-1992", 
    "08/09/1994",
     "05/11/1992"
    // Agrega más fechas de nacimiento de mediocampistas aquí
};
        public static string[] nombresArqueros = {
    "Manuel Neuer",
    "Jan Oblak",
    "Alisson Becker",
    "Thibaut Courtois",
    "Ederson Moraes"
    // Agrega más nombres de arqueros aquí
};

        public static string[] nombresDefensas = {
            "Sergio Ramos", 
            "Giorgio Chiellini",
            "Virgil van Dijk",
            "Kalidou Koulibaly",
            "Aymeric Laporte",
            "Leonardo Bonucci", 
            "Raphael Varane", 
            "Trent Alexander-Arnold", 
            "Andrew Robertson", 
            "Stefan de Vrij"
    // Agrega más nombres de defensas aquí
};

        public static string[] apodosArqueros = {
    "El Gato",
    "El Muro",
    "El Arquitecto",
    "La Muralla",
    "El Pulpo"
    // Agrega más apodos de arqueros aquí
};

        public static string[] apodosDefensas = {
    "El Capitán",
     "Il Gladiatore", 
     "The Rock", 
     "KK", 
     "The Wall",
    "BonBon", 
    "Varane", 
    "TAA", 
    "Robbo", 
    "The Iceman"
    // Agrega más apodos de defensas aquí
};

        public static string[] fechasNacimientoArqueros = {
    "27-03-1986",
    "07-01-1993",
    "02-10-1992",
    "11-05-1992",
    "17-08-1993"
    // Agrega más fechas de nacimiento de arqueros aquí
};

        public static string[] fechasNacimientoDefensas = {
    "30-03-1986", 
    "14-08-1984", 
    "08-07-1991", 
    "20-06-1991", 
    "27-05-1994",
    "01-05-1987", 
    "25-04-1993", 
    "07-10-1998", 
    "11-03-1994", 
    "05-02-1992"
    // Agrega más fechas de nacimiento de defensas aquí
};
        public Personaje CrearPersonaje(int posicionIngresada)
        {
            var random = new Random();
            var DatosPersonaje = new Datos();
            var CaracteristicasPersonaje = new Caracteristicas();
            var personajeCreado = new Personaje();
            int indicePersonaje;
            var fechaAux = new DateTime();
            Tipo posicion = (Tipo)posicionIngresada;
            if (posicionIngresada > 0 && posicionIngresada <= 4)
            {
                DatosPersonaje.TipoPersonaje = (Tipo)posicion;
            }
            else
            {
                posicion = (Tipo)3;
                //Por defecto mediocampo
                DatosPersonaje.TipoPersonaje = posicion;
            }
            switch (DatosPersonaje.TipoPersonaje)
            {
                case Tipo.delantero:
                    indicePersonaje = random.Next(0, (nombresDelanteros.Length-1));
                    if ((DateTime.TryParseExact(fechaNacimientoDelanteros[indicePersonaje], "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaAux)))
                    {
                        DatosPersonaje.FechaNacimiento = fechaAux;
                    }
                    else
                    {
                        DatosPersonaje.FechaNacimiento = FechaAleatoria();
                    }

                    DatosPersonaje.Nombre = nombresDelanteros[indicePersonaje];
                    DatosPersonaje.Apodo = apodosDelanteros[indicePersonaje];
                    CaracteristicasPersonaje.Control = random.Next(5, 10);
                    CaracteristicasPersonaje.Tiro = random.Next(5, 10);
                    CaracteristicasPersonaje.Intercepciones = random.Next(1, 5);
                    CaracteristicasPersonaje.Marcaje = random.Next(1, 5);
                    CaracteristicasPersonaje.Nivel = 1;

                    break;
                case Tipo.mediocampo:
                    indicePersonaje = random.Next(0, (nombresMediocampos.Length-1));
                    if (DateTime.TryParseExact(fechasNacimientoMediocampos[indicePersonaje], "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaAux))
                    {
                        DatosPersonaje.FechaNacimiento = fechaAux;
                    }
                    else
                    {
                        DatosPersonaje.FechaNacimiento = FechaAleatoria();
                    }

                    DatosPersonaje.Nombre = nombresMediocampos[indicePersonaje];
                    DatosPersonaje.Apodo = apodosMediocampos[indicePersonaje];
                    CaracteristicasPersonaje.Control = random.Next(1, 10);
                    CaracteristicasPersonaje.Tiro = random.Next(1, 10);
                    CaracteristicasPersonaje.Intercepciones = random.Next(1, 10);
                    CaracteristicasPersonaje.Marcaje = random.Next(1, 10);
                    CaracteristicasPersonaje.Nivel = 1;
                    break;
                case Tipo.defensa:
                    indicePersonaje = random.Next(0, (nombresDefensas.Length-1));
                    if (DateTime.TryParseExact(fechasNacimientoDefensas[indicePersonaje], "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaAux))
                    {
                        DatosPersonaje.FechaNacimiento = fechaAux;
                    }
                    else
                    {
                        DatosPersonaje.FechaNacimiento = FechaAleatoria();
                    }

                    DatosPersonaje.Nombre = nombresDefensas[indicePersonaje];
                    DatosPersonaje.Apodo = apodosDefensas[indicePersonaje];
                    CaracteristicasPersonaje.Control = random.Next(1, 5);
                    CaracteristicasPersonaje.Tiro = random.Next(1, 5);
                    CaracteristicasPersonaje.Intercepciones = random.Next(5, 10);
                    CaracteristicasPersonaje.Marcaje = random.Next(5, 10);
                    CaracteristicasPersonaje.Nivel = 1;
                    break;
                case Tipo.arquero:
                    indicePersonaje = random.Next(0, (nombresArqueros.Length-1));
                    if (DateTime.TryParseExact(fechasNacimientoArqueros[indicePersonaje], "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaAux))
                    {
                        DatosPersonaje.FechaNacimiento = fechaAux;
                    }
                    else
                    {
                        DatosPersonaje.FechaNacimiento = FechaAleatoria();
                    }

                    DatosPersonaje.Nombre = nombresArqueros[indicePersonaje];
                    DatosPersonaje.Apodo = apodosArqueros[indicePersonaje];
                    CaracteristicasPersonaje.Control = random.Next(1, 5);
                    CaracteristicasPersonaje.Tiro = random.Next(1, 5);
                    CaracteristicasPersonaje.Intercepciones = random.Next(5, 10);
                    CaracteristicasPersonaje.Marcaje = random.Next(5, 10);
                    CaracteristicasPersonaje.Nivel = 1;
                    break;
                default:
                    break;

            }
            DatosPersonaje.Edad = CalculaEdad(DatosPersonaje.FechaNacimiento);
            personajeCreado.DatosPersonaje = new Datos();
            personajeCreado.DatosPersonaje = DatosPersonaje;
            personajeCreado.CaracteristicasPersonaje = new Caracteristicas();
            personajeCreado.CaracteristicasPersonaje = CaracteristicasPersonaje;
            return (personajeCreado);
        }
        private DateTime FechaAleatoria()
        {
            DateTime fecha = DateTime.Today;
            var random = new Random();
            int RangoDias = random.Next(16 * 365, 70 * 365);
            fecha = fecha.AddDays(-RangoDias);
            return (fecha);
        }
        private int CalculaEdad(DateTime fechaNacimiento)
        {
            DateTime fechaHoy = DateTime.Now;
            TimeSpan diasTotales = fechaHoy - fechaNacimiento;
            int edad = (int)diasTotales.Days / 365;
            return (edad);
        }
    }
}