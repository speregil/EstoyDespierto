using UnityEngine;
using System.Collections;

public class Minijuego2 : MonoBehaviour
{
	/*Varaibles de estilo para las teclas en GUI*/
	private GUIStyle botonNormal;
	private GUIStyle botonPresionado;
	private GUIStyle inactivo;
	/*Tiempo actual registrado*/
	private float tiempo;
	/*tiempo actual pasado a un entero*/
	private int tiempoParseado;
	/*Variable que indica que acaba de pasar un segundo*/
	private bool pasoSegundo;
	/*Variable que tiene el score acumulado en el juego*/
	private bool MinijuegoActivo = false;
	private int score;
	public Texture2D botonNormalT;
	public Texture2D botonPresionadoT;
	public Texture2D botonInactivoT;
	public float radio;
	private float[] posicion1;
	private float[] posicion2;
	private float[] posicion3;
	bool activo1;
	bool activo2;
	bool activo3;
	
	private Vector3 posicion;
	
	private int id;
	
	void Start ()
	{
		score = 35;
		botonNormal =new GUIStyle();
		botonNormal.normal.background = botonNormalT;
		botonPresionado =new GUIStyle();
		botonPresionado.normal.background = botonPresionadoT;
		inactivo =new GUIStyle();
		inactivo.normal.background = botonInactivoT;
		posicion1 = new float[2];
		posicion2 = new float[2];
		posicion3 = new float[2];
		posicion1[0]=0;
		posicion1[1]=0;
		posicion2[0]=0;
		posicion2[1]=0;
		posicion3[0]=0;
		posicion3[1]=0;
		
		pasoSegundo = false;
		activo1 = true;
		activo2 = true;
		activo3 = true;
		
		posicion1 = random();
		posicion2 = random();
		posicion3= random();
		//tiempo = Time.time;
		//tiempoParseado = 0;
	}
	
	void Update ()
	{
		/*Parte que maneja todos los eventos de keypressed*/
		//print ("Cadena: " + respuesta);
		if(MinijuegoActivo){
		if(Input.GetMouseButtonDown(0))
		{
				posicion.x = Input.mousePosition.x;
				posicion.y = Screen.height - Input.mousePosition.y;
				print("posicion x: "+posicion.x);
				print("posicion y: "+posicion.y);
				if(estaDentro())
				{
					score++;
				}
				}
		if(pasoSegundo)
		{
				pasoSegundo = false;
				if(score*20 >= Screen.width){
					VariablesGlobales.extrovertido = true;
					desactivar();		
				}
				else if(score <= 0){
					VariablesGlobales.introvertido = true;
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
		if(id == 1 && activo1)
		{
			activo1 = false;
			if(GUI.Button(new Rect(posicion1[0],posicion1[1],radio*2,radio*2), "", inactivo))
			{
			}
		}
		else if(activo1)
		{
			if(GUI.Button(new Rect(posicion1[0],posicion1[1],radio*2,radio*2), "", botonNormal))
			{
			}
		}
		if(id == 2 && activo2)
		{
			activo2 = false;
			if(GUI.Button(new Rect(posicion2[0],posicion2[1],radio*2,radio*2), "", inactivo))
			{
			}
		}
		else if(activo2)
		{
			if(GUI.Button(new Rect(posicion2[0],posicion2[1],radio*2,radio*2), "", botonNormal))
			{
			}
		}
		if(id == 3 && activo3)
		{
			activo3 = false;
			if(GUI.Button(new Rect(posicion3[0],posicion3[1],radio*2,radio*2), "", inactivo))
			{
			}
		}
		else if(activo3)
		{
			if(GUI.Button(new Rect(posicion3[0],posicion3[1],radio*2,radio*2), "", botonNormal))
			{
			}
		}
		//Barra de progreso
		GUI.Box(new Rect(0, 0, Screen.width, 60), "");
        GUI.Box(new Rect(0, 0, 20 * score, 60), "");
		
		}
	}
	/*Metodo que genera las posiciones aleatorias de 
	 * los botones en la pantalla*/
	public float[] random()
	{
		float aleatorio = Random.Range(radio,(Screen.width-radio));
		float[] respuesta = new float[2];
		respuesta[0] = aleatorio;
		aleatorio = Random.Range(radio,(Screen.height-radio));;
		respuesta[1] = aleatorio;
		//print ("Random seed: " + decision);
		return respuesta;
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
			print("tiempoParseado: "+ tiempoParseado);
			if(tiempoParseado%3 == 0)
			{
				pasoSegundo = true;
				posicion1 = random();
				posicion2 = random();
				posicion3 = random();
				activo1 = true;
				activo2 = true;
				activo3 = true;
			}
		}
	}
	bool estaDentro()
	{
		float hipotenusa;
		hipotenusa = Mathf.Sqrt((Mathf.Pow(posicion.x-posicion2[0]-(radio),2)+Mathf.Pow(posicion.y-posicion2[1]-(radio),2)));
		if(hipotenusa < radio)
		{
			id = 2;
			return true;
		}
		hipotenusa = Mathf.Sqrt((Mathf.Pow(posicion.x-posicion1[0]-(radio),2)+Mathf.Pow(posicion.y-posicion1[1]-(radio),2)));
		//print("hipotenusa primer punto: "+hipotenusa);
		if(hipotenusa < radio)
		{
			id = 1;
			return true;
		}
		hipotenusa = Mathf.Sqrt((Mathf.Pow(posicion.x-posicion3[0]-(radio),2)+Mathf.Pow(posicion.y-posicion3[1]-(radio),2)));
		//print("hipotenusa tercer punto: "+hipotenusa);
		if(hipotenusa < radio)
		{
			id = 3;
			return true;
		}
		if(score>0)
		{
			score--;
		}
		return false;
	}
}