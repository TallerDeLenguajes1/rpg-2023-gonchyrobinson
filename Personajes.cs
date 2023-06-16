using System;
namespace EspacioPersonajes
{
    public class Personaje{
        private Datos datosPersonaje;
        private Caracteristicas caracteristicasPersonaje;

        public Datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }
        public Caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }
    public string Mostrar(){
            return("Datos: \n\tNombre:  "+DatosPersonaje.Nombre+"\n\tApodo:  "+DatosPersonaje.Apodo + "\n\tFecha de Nacimiento:   "+ DatosPersonaje.FechaNacimiento.ToShortDateString()+"\n\tEdad:  "+DatosPersonaje.Edad+"\nCaracteristicas: \n\tTiro:  "+CaracteristicasPersonaje.Tiro+"\n\tControl:  "+CaracteristicasPersonaje.Control+"\n\tMarcaje:  "+CaracteristicasPersonaje.Marcaje+"\n\t"+"\n\tIntercepciones:  "+CaracteristicasPersonaje.Intercepciones+"\n\tNivel:  "+CaracteristicasPersonaje.Nivel);
        }
    }

}