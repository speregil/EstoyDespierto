using UnityEngine;
using System.Collections;

public class MovimientoDisplay : MonoBehaviour {
	
	//=================================================================
	// Atributos
	//=================================================================
	
	public Texture2D iconoFlecha;
	public float velocidad;
	
	public GUISkin skin;
	private GameObject admin;
	private IEventos eventos;
	private GameObject Camara;
	private bool flecha= false;
	private float anguloLerp = 0.0f;
	private Vector3 posicionDestino;
	private float anguloDestino = 0.0f;
	private VariablesGlobales globales;
	private EstadosNivel estados;
	private bool enMovimiento = false;
	
	private bool puedeMoverse = false;
	private bool hayAdelante = false;
	private bool hayDetras = false;
	private bool hayIzquierda = false;
	private bool hayDerecha = false;
	//=================================================================================
	// Inicializacion
	//=================================================================================
	
	void Awake(){
		globales = (VariablesGlobales)GetComponent(typeof(VariablesGlobales));
		estados = globales.darEstados();
	}
	
	void Start(){
		admin = GameObject.Find("Nivel");
		eventos = (IEventos)admin.GetComponent(typeof(IEventos));
	}
	
	//=================================================================================
	// Update
	//=================================================================================
	
	void Update ()
	{
		if(enMovimiento){
			Vector3 posicionActual = Camara.transform.position;
			if(flecha){
				anguloLerp = Mathf.LerpAngle(0.0f,anguloDestino,Time.time*0.2f);
				Camara.transform.eulerAngles = new Vector3(0.0f,anguloLerp,0.0f);
				Camara.transform.position = Vector3.MoveTowards(posicionActual,posicionDestino, Time.deltaTime*velocidad);
			}
		
			if(posicionActual.Equals(posicionDestino)){
				flecha = false;
				activar();
				if(estados.darEstadoActual().TieneDialogo()){
					if(eventos != null){
						eventos.EstadoTrigger(estados.darEstadoActual().darDialogo());
					}
				}
			}
		}
	}
	
	//==============================================================================================
	// OnGUI
	//==============================================================================================
	
	void OnGUI () {
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de arriba
		GUI.skin = skin;
		if(puedeMoverse){
			if(hayAdelante){
				if(GUI.Button(new Rect((Screen.width/2)-40,40,80,20), iconoFlecha)) {
					NodoGrafo estadoActual = estados.darEstadoActual();
					NodoGrafo estadoSig = estadoActual.darAdelante();
					estados.cambiarEstadoActual(estadoSig);
					posicionDestino = estadoSig.darPosicion();
					desactivar();
					hayAdelante = estadoSig.TieneAdelante();
					hayDetras = estadoSig.TieneDetras();
					hayIzquierda = estadoSig.TieneIzquierda();
					hayDerecha = estadoSig.TieneDerecha();
					anguloDestino = estadoSig.darAngulo();
					flecha = true;
					enMovimiento = true;
					//Debug.Log("Ad: " + hayAdelante + " Atr: " + hayDetras + " Izq: " + hayIzquierda + " Der: " + hayDerecha);
				}
			}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la izquierda
			if(hayIzquierda){
				if(GUI.Button(new Rect(20,(Screen.height/2),20,80), iconoFlecha)) {
					NodoGrafo estadoActual = estados.darEstadoActual();
					NodoGrafo estadoSig = estadoActual.darIzquierda();
					estados.cambiarEstadoActual(estadoSig);
					posicionDestino = estadoSig.darPosicion();
					anguloDestino = estadoSig.darAngulo();
					desactivar();
					hayAdelante = estadoSig.TieneAdelante();
					hayDetras = estadoSig.TieneDetras();
					hayIzquierda = estadoSig.TieneIzquierda();
					hayDerecha = estadoSig.TieneDerecha();
					anguloDestino = estadoSig.darAngulo();
					flecha = true;
					enMovimiento = true;
				}
			}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la derecha
			if(hayDerecha){
				if(GUI.Button(new Rect((Screen.width-40),(Screen.height/2),20,80), iconoFlecha)) {
					NodoGrafo estadoActual = estados.darEstadoActual();
					NodoGrafo estadoSig = estadoActual.darDerecha();
					estados.cambiarEstadoActual(estadoSig);
					posicionDestino = estadoSig.darPosicion();
					anguloDestino = estadoSig.darAngulo();
					desactivar();
					hayAdelante = estadoSig.TieneAdelante();
					hayDetras = estadoSig.TieneDetras();
					hayIzquierda = estadoSig.TieneIzquierda();
					hayDerecha = estadoSig.TieneDerecha();
					anguloDestino = estadoSig.darAngulo();
					flecha = true;
					enMovimiento = true;
				}
			}
		
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de atrás
			if(hayDetras){
				if(GUI.Button(new Rect((Screen.width/2)-40,520,80,20), iconoFlecha)) {
					NodoGrafo estadoActual = estados.darEstadoActual();
					NodoGrafo estadoSig = estadoActual.darAtras();
					estados.cambiarEstadoActual(estadoSig);
					posicionDestino = estadoSig.darPosicion();
					anguloDestino = estadoSig.darAngulo();
					desactivar();
					hayAdelante = estadoSig.TieneAdelante();
					hayDetras = estadoSig.TieneDetras();
					hayIzquierda = estadoSig.TieneIzquierda();
					hayDerecha = estadoSig.TieneDerecha();
					anguloDestino = estadoSig.darAngulo();
					flecha = true;
					enMovimiento = true;
				}
			}
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
		if(estado != null){
			Camara.transform.position = estado.darPosicion();
			estados.cambiarEstadoActual(estado);
		}
	}
	
	public void EstablecerCamara(GameObject camara){
		Camara = camara;	
	}
	
	public void activar(){
		puedeMoverse = true;
		enMovimiento = false;
	}
	
	public void desactivar(){
		puedeMoverse = false;	
	}
	
	public void SiHayAdelante(){
		hayAdelante = true;	
	}
	
	public void SiHayDetras(){
		hayDetras = true;	
	}
	
	public void SiHayDerecha(){
		hayDerecha = true;	
	}
	
	public void SiHayIzquierda(){
		hayIzquierda = true;	
	}
	
	public void NoHayAdelante(){
		hayAdelante = false;	
	}
	
	public void NoHayDetras(){
		hayDetras = false;	
	}
	
	public void NoHayDerecha(){
		hayDerecha = false;	
	}
	
	public void NoHayIzquierda(){
		hayIzquierda = false;	
	}
	
	public void reiniciarFlechas(){
		hayAdelante = false;
		hayDerecha = false;
		hayDetras = false;
		hayIzquierda = false;
	}
	
	public void cambiarAdmin(){
		admin = GameObject.Find("Nivel");
		eventos = (IEventos)admin.GetComponent(typeof(IEventos));
	}
}