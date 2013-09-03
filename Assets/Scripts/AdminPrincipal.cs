using UnityEngine;
using System.Collections;

public class AdminPrincipal : MonoBehaviour {
	
	private GameObject Global;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	
	void Awake(){
		
	}
	
	void Start () {
		Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		movimiento = (MovimientoDisplay)Global.GetComponent(typeof(MovimientoDisplay));
		movimiento.EstablecerCamara(GameObject.Find("Main Camera"));
		movimiento.activar();
		movimiento.cambiarGrafo(EstadosNivel.PRINCIPAL);
		NodoGrafo ultimo = globales.darUltimoEstado();
		movimiento.irAEstado(ultimo);
		textos = (TextoDisplay)Global.GetComponent(typeof(TextoDisplay));
		if(VariablesGlobales.primeraVez){
			textos.empezarTexto(TextosNivel.TEXTO_INTRO_CAMA);
		}
	}
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		if(comando.Equals("prueba")){
		
		}
		if(comando.Equals("PuertaGemelas")){
			NodoGrafo actual = movimiento.darEstadoActual();
			globales.establecerUltimoEstado(actual.darIzquierda());
			movimiento.desactivar();
			Application.LoadLevel("CuartoGemelas");
		}
	}
	
	public void EventDialog(int resultado){
		
		if(resultado == TextosNivel.RESULTADO_INTRO){
			// TODO: Efecto de abrir los ojos
			Debug.Log("Entre al resultado");
			textos.empezarTexto(TextosNivel.TEXTO_INTRO_VER_GEMELAS);
		}
	}
}