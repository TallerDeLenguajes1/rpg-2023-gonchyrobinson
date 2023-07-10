using System;
namespace EspacioPersonajes
{
    public class Personaje{

        private Datos datosPersonaje;
        private Caracteristicas caracteristicasPersonaje;

        public Datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }
        public Caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }
 
   
    public string Mostrar(){
            return("\tDatos: \n\t\tNombre: "+DatosPersonaje.Nombre+"\tApodo:  "+DatosPersonaje.Apodo + "\tFecha de Nacimiento: "+ DatosPersonaje.FechaNacimiento.ToShortDateString()+"\tEdad: "+DatosPersonaje.Edad+"\n\tCaracteristicas: \n\t\tTiro: "+CaracteristicasPersonaje.Tiro+"\tControl: "+CaracteristicasPersonaje.Control+"\tMarcaje: "+CaracteristicasPersonaje.Marcaje+"\tIntercepciones: "+CaracteristicasPersonaje.Intercepciones+"\tNivel: "+CaracteristicasPersonaje.Nivel);
        }
    public string Nombre(){
        return(datosPersonaje.Nombre);
    }
    public double Ataque(double efectividad){
        return((caracteristicasPersonaje.Control+caracteristicasPersonaje.Tiro)+(efectividad/100)*(caracteristicasPersonaje.Control+caracteristicasPersonaje.Tiro)+caracteristicasPersonaje.Nivel*(caracteristicasPersonaje.Control+caracteristicasPersonaje.Tiro)/10);
    }
    public double Defensa(double efectividad){
        return((caracteristicasPersonaje.Intercepciones+caracteristicasPersonaje.Marcaje)+(efectividad/100)*(caracteristicasPersonaje.Intercepciones+caracteristicasPersonaje.Marcaje)+caracteristicasPersonaje.Nivel*(caracteristicasPersonaje.Intercepciones+caracteristicasPersonaje.Marcaje)/10);
    }
    public void AumentaCaracteristicas(int factor){
        caracteristicasPersonaje.Control+=factor;
        caracteristicasPersonaje.Intercepciones+=factor;
        caracteristicasPersonaje.Tiro+=factor;
        caracteristicasPersonaje.Marcaje+=factor;
    }
    public void DisminuyeCaracteristicas(int factor){
        caracteristicasPersonaje.Control-=factor;
        caracteristicasPersonaje.Intercepciones-=factor;
        caracteristicasPersonaje.Tiro-=factor;
        caracteristicasPersonaje.Marcaje-=factor;
    }
    }
    

}