using UnityEngine;
using System.Collections;

public class AdminGemelas : MonoBehaviour {

	private GameObject Global;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	private Minijuego1 mini1;
	private Minijuego2 mini2;
	
	void Awake(){
		
	}
	
	void Start () {
		
		//Inicializa las relaciones con los scripts de control
		Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		movimiento = (MovimientoDisplay)Global.GetComponent(typeof(MovimientoDisplay));
		movimiento.EstablecerCamara(GameObject.Find("Main Camera"));
		movimiento.activar();
		textos = (TextoDisplay)Global.GetComponent(typeof(TextoDisplay));
		
		//Cambia al grafo respectivo y se mueve al estado apropiado
		movimiento.cambiarGrafo(EstadosNivel.GEMELAS);
		movimiento.reiniciarFlechas();
		NodoGrafo ultimo = movimiento.darEstadoActual();
		if(ultimo.TieneAdelante())
			movimiento.SiHayAdelante();
		if(ultimo.TieneDetras())
			movimiento.SiHayDetras();
		if(ultimo.TieneIzquierda())
			movimiento.SiHayIzquierda();
		if(ultimo.TieneDerecha())
			movimiento.SiHayDerecha();
		
		//Modifica variables globales
		VariablesGlobales.primeraVez = false;
	}
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		if(comando.Equals("Puerta")){
			print ("Ultimo estado: " + globales.darUltimoEstado());
			movimiento.desactivar();
			Application.LoadLevel("Principal");	
		}
		if(comando.Equals("MiniJuego1")){
			mini1 = (Minijuego1)GetComponent(typeof(Minijuego1));
			mini1.activar();
		}
		if(comando.Equals("MiniJuego2")){
			mini2 = (Minijuego2)GetComponent(typeof(Minijuego2));
			mini2.activar();
		}
	}
	
	public void EventDialog(int resultado){
		
	}
}
