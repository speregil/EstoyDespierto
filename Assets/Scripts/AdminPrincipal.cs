using UnityEngine;
using System.Collections;

public class AdminPrincipal : MonoBehaviour {
	
	//==================================================================================================
	// Atributos
	//==================================================================================================
	
	//Objetos
	private GameObject Global;
	private Parpado1 parpado1;
	private Parpado2 parpado2;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	
	//Flags particulares
	private bool gemelaIzq = false;
	private bool gemelaDer = false;
	private bool verNiño = false;
	
	void Awake(){
		
	}
	
	void Start () {
		Global = GameObject.Find("Global");
		parpado1 = (Parpado1)GameObject.Find("Parpado1").GetComponent(typeof(Parpado1));
		parpado2 = (Parpado2)GameObject.Find("Parpado2").GetComponent(typeof(Parpado2));
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
		
		// En la cama, hablar con la gemela derecha
		if(comando.Equals("CamaGemelaDer")){
			textos.empezarTexto(TextosNivel.TEXTO_CAMA_GEMELA_DERECHA);
			gemelaDer = true;
		}
		
		// En la cama, hablar con la gemela izquierda
		else if(comando.Equals("CamaGemelaIzq")){
			textos.empezarTexto(TextosNivel.TEXTO_CAMA_GEMELA_IZQUIERDA);
			gemelaIzq = true;
		}
		
		// Mueble en el cuarto
		else if(comando.Equals("MuebleH1")){
			Debug.Log("Mueble");
			if(verNiño){
				Debug.Log("Si niño");
				textos.empezarTexto(TextosNivel.TEXTO_MUEBLE_CUARTO_SI_NINO);
			}
			else{
				Debug.Log("No niño");
				textos.empezarTexto(TextosNivel.TEXTO_MUEBLE_CUARTO_NO_NINO);
			}
		}
		
		//Puerta a la habitacion de las gemelas
		else if(comando.Equals("PuertaGemelas")){
			NodoGrafo actual = movimiento.darEstadoActual();
			globales.establecerUltimoEstado(actual.darIzquierda());
			movimiento.desactivar();
			Application.LoadLevel("CuartoGemelas");
		}
		
	}
	
	public void EventDialog(int resultado){
		
		if(resultado == TextosNivel.RESULTADO_INTRO){
			// TO DO: Efecto de abrir los ojos
			parpado1.Abrir();
			parpado2.Abrir();
			textos.empezarTexto(TextosNivel.TEXTO_INTRO_VER_GEMELAS);
		}
		else if(resultado == TextosNivel.RESULTADO_CAMA_GEMELAS){
			if(gemelaDer && gemelaIzq){
				textos.empezarTexto(TextosNivel.TEXTO_CAMA_GEMELAS_SE_VAN);
			}
		}
	}
}