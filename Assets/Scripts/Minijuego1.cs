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
	/*Cadena a ejecutar en un segundo*/
	string respuesta;
	/*Tiempo actual registrado*/
	private float tiempo;
	/*tiempo actual pasado a un entero*/
	private int tiempoParseado;
	/*Variable que indica que acaba de pasar un segundo*/
	private bool pasoSegundo;
	/*Variable que tiene el score acumulado en el juego*/
	private int score;
	public Texture2D botonOprimido;
	public Texture2D botonNoOprimido;
	
	void Start ()
	{
		q = new GUIStyle();
		w = new GUIStyle();
		e = new GUIStyle();
		u = new GUIStyle();
		i = new GUIStyle();
		o = new GUIStyle();
		space = new GUIStyle();
		respuesta = random();
		pasoSegundo = false;
		tiempo = Time.time;
		tiempoParseado = 0;
		
	}
	
	void Update ()
	{
		/*Parte que maneja todos los eventos de keypressed*/
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(verificador("q"))
			{
				//lo hizo bien
				score++;
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
			if(verificador("w"))
			{
				//lo hizo bien
				score++;
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
			if(verificador("e"))
			{
				//lo hizo bien
				score++;
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
			if(verificador("i"))
			{
				//lo hizo bien
				score++;
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
			if(verificador("o"))
			{
				//lo hizo bien
				score++;
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
			if(verificador("u"))
			{
				//lo hizo bien
				score++;
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
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(verificador(" "))
			{
				//lo hizo bien
				score++;
			}
		}
		else
		{
			space.normal.background = null;
		}
		if(Input.GetKey(KeyCode.Space))	
		{
			space.normal.background = botonOprimido;
		}
		
		if(pasoSegundo)
		{
			if(respuesta.Equals(""))
			{
				score ++;
			}
			else
			{
				score --;
			}
			respuesta = random();
		}
	}
	/*Update del thread de la interfaz*/
	void OnGUI()
	{
		/*Creacion de botones*/
		if(GUI.Button(new Rect((Screen.width/4),(Screen.height*3/4),20,20), "Q", q))
		{
		}
		if(GUI.Button(new Rect((Screen.width/4+20),(Screen.height*3/4),20,20), "W", w))
		{
		}
		if(GUI.Button(new Rect((Screen.width/4+40),(Screen.height*3/4),20,20), "E", e))
		{
		}
		if(GUI.Button(new Rect((Screen.width*3/4),(Screen.height*3/4),20,20), "I", u))
		{
		}
		if(GUI.Button(new Rect((Screen.width*3/4+20),(Screen.height*3/4),20,20), "O", i))
		{
		}
		if(GUI.Button(new Rect((Screen.width*3/4+40),(Screen.height*3/4),20,20), "O", o))
		{
		}
		if(GUI.Button(new Rect((Screen.width/2),(Screen.height*7/8),60,20), "Space", space))
		{
		}
		//Barra de progreso
		GUI.Box(new Rect(0, 0, Screen.width, 60), "");
        GUI.Box(new Rect(0, 0, 20 * score, 60), "", "Box2");
	}
	/*Metodo que crea un numero aleatorio entre 1 y 32 
	 * para los posibles inputs desafiantes del nivel*/
	public string random()
	{
		float aleatorio = Random.value + 1;
		string respuesta = "";
		int decision = (int)(aleatorio*32+(0.5));
		if(decision == 1)
		{
		   respuesta = "q";
		}
		else if(decision == 2)
		{
		   respuesta = "w";
		}
		else if(decision == 3)
		{
		   respuesta = "e";
		}
		else if(decision == 4)
		{
		   respuesta = " ";
		}
		else if(decision == 5)
		{
		   respuesta = "u";
		}
		else if(decision == 6)
		{ 
		   respuesta = "i";
		}
		else if(decision == 7)
		{
		   respuesta = "o";
		}
		else if(decision == 8)
		{
		   respuesta = "qw";
		}
		else if(decision == 9)
		{
		   respuesta = "we";
		}
		else if(decision == 10)
		{
		   respuesta = "e ";
		}
		else if(decision == 11)
		{
		   respuesta = " u";
		}
		else if(decision == 12)
		{
		   respuesta = "ui";
		}
		else if(decision == 13)
		{
		   respuesta = "io";
		}
		else if(decision == 14)
		{
		   respuesta = "qo";
		} 
		else if(decision == 15)
		{
		   respuesta = "wi";
		}
		else if(decision == 16)
		{
		   respuesta = "eu";
		}
		else if(decision == 17)
		{
		   respuesta = "qwe";
		}
		else if(decision == 18)
		{
		   respuesta = "we ";
		}
		else if(decision == 19)
		{
		   respuesta = "e u";
		}
		else if(decision == 20)
		{
		   respuesta = " ui";
		}
		else if(decision == 21)
		{
		   respuesta = "uio";
		}
		else if(decision == 22)
		{
		   respuesta = "qwo";
		}
		else if(decision == 23)
		{
		   respuesta = "weo";
		}
		else if(decision == 24)
		{
		   respuesta = "e o";
		}
		else if(decision == 25)
		{
		   respuesta = " uo";
		}
		else if(decision == 26)
		{
		   respuesta = "qw ";
		}
		else if(decision == 27)
		{
		   respuesta = "w i";
		}
		else if(decision == 28)
		{
		   respuesta = " io";
		}
		else if(decision == 29)
		{
		   respuesta = "qio";
		}
		else if(decision == 30)
		{
		   respuesta = "qui";
		}
		else if(decision == 31)
		{
		   respuesta = "q u";
		}
		else if(decision == 32)
		{
		   respuesta = "qe ";
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
			respuesta.Trim(arreglo);
			return true;
		}
		return false;
	}
	/*Metodo que se ejecuta siempre en un tiempo determinado 
	 * por lo que es usado para saber cuando pasa un segundo*/
	void FixedUpdate () {
		tiempo = Time.time;
		tiempoParseado = (int) (tiempo+(0.03));
		if(tiempoParseado > tiempo )
		{
			pasoSegundo = true;
			Debug.Log ("ha pasado un segundo: "+ tiempo);
		}
	}
}

