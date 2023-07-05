using System;
namespace EspacioPersonajes
{
    public class Personaje{

        private Datos datosPersonaje;
        private Caracteristicas caracteristicasPersonaje;

        public Datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }
        public Caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }
 
   
    public string Mostrar(){
            return("Datos: \n\tNombre:  "+DatosPersonaje.Nombre+"\n\tApodo:  "+DatosPersonaje.Apodo + "\n\tFecha de Nacimiento:   "+ DatosPersonaje.FechaNacimiento.ToShortDateString()+"\n\tEdad:  "+DatosPersonaje.Edad+"\nCaracteristicas: \n\tTiro:  "+CaracteristicasPersonaje.Tiro+"\n\tControl:  "+CaracteristicasPersonaje.Control+"\n\tMarcaje:  "+CaracteristicasPersonaje.Marcaje+"\n\tIntercepciones:  "+CaracteristicasPersonaje.Intercepciones+"\n\tNivel:  "+CaracteristicasPersonaje.Nivel);
        }
    public string Nombre(){
        return(datosPersonaje.Nombre);
    }
    public double Ataque(double efectividad){
        return((caracteristicasPersonaje.Control+caracteristicasPersonaje.Tiro)+(efectividad/100)*caracteristicasPersonaje.Nivel*(caracteristicasPersonaje.Control+caracteristicasPersonaje.Tiro));
    }
    public double Defensa(double efectividad){
        return((caracteristicasPersonaje.Intercepciones+caracteristicasPersonaje.Marcaje)+(efectividad/100)*caracteristicasPersonaje.Nivel*(caracteristicasPersonaje.Intercepciones+caracteristicasPersonaje.Marcaje));
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