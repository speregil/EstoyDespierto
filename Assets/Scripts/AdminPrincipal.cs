using UnityEngine;
using System.Collections;

public class AdminPrincipal : MonoBehaviour {
	
	//==================================================================================================
	// Atributos
	//==================================================================================================
	
	//Objetos
	public Texture2D texturaImagen;
	private GameObject Global;
	private Parpado1 parpado1;
	private Parpado2 parpado2;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	
	//Flags particulares
	private bool gemelaIzq = false;
	private bool gemelaDer = false;
	private bool verNino = false;
	private bool corredor1 = false;
	private bool corredor2 = false;
	private bool espejo = false;
	private bool verReja = false;
	private bool volver = false;
	private bool enFinal = false;
	private bool reflejo = false;
	private bool imagen = false;
	
	//=================================================================================================
	// inicializacion
	//=================================================================================================
	
	void Awake(){
		
	}
	
	void Start () {
		
		//Inicializa las relaciones con los scripts de control
		Global = GameObject.Find("Global");
		parpado1 = (Parpado1)GameObject.Find("Parpado1").GetComponent(typeof(Parpado1));
		parpado2 = (Parpado2)GameObject.Find("Parpado2").GetComponent(typeof(Parpado2));
		globales = (VariablesGlobales)Global.GetComponent(typeof(VariablesGlobales));
		movimiento = (MovimientoDisplay)Global.GetComponent(typeof(MovimientoDisplay));
		movimiento.EstablecerCamara(GameObject.Find("Main Camera"));
		textos = (TextoDisplay)Global.GetComponent(typeof(TextoDisplay));
		textos.cambiarAdmin();
		//Cambia al grafo respectivo y se mueve al estado apropiado
		movimiento.cambiarGrafo(EstadosNivel.PRINCIPAL);
		movimiento.cambiarAdmin();
		movimiento.reiniciarFlechas();
		NodoGrafo ultimo = globales.darUltimoEstado();
		movimiento.irAEstado(ultimo);
		movimiento.reiniciarFlechas();
		ultimo = movimiento.darEstadoActual();
		if(ultimo.TieneAdelante())
			movimiento.SiHayAdelante();
		if(ultimo.TieneDetras())
			movimiento.SiHayDetras();
		if(ultimo.TieneIzquierda())
			movimiento.SiHayIzquierda();
		if(ultimo.TieneDerecha())
			movimiento.SiHayDerecha();
		
		GameObject nino = GameObject.Find("NinoFinal");
		nino.renderer.enabled = false;
		nino.collider.enabled = false;
		// Ejecuta las acciones correspondietes a los flags de control
		if(VariablesGlobales.primeraVez){
			textos.empezarTexto(TextosNivel.TEXTO_INTRO_CAMA);
			textos.PuedoActivarMov(false);
		}
		else{
			parpado1.Abrir();
			parpado2.Abrir();
			movimiento.activar();
			
			corredor1 = true;
			corredor2 = true;
			espejo = true;
			verReja = true;
			volver = true;
			
			if((VariablesGlobales.racional || VariablesGlobales.artistico) && (VariablesGlobales.introvertido || VariablesGlobales.extrovertido)){
				enFinal = true;
				Destroy(GameObject.Find("Reja"));
				nino.renderer.enabled = true;
				nino.collider.enabled = true;
			}
		}
		if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork){
		    GoogleAnalyticsHelper.Settings("UA-44248318-1", "http://juegalibre.virtual.uniandes.edu.co");
			GoogleAnalyticsHelper.LogEvent("Pasillo", "Inicio", "Empezo a jugar", "", 0);
		}
	}
	
	// ============================================================================================
	// Eventos
	//=============================================================================================
	
	void OnGUI(){
		if(imagen){
			GUI.Box (new Rect (0,0, Screen.width, Screen.height),"");
			GUI.Label (new Rect (Screen.width/2 - (512/2),0, Screen.width, Screen.height), texturaImagen);
		}
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
		
		// Niño en la puerta
		else if(comando.Equals("Nino")){
			textos.empezarTexto(TextosNivel.TEXTO_PUERTA_NINO);
			verNino = true;
		}
		// Mueble en el cuarto
		else if(comando.Equals("MuebleH1")){
			if(verNino){
				textos.empezarTexto(TextosNivel.TEXTO_MUEBLE_CUARTO_SI_NINO);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_MUEBLE_CUARTO_NO_NINO);
			}
		}
		
		//Puerta a la habitacion de las gemelas
		else if(comando.Equals("PuertaGemelas")){
			
			if(VariablesGlobales.racional || VariablesGlobales.artistico){
				textos.empezarTexto(TextosNivel.TEXTO_GEMELAS_COMPLETO);	
			}
			else if(volver){
				textos.empezarTexto(TextosNivel.TEXTO_PUERTA_GEMELAS);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PUERTA);	
			}
		}
		
		else if(comando.Equals("PuertaGaraje")){
			if(volver){
				textos.empezarTexto(TextosNivel.TEXTO_NO_ALCANZAMOS);	
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PUERTA);	
			}
		}
		
		else if(comando.Equals("PuertaCocina")){
			
			if(VariablesGlobales.extrovertido || VariablesGlobales.introvertido){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_COMPLETO);	
			}
			else if(volver){
				textos.empezarTexto(TextosNivel.TEXTO_PUERTA_COCINA);	
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PUERTA);	
			}
		}
		
		else if(comando.Equals("PuertaStar")){
			if(volver){
				textos.empezarTexto(TextosNivel.TEXTO_NO_ALCANZAMOS);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PUERTA);	
			}
		}
		
		else if(comando.Equals("Alfombra")){
			textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_ALFOMBRA);
		}
		
		else if(comando.Equals("Pared")){
			textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PARED);
		}
		
		else if(comando.Equals("Lampara")){
			textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_LAMPARA);
		}
		
		else if(comando.Equals("Espejo")){
			if(enFinal){
				textos.empezarTexto(TextosNivel.TEXTO_FINAL_ESPEJO);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_ESPEJO);
			}
		}
		
		else if(comando.Equals("Reja")){
			textos.empezarTexto(TextosNivel.TEXTO_REJA);
			verReja = true;
			corredor1 = false;
		}
		
		else if(comando.Equals("NinoFinal")){
			if(reflejo){
				textos.empezarTexto(TextosNivel.TEXTO_FINAL_NINO_ESPEJO);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_FINAL_NINO_NO_ESPEJO);
			}
		}
	}
	
	public void EventDialog(int resultado){
		
		// Intro al juego
		if(resultado == TextosNivel.RESULTADO_INTRO){
			parpado1.Abrir();
			parpado2.Abrir();
			textos.empezarTexto(TextosNivel.TEXTO_INTRO_VER_GEMELAS);
		}
		// Hablar con las gemelas
		else if(resultado == TextosNivel.RESULTADO_CAMA_GEMELAS){
			if(gemelaDer && gemelaIzq){
				textos.empezarTexto(TextosNivel.TEXTO_CAMA_GEMELAS_SE_VAN);
				StartCoroutine(Parpadear());
				StartCoroutine(GemelasSeVan());
			}
		}
		
		// Solo en la cama
		else if(resultado == TextosNivel.RESULTADO_GEMELAS_SE_FUERON){
			textos.empezarTexto(TextosNivel.TEXTO_CAMA_NINO);
			textos.PuedoActivarMov(true);
		}
		
		// Despues de texto de solo en la cama
		else if(resultado == TextosNivel.RESULTADO_CAMA_SOLO){
			movimiento.activar();
		}
		
		//Solo en la puerta
		else if(resultado == TextosNivel.RESULTADO_NINO_SE_FUE){
			textos.empezarTexto(TextosNivel.TEXTO_PUERTA_SOLO);
			StartCoroutine(Parpadear());
			StartCoroutine(NinoSeVa());
		}
		
		// Ir al cuarto de las gemelas
		else if(resultado == TextosNivel.RESULTADO_PUERTA_GEMELAS){
			NodoGrafo actual = movimiento.darEstadoActual();
			globales.establecerUltimoEstado(actual.darIzquierda());
			movimiento.desactivar();
			Application.LoadLevel("CuartoGemelas");
		}
		
		// Ir a la cocina
		else if(resultado == TextosNivel.RESULTADO_PUERTA_COCINA){
			NodoGrafo actual = movimiento.darEstadoActual();
			globales.establecerUltimoEstado(actual.darDerecha());
			movimiento.desactivar();
			Application.LoadLevel("Cocina");
		}
		
		else if(resultado == TextosNivel.RESULTADO_ESPEJO_FINAL){
			StartCoroutine(EnEspejo());
		}
		
		else if(resultado == TextosNivel.RESULTADO_NINO_FINAL){
			if(VariablesGlobales.racional && VariablesGlobales.extrovertido){
				textos.empezarTexto(TextosNivel.TEXTO_FINAL_RACIONAL_EXTROVERTIDO);	
			}
			else if(VariablesGlobales.racional && VariablesGlobales.introvertido){
				textos.empezarTexto(TextosNivel.TEXTO_FINAL_RACIONAL_INTROVERTIDO);	
			}
			else if(VariablesGlobales.artistico && VariablesGlobales.introvertido){
				textos.empezarTexto(TextosNivel.TEXTO_FINAL_ARTISTICO_INTROVERTIDO);	
			}
			else if(VariablesGlobales.artistico && VariablesGlobales.extrovertido){
				textos.empezarTexto(TextosNivel.TEXTO_FINAL_ARTISTICO_EXTROVERTIDO);	
			}
		}
		
		else if(resultado == TextosNivel.RESULTADO_FINAL_JUEGO){
			parpado1.Cerrar();
			parpado2.Cerrar();
			textos.empezarTexto(TextosNivel.TEXTO_FINAL_DECISION);
		}
		
		else if(resultado == TextosNivel.RESULTADO_DESPERTAR){
			Application.LoadLevel("Menu");
		}
		
		else if(resultado == TextosNivel.RESULTADO_DORMIR){
			Application.LoadLevel("Menu");
		}
	}
	
	public void EventEstado (string comando){
		
		if(comando.Equals("Puerta")){
			if(!verNino)
				movimiento.NoHayAdelante();
		}
		
		else if(comando.Equals("Corredor1")){
			movimiento.darEstadoActual().eliminarAnterior();
			movimiento.NoHayDetras();
			if(!verReja){
				if(!corredor1){
					textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_1_NO_REJA);
					corredor1 = true;
				}
			}
			else{
				if(!corredor1){
					textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_1_SI_REJA);
					volver = true;
				}
			}
		}
		
		else if(comando.Equals("Corredor2")){
			if(!corredor2){
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_2_INTRO);
				corredor2 = true;
			}
		}
		
		else if(comando.Equals("Espejo")){
			if(!espejo){
				textos.empezarTexto(TextosNivel.TEXTO_FRENTE_ESPEJO);
				espejo = true;
			}
		}
	}
	
	//================================================================================================
	// Corutinas auxiliares
	//================================================================================================
	
	private IEnumerator EnEspejo(){
		imagen = true;
		yield return new WaitForSeconds(2);
		imagen = false;
		textos.empezarTexto(TextosNivel.TEXTO_FINAL_ESPEJO_2);
		reflejo = true;
	}
	
	private IEnumerator Parpadear(){
		parpado1.Cerrar();
		parpado2.Cerrar();
		yield return new WaitForSeconds(2);
		parpado1.Abrir();
		parpado2.Abrir();
	}
	
	private IEnumerator GemelasSeVan(){
		yield return new WaitForSeconds(1);
		Destroy(GameObject.Find("GemelaDer"));
		Destroy(GameObject.Find("GemelaIzq"));
	}
	
	private IEnumerator NinoSeVa(){
		yield return new WaitForSeconds(1);
		Destroy(GameObject.Find("Nino"));
		movimiento.SiHayAdelante();
	}
}