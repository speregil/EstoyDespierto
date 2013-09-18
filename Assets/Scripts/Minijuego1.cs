using UnityEngine;
using System.Collections;

public class Minijuego1 : MonoBehaviour
{
	/*Varaibles de estilo para las teclas en GUI*/
	private GUIStyle q;
	private GUIStyle w;
	private GUIStyle e;
	private GUIStyle u;
	private GUIStyle i;
	private GUIStyle o;
	private GUIStyle space;
	private GUIStyle labelTexto;
	/*Cadena a ejecutar en un segundo*/
	string respuesta;
	/*Tiempo actual registrado*/
	private float tiempo;
	/*tiempo actual pasado a un entero*/
	private int tiempoParseado;
	/*Variable que indica que acaba de pasar un segundo*/
	private bool pasoSegundo;
	/*Variable que tiene el score acumulado en el juego*/
	private bool MinijuegoActivo = false;
	private int score;
	public Texture2D botonOprimido;
	public Texture2D botonNoOprimido;
	public Font FuenteTexto;
	public Texture2D backgroundTexto;
	
	void Start ()
	{
		score = 35;
		q =new GUIStyle();
		q.normal.background = botonNoOprimido;
		w =new GUIStyle();
		e =new GUIStyle();
		u =new GUIStyle();
		i =new GUIStyle();
		o =new GUIStyle();
		space =new GUIStyle();
		labelTexto =new GUIStyle();
		labelTexto.font = FuenteTexto;
		labelTexto.normal.background = backgroundTexto;
		respuesta = random();
		pasoSegundo = false;
		//tiempo = Time.time;
		//tiempoParseado = 0;
	}
	
	void Update ()
	{
		/*Parte que maneja todos los eventos de keypressed*/
		//print ("Cadena: " + respuesta);
		if(MinijuegoActivo){
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(verificador("Q"))
			{
				//lo hizo bien
				score++;
			}
			else{
				if(score > 0){
					score--;}
			}
		}
		if(Input.GetKey(KeyCode.Q))	
		{
			q.normal.background = botonOprimido;
		}
		else
		{
			q.normal.background = null;
		}
		//w
		if(Input.GetKeyDown(KeyCode.W))
		{
			if(verificador("W"))
			{
				//lo hizo bien
				score++;
			}
			else{
				if(score > 0){
					score--;}
			}
		}
		if(Input.GetKey(KeyCode.W))	
		{
			w.normal.background = botonOprimido;
		}
		else
		{
			w.normal.background = null;
		}
		//e
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(verificador("E"))
			{
				//lo hizo bien
				score++;
			}
			else{
				if(score > 0){
					score--;}
			}
		}
		if(Input.GetKey(KeyCode.E))	
		{
			e.normal.background = botonOprimido;
		}
		else
		{
			e.normal.background = null;
		}
		//i
		if(Input.GetKeyDown(KeyCode.I))
		{
			if(verificador("I"))
			{
				//lo hizo bien
				score++;
			}
			else{
				if(score > 0){
					score--;}
			}
		}
		if(Input.GetKey(KeyCode.I))	
		{
			i.normal.background = botonOprimido;
		}
		else
		{
			i.normal.background = null;
		}
		//o
		if(Input.GetKeyDown(KeyCode.O))
		{
			if(verificador("O"))
			{
				//lo hizo bien
				score++;
			}
			else{
				if(score > 0){
					score--;}
			}
		}
		if(Input.GetKey(KeyCode.O))	
		{
			o.normal.background = botonOprimido;
		}
		else
		{
			o.normal.background = null;
		}
		//p
		if(Input.GetKeyDown(KeyCode.U))
		{
			if(verificador("U"))
			{
				//lo hizo bien
				score++;
			}
			else{
				if(score > 0){
					score--;}
			}
		}
		if(Input.GetKey(KeyCode.U))	
		{
			u.normal.background = botonOprimido;
		}
		else
		{
			u.normal.background = null;
		}
		//space
		if(Input.GetKeyDown(KeyCode.T))
		{
			if(verificador("T"))
			{
				//lo hizo bien
				score++;
			}
			else{
				if(score > 0){
					score--;}
			}
		}
		else
		{
			space.normal.background = null;
		}
		if(Input.GetKey(KeyCode.T))	
		{
			space.normal.background = botonOprimido;
		}
		
