using UnityEngine;
using System.Collections;

public class Minijuego3 : MonoBehaviour
{
	/*Varaibles de estilo para las teclas en GUI*/
	private GUIStyle oprimido;
	private GUIStyle noOprimido;

	/*Variable que tiene el score acumulado en el juego*/
	private bool MinijuegoActivo = false;
	private int score;
	public Texture2D botonOprimido;
	public Texture2D botonNoOprimido;
	private int tiempoAux = 0;
	private bool pasoSegundo = false;
	
	void Start ()
	{
		score = 0;
		oprimido =new GUIStyle();
		oprimido.normal.background = botonNoOprimido;
		noOprimido =new GUIStyle();
		noOprimido.normal.background = botonOprimido; 
		//tiempo = Time.time;
		//tiempoParseado = 0;
	}
	
	void Update ()
	{
		/*Parte que maneja todos los eventos de keypressed*/
		//print ("Cadena: " + respuesta);
		if(MinijuegoActivo){
			if(pasoSegundo && score < 300)
			{
				//PERDIO
				desactivar();
			}
			else if(pasoSegundo && score > 300)
			{
				//GANO
				desactivar();
			}
		}
	}
	/*Update del thread de la interfaz*/
	void OnGUI()
	{
		if(MinijuegoActivo){
		if(Input.GetKeyDown(KeyCode.Space))
		{
				score++;
		}
			GUI.Box(new Rect(0, 0, Screen.width, 20), "");
        	GUI.Box(new Rect(0, 0, Screen.width/300*score, 20), "");
		}
	}
	
	public void activar(){
		MinijuegoActivo = true;	
	}
	
	public void desactivar(){
		MinijuegoActivo = false;	
	}
	void FixedUpdate () 
	{
		float tiempo = 0;
		int tiempoParseado = 0;
		if(MinijuegoActivo){
			tiempo = Time.time;
			tiempoParseado = (int) (tiempo+(0.03));
			if(tiempoParseado%60 == 0 && tiempoAux != tiempoParseado)
			{
				tiempoAux = tiempoParseado;
				pasoSegundo = true;
			}
		}
		
	}
}