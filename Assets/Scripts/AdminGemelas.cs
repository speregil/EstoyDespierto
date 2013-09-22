using UnityEngine;
using System.Collections;

public class AdminGemelas : MonoBehaviour {

	private GameObject Global;
	private TextoDisplay textos;
	private Parpado1 parpado1;
	private Parpado2 parpado2;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	private Minijuego1 mini1;
	
	// Flags de control
	private bool puerta = false;
	private bool minijuego = false;
	private bool aprobacion = false;
	private bool hablarGemelas = false;
	
	void Awake(){
		
	}
	
	void Start () {
		
		//Inicializa las relaciones con los scripts de control
		Global = GameObject.Find("Global");
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		parpado1 = (Parpado1)GameObject.Find("Parpado1").GetComponent(typeof(Parpado1));
		parpado2 = (Parpado2)GameObject.Find("Parpado2").GetComponent(typeof(Parpado2));
		movimiento = (MovimientoDisplay)Global.GetComponent(typeof(MovimientoDisplay));
		movimiento.EstablecerCamara(GameObject.Find("Main Camera"));
		movimiento.activar();
		textos = (TextoDisplay)Global.GetComponent(typeof(TextoDisplay));
		textos.cambiarAdmin();
		//Cambia al grafo respectivo y se mueve al estado apropiado
		movimiento.cambiarGrafo(EstadosNivel.GEMELAS);
		movimiento.cambiarAdmin();
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
		movimiento.irAEstado(movimiento.darEstadoActual());
		//Modifica variables globales
		VariablesGlobales.primeraVez = false;
		parpado1.Abrir();
		parpado2.Abrir();
		
		if(!puerta){
			textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_INTR0);
			puerta = true;
		}
		if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork){
		    GoogleAnalyticsHelper.Settings("UA-44248318-1", "http://juegalibre.virtual.uniandes.edu.co");
			GoogleAnalyticsHelper.LogEvent("Gemelas", "Inicio", "Entro donde las gemelas", "", 0);
		}
	}
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		if(comando.Equals("Puerta")){
			
			if(!minijuego){
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_PUERTA_SIN_JUEGO);	
			}
			else{
				if(aprobacion){
					textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_PUERTA_CON_APROBACION);
				}
				else{
					textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_PUERTA_SIN_APROBACION);	
				}
			}
		}
		if(comando.Equals("Armario")){
			if(hablarGemelas){
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_REINA);
				minijuego = true;
			}
			else
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_SIN_REINA);
		}
		if(comando.Equals("Tapete")){
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_SIN_BUFON);
		}
		
		if(comando.Equals("Derecha")){
			if(VariablesGlobales.racional){	
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_GANO_DERECHA);
				aprobacion = true;
			}
			else
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_DERECHA);
		}
		if(comando.Equals("Izquierda")){
			if(VariablesGlobales.artistico){	
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_GANO_IZQUIERDA);
				aprobacion = true;
			}
			else
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_IZQUIERDA);
		}
	}
	
	public void EventDialog(int resultado){
		if(resultado == TextosNivel.RESULTADO_APROPACION){
			movimiento.desactivar();
			Application.LoadLevel("Principal");
		}
		
		else if(resultado == TextosNivel.RESULTADO_INICIO_JUEGO1){
			mini1 = (Minijuego1)GetComponent(typeof(Minijuego1));
			mini1.activar();
		}
	}
	
	public void EventEstado (string comando){
		if(comando.Equals("Gemelas")){
			if(!hablarGemelas){
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_INTRO_FRENTE);
				hablarGemelas = true;	
			}
		}
		
		if(comando.Equals("Prueba")){
			if(VariablesGlobales.racional){
				GameObject.Destroy(GameObject.Find("GemelaIzq"));	
			}
			else if(VariablesGlobales.artistico){
				GameObject.Destroy(GameObject.Find("GemelaDer"));	
			}
		}
	}
	
	//================================================================================================
	// Corutinas auxiliares
	//================================================================================================
	
	private IEnumerator Parpadear(){
		parpado1.Cerrar();
		parpado2.Cerrar();
		yield return new WaitForSeconds(2);
		parpado1.Abrir();
		parpado2.Abrir();
	}
}