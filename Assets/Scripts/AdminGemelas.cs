using UnityEngine;
using System.Collections;

public class AdminGemelas : MonoBehaviour {

	private GameObject Global;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	private Minijuego1 mini1;
	
	void Awake(){
		
	}
	
	void Start () {
		Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		movimiento = (MovimientoDisplay)Global.GetComponent(typeof(MovimientoDisplay));
		movimiento.EstablecerCamara(GameObject.Find("Main Camera"));
		movimiento.activar();
		movimiento.cambiarGrafo(EstadosNivel.GEMELAS);
		VariablesGlobales.primeraVez = false;
		textos = (TextoDisplay)Global.GetComponent(typeof(TextoDisplay));
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
	}
	
	public void EventDialog(int resultado){
		
	}
}