		if(pasoSegundo)
		{
			pasoSegundo = false;
			if(string.IsNullOrEmpty(respuesta))
			{
				Debug.Log("Empty");
				score ++;
				respuesta = random();
				
			}
				if(score*20 >= Screen.width){
					VariablesGlobales.racional = true;
					desactivar();		
				}
				else if(score <= 0){
					VariablesGlobales.artistico = true;
					desactivar();		
				}
		}
		}
	}
	/*Update del thread de la interfaz*/
	void OnGUI()
	{
		//Creacion de botones
		if(MinijuegoActivo){
		if(GUI.Button(new Rect((Screen.width/4),(Screen.height*3/4),20,20), "Q", q))
		{
		}
		if(GUI.Button(new Rect((Screen.width/4+20),(Screen.height*3/4),20,20), "W", w))
		{
		}
		if(GUI.Button(new Rect((Screen.width/4+40),(Screen.height*3/4),20,20), "E", e))
		{
		}
		if(GUI.Button(new Rect((Screen.width*3/4),(Screen.height*3/4),20,20), "U", u))
		{
		}
		if(GUI.Button(new Rect((Screen.width*3/4+20),(Screen.height*3/4),20,20), "I", i))
		{
		}
		if(GUI.Button(new Rect((Screen.width*3/4+40),(Screen.height*3/4),20,20), "O", o))
		{
		}
		if(GUI.Button(new Rect((Screen.width/2),(Screen.height*3/4),60,20), "T", space))
		{
		}
		//Barra de progreso
		GUI.Box(new Rect(0, 0, Screen.width, 60), "");
        GUI.Box(new Rect(0, 0, 20 * score, 60), "");
		
		GUI.Label(new Rect(Screen.width/2, Screen.height/2, 50, 50), respuesta,labelTexto);
		}
	}
	/*Metodo que crea un numero aleatorio entre 1 y 32 
	 * para los posibles inputs desafiantes del nivel*/
	public string random()
	{
		float aleatorio = Random.Range(1.0f,32.0f);
		string respuesta = "";
		int decision = (int)aleatorio;
		//print ("Random seed: " + decision);
		if(decision == 1)
		{
		   respuesta = "Q";
		}
		else if(decision == 2)
		{
		   respuesta = "W";
		}
		else if(decision == 3)
		{
		   respuesta = "E";
		}
		else if(decision == 4)
		{
		   respuesta = "T";
		}
		else if(decision == 5)
		{
		   respuesta = "U";
		}
		else if(decision == 6)
		{ 
		   respuesta = "I";
		}
		else if(decision == 7)
		{
		   respuesta = "O";
		}
		else if(decision == 8)
		{
		   respuesta = "QW";
		}
		else if(decision == 9)
		{
		   respuesta = "WE";
		}
		else if(decision == 10)
		{
		   respuesta = "ET";
		}
		else if(decision == 11)
		{
		   respuesta = "TU";
		}
		else if(decision == 12)
		{
		   respuesta = "UI";
		}
		else if(decision == 13)
		{
		   respuesta = "IO";
		}
		else if(decision == 14)
		{
		   respuesta = "QO";
		} 
		else if(decision == 15)
		{
		   respuesta = "WI";
		}
		else if(decision == 16)
		{
		   respuesta = "EU";
		}
		else if(decision == 17)
		{
		   respuesta = "QWE";
		}
		else if(decision == 18)
		{
		   respuesta = "WET";
		}
		else if(decision == 19)
		{
		   respuesta = "ETU";
		}
		else if(decision == 20)
		{
		   respuesta = "TUI";
		}
		else if(decision == 21)
		{
		   respuesta = "UIO";
		}
		else if(decision == 22)
		{
		   respuesta = "QWO";
		}
		else if(decision == 23)
		{
		   respuesta = "WEO";
		}
		else if(decision == 24)
		{
		   respuesta = "ETO";
		}
		else if(decision == 25)
		{
		   respuesta = "TUO";
		}
		else if(decision == 26)
		{
		   respuesta = "QWT";
		}
		else if(decision == 27)
		{
		   respuesta = "WTI";
		}
		else if(decision == 28)
		{
		   respuesta = "TIO";
		}
		else if(decision == 29)
		{
		   respuesta = "QIO";
		}
		else if(decision == 30)
		{
		   respuesta = "QUI";
		}
		else if(decision == 31)
		{
		   respuesta = "QTU";
		}
		else if(decision == 32)
		{
		   respuesta = "QET";
		}
		return respuesta;
	}
	/*Metodo que verifica que el input del teclado coincida 
	 * con el input pedido por el juego en un segundo dado*/	
	public bool verificador(string caracter)
	{
		if(respuesta.Contains(caracter))
		{
			char[] arreglo = caracter.ToCharArray();
			respuesta = respuesta.Trim(arreglo);
			Debug.Log("Respuesta: " + respuesta);
			return true;
		}
		return false;
	}
	
	public void activar(){
		MinijuegoActivo = true;	
	}
	
	public void desactivar(){
		MinijuegoActivo = false;	
	}
	/*Metodo que se ejecuta siempre en un tiempo determinado 
	 * por lo que es usado para saber cuando pasa un segundo*/
	void FixedUpdate () {
		if(MinijuegoActivo){
		tiempo = Time.time;
		tiempoParseado = (int) (tiempo+(0.03));
		if(tiempoParseado%3 == 0)
		{
			pasoSegundo = true;
			respuesta = random();
		}
		}
	}
}