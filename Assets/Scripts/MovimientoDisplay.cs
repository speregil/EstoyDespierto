using UnityEngine;
using System.Collections;

public class MovimientoDisplay : MonoBehaviour {
	
	//=================================================================
	// Atributos
	//=================================================================
	
	public Texture2D iconoFlecha;
	public float velocidad;
	
	private GameObject Camara;
	private bool flecha= false;
	private float anguloLerp = 0.0f;
	private Vector3 posicionDestino;
	private float anguloDestino = 0.0f;
	private VariablesGlobales globales;
	private EstadosNivel estados;
	private bool activo = false;
	//=================================================================================
	// Inicializacion
	//=================================================================================
	
	void Awake(){
		
	}
	
	void Start(){
		GameObject Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		estados = globales.darEstados();
		/*NodoGrafo n = estados.darEstadoActual();
		Camara.transform.position = n.darPosicion();*/	
	}
	
	//=================================================================================
	// Update
	//=================================================================================
	
	void Update ()
	{
		if(activo){
			Vector3 posicionActual = Camara.transform.position;
			if(flecha){
				anguloLerp = Mathf.LerpAngle(0.0f,anguloDestino,Time.time*0.2f);
				Camara.transform.eulerAngles = new Vector3(0.0f,anguloLerp,0.0f);
				Camara.transform.position = Vector3.MoveTowards(posicionActual,posicionDestino, Time.deltaTime*velocidad);
			}
		
			if(posicionActual.Equals(posicionDestino)){
				flecha = false;	
			}
		}
	}
	
	//==============================================================================================
	// OnGUI
	//==============================================================================================
	
	void OnGUI () {

		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de arriba
		if(GUI.Button(new Rect((Screen.width/2)-40,40,80,20), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darAdelante();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			print (posicionDestino);
			anguloDestino = estadoSig.darAngulo();
			flecha = true;
		}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la izquierda
		if(GUI.Button(new Rect(20,(Screen.height/2),20,80), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darIzquierda();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			anguloDestino = estadoSig.darAngulo();
			flecha = true;
		}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la derecha
		if(GUI.Button(new Rect((Screen.width-40),(Screen.height/2),20,80), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darDerecha();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			anguloDestino = estadoSig.darAngulo();
			flecha = true;
		}
		
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de atrás
		if(GUI.Button(new Rect((Screen.width/2)-40,520,80,20), iconoFlecha)) {
			NodoGrafo estadoActual = estados.darEstadoActual();
			NodoGrafo estadoSig = estadoActual.darAtras();
			estados.cambiarEstadoActual(estadoSig);
			posicionDestino = estadoSig.darPosicion();
			anguloDestino = estadoSig.darAngulo();
			flecha = true;
		}
	}
	
	//==============================================================================================
	// Metodos auxiliares
	//==============================================================================================
	
	public void cambiarGrafo(int id){
		estados.cambiarGrafoActual(id);
	}
	
	public NodoGrafo darEstadoActual(){
		
		return estados.darEstadoActual();	
	}
	
	public void irAEstado(NodoGrafo estado){
		print ("Por fuera del if");
		if(estado != null){
			print ("Ir a estado se lanzo");
			Camara.transform.position = estado.darPosicion();
			estados.cambiarEstadoActual(estado);
		}
	}
	
	public void EstablecerCamara(GameObject camara){
		Camara = camara;	
	}
	
	public void activar(){
		activo = true;	
	}
	
	public void desactivar(){
		activo = false;	
	}
}