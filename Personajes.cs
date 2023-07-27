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
    public double Ataque(double efectividad)
        {
            return (SumaAtaque() + (efectividad / 100) * (SumaAtaque()) + caracteristicasPersonaje.Nivel * (SumaAtaque()) / 10);
        }

        private int SumaAtaque()
        {
            return (caracteristicasPersonaje.Control + caracteristicasPersonaje.Tiro);
        }

        public double Defensa(double efectividad)
        {
            return ((SumaDefensa()) + (efectividad / 100) * (SumaDefensa()) + caracteristicasPersonaje.Nivel * (SumaDefensa()) / 10);
        }

        private int SumaDefensa()
        {
            return caracteristicasPersonaje.Intercepciones + caracteristicasPersonaje.Marcaje;
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