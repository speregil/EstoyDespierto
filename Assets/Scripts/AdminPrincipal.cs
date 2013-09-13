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
	private bool corredor1 = false;
	private bool corredor2 = false;
	private bool espejo = false;
	private bool verReja = true;
	private bool volver = false;
	
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
		textos.PuedoActivarMov(false);
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
		
		// Ejecuta las acciones correspondietes a los flags de control
		if(VariablesGlobales.primeraVez){
			textos.empezarTexto(TextosNivel.TEXTO_INTRO_CAMA);
		}
		else{
			parpado1.Abrir();
			parpado2.Abrir();
			movimiento.activar();
		}
	}
	
	// ============================================================================================
	// Eventos
	//=============================================================================================
	
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
		
		// Niño en la puerta
		else if(comando.Equals("Nino")){
			textos.empezarTexto(TextosNivel.TEXTO_PUERTA_NINO);
			verNiño = true;
		}
		// Mueble en el cuarto
		else if(comando.Equals("MuebleH1")){
			if(verNiño){
				textos.empezarTexto(TextosNivel.TEXTO_MUEBLE_CUARTO_SI_NINO);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_MUEBLE_CUARTO_NO_NINO);
			}
		}
		
		//Puerta a la habitacion de las gemelas
		else if(comando.Equals("PuertaGemelas")){
			if(volver){
				textos.empezarTexto(TextosNivel.TEXTO_PUERTA_GEMELAS);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PUERTA);	
			}
		}
		
		else if(comando.Equals("PuertaGaraje")){
			if(volver){
				NodoGrafo actual = movimiento.darEstadoActual();
				globales.establecerUltimoEstado(actual.darIzquierda());
				movimiento.desactivar();
				Application.LoadLevel("Garaje");
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PUERTA);	
			}
		}
		
		else if(comando.Equals("PuertaCocina")){
			if(volver){
				NodoGrafo actual = movimiento.darEstadoActual();
				globales.establecerUltimoEstado(actual.darIzquierda());
				movimiento.desactivar();
				Application.LoadLevel("Cocina");
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_CORREDOR_PUERTA);	
			}
		}
		
		else if(comando.Equals("PuertaStar")){
			if(volver){
				NodoGrafo actual = movimiento.darEstadoActual();
				globales.establecerUltimoEstado(actual.darIzquierda());
				movimiento.desactivar();
				Application.LoadLevel("Star");
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
			textos.empezarTexto(TextosNivel.TEXTO_ESPEJO);
		}
		
		else if(comando.Equals("Reja")){
			textos.empezarTexto(TextosNivel.TEXTO_REJA);
			verReja = true;
			corredor1 = false;
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
	}
	
	public void EventEstado (string comando){
		
		if(comando.Equals("Puerta")){
			if(!verNiño)
				movimiento.NoHayAdelante();
		}
		
		else if(comando.Equals("Corredor1")){
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