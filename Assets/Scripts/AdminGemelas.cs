using UnityEngine;
using System.Collections;

public class AdminGemelas : MonoBehaviour {

	private GameObject Global;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	
	void Awake(){
		movimiento = (MovimientoDisplay)GetComponent(typeof(MovimientoDisplay));
	}
	
	void Start () {
		textos = (TextoDisplay)GetComponent(typeof(TextoDisplay));
		Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		movimiento.cambiarGrafo(EstadosNivel.GEMELAS);
	}
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		if(comando.Equals("Puerta")){
			NodoGrafo actual = movimiento.darEstadoActual();
			globales.establecerUltimoEstado(actual);
			Application.LoadLevel("Principal");	
		}
	}
	
	public void EventDialog(int resultado){
		
	}
}
