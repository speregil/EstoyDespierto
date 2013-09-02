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
		Debug.Log("Admin Start: " + Time.time);
		textos = (TextoDisplay)GetComponent(typeof(TextoDisplay));
		Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		movimiento = (MovimientoDisplay)Global.GetComponent(typeof(MovimientoDisplay));
		movimiento.EstablecerCamara(GameObject.Find("Main Camera"));
		movimiento.activar();
		movimiento.cambiarGrafo(EstadosNivel.PRINCIPAL);
		NodoGrafo ultimo = globales.darUltimoEstado();
		movimiento.irAEstado(ultimo);
		if(VariablesGlobales.primeraVez){
			textos.empezarTexto(TextosNivel.TEXTO_PRUEBA);
		}
	}
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		if(comando.Equals("prueba")){
			textos.empezarTexto(TextosNivel.TEXTO_INTERACTOR);
		}
		if(comando.Equals("PuertaGemelas")){
			NodoGrafo actual = movimiento.darEstadoActual();
			globales.establecerUltimoEstado(actual.darIzquierda());
			movimiento.desactivar();
			Application.LoadLevel("CuartoGemelas");
		}
	}
	
	public void EventDialog(int resultado){
		
	}
}