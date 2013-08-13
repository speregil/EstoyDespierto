using UnityEngine;
using System.Collections;

public class GUIDisplay : MonoBehaviour {
	
	public Texture2D iconoFlecha;
	public float angulo = 0.0f;
	public Grafo grafo;
	public GameObject Camara;
	public float velocidad;
	
	private bool flecha= false;
	private Vector3 posicionDestino;
	private Vector3 anguloDestino;
	
	private EstadosNivel estados;

	
	void Awake()
	{
		estados = new EstadosNivel();
	}
	
	void Start(){
		NodoGrafo n = estados.darEstadoActual();
		Camara.transform.position = n.darPosicion();	
	}
	
	void Update ()
	{
	 	if (flecha)
		{
			Vector3 posicionActual = Camara.transform.position;
			//angulo = Mathf.LerpAngle(0.0f,-90.0f,Time.time*0.2f);
			//Camara.transform.eulerAngles = new Vector3(0.0f,angulo,0.0f);
			Camara.transform.position = Vector3.MoveTowards(posicionActual,posicionDestino, Time.deltaTime*velocidad);
			
			if(posicionActual.Equals(posicionDestino)){
				flecha = false;	
			}
		}
	}
	
	void OnGUI () {

		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de arriba
		if(GUI.Button(new Rect((Screen.width/2)-40,40,80,20), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darAdelante();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			flecha = true;
			print ("Adelante");
		}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la izquierda
		if(GUI.Button(new Rect(20,(Screen.height/2),20,80), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darIzquierda();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			flecha = true;
			print ("Izquierda");
		}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la derecha
		if(GUI.Button(new Rect((Screen.width-40),(Screen.height/2),20,80), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darDerecha();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			flecha = true;
			print ("Derecha");
		}
		
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de atrás
		if(GUI.Button(new Rect((Screen.width/2)-40,520,80,20), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darAtras();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			flecha = true;
			print ("Atras");
		}
	}
}
