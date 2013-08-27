using UnityEngine;
using System.Collections;

public class AdminPrincipal : MonoBehaviour {
	
	private GameObject Global;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	
	void Awake(){
		movimiento = (MovimientoDisplay)GetComponent(typeof(MovimientoDisplay));
	}
	
	void Start () {
		textos = (TextoDisplay)GetComponent(typeof(TextoDisplay));
		textos.empezarTexto(TextosNivel.TEXTO_PRUEBA);
		Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		movimiento.cambiarGrafo(EstadosNivel.PRINCIPAL);
		
	}
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		Debug.Log(comando+" AdminPrincipal");
		if(comando.Equals("prueba")){
			textos.empezarTexto(TextosNivel.TEXTO_INTERACTOR);
		}
		if(comando.Equals("PuertaGemelas")){
			NodoGrafo actual = movimiento.darEstadoActual();
			globales.establecerUltimoEstado(actual);
			Application.LoadLevel("CuartoGemelas");
		}
	}
	
	public void EventDialog(int resultado){
		
	}
}