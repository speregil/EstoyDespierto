using UnityEngine;
using System.Collections;

public class TextoDisplay : MonoBehaviour {

//=================================================================================
// Atributos
//=================================================================================

	public GUISkin skin;
	public TextosNivel mapaTextos;
	public bool puedoActivarMov = true;
	
	private Rect ventana;
	private NodoTexto textoActual;
	private bool dialogosActivos = false;
	private bool ventanaActiva = false;
	private bool enOpcion = false;
	private string textoOpcion1;
	private string textoOpcion2;
	private string textoActivo;
	private IEventos admin;
	private GUIStyle stilo;
	private MovimientoDisplay movimiento;
	
//=================================================================================
// Start
//=================================================================================

	void Awake(){
		ventana = new Rect(Screen.width/4,(Screen.height/4), Screen.width/2 + 20,(Screen.height/2));
		mapaTextos = new TextosNivel();
	}
	
	void Start(){
		admin = (IEventos)GameObject.Find("Nivel").GetComponent(typeof(IEventos));
		stilo = new GUIStyle();
		stilo.font = skin.font;
		movimiento = (MovimientoDisplay)GetComponent(typeof(MovimientoDisplay));
	}

// ================================================================================
// OnGui
// ================================================================================

	void OnGUI () {
		GUI.skin = skin;
		if(dialogosActivos && textoActual != null && !textoActivo.Equals("")){
			ventana = GUI.Window(0,ventana , WindowFunction,"");
			ventanaActiva = true;
			movimiento.desactivar();
		}
		else{
			ventanaActiva = false;
			//if(puedoActivarMov)
			//		movimiento.activar();
		}
	}

	void WindowFunction (int windowID) {

		if(enOpcion){
			if(GUI.Button(new Rect (10, 20, ventana.width, 75), textoOpcion1)){
				print("Escogio Opcion 1:");
				textoActual = textoActual.getHijo1();
				dibujarDialogo();
				enOpcion = false;
				textoOpcion1 = "";
				textoOpcion2 = "";
			}
			
			if(GUI.Button(new Rect (10, 95, ventana.width, 75), textoOpcion2)){
				print("Escogio Opcion 2:");
				textoActual = textoActual.getHijo2();
				dibujarDialogo();
				enOpcion = false;
				textoOpcion1 = "";
				textoOpcion2 = "";
			}
		}
		else{
			GUI.Label (new Rect (10, 30, ventana.width - 20, ventana.height - 30), textoActivo, stilo);
		}
	}


// ================================================================================
// OnMouseDown
// ================================================================================
	void Update(){

		if(ventanaActiva && Input.GetKeyDown(KeyCode.Mouse0) && !enOpcion){

			if(!textoActual.estaTerminado()){
				dibujarDialogo();
			}
			else if(textoActual.estaTerminado()&&textoActual.tieneHijos()){
				enOpcion = true;
				dibujarOpcion();
			}
			else if(textoActual.estaTerminado() && !textoActual.tieneHijos()){
				dialogosActivos = false;
				textoActivo = "";
				textoActual.reiniciar();
				if(puedoActivarMov)
					movimiento.activar();
				admin.DialogSwitch(textoActual.getResultado());
			}
		}
	}

//==================================================================================
// Metodos
//==================================================================================

	public void empezarTexto(int IDnuevo){
		textoActual = mapaTextos.darTexto(IDnuevo);
		dibujarDialogo();
	}
	
	private void dibujarDialogo(){
		textoActivo = textoActual.getTextoLinea();
		dialogosActivos = true;
	}

	private void dibujarOpcion(){
		textoOpcion1 = textoActual.getHijo1().getTextoLinea();
		textoOpcion2 = textoActual.getHijo2().getTextoLinea();
		textoActivo = "";
	}
	
	public void PuedoActivarMov(bool param){
		puedoActivarMov = param;	
	}
}