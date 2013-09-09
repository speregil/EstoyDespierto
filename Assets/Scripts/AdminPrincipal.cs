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
		
		//Cambia al grafo respectivo y se mueve al estado apropiado
		movimiento.cambiarGrafo(EstadosNivel.PRINCIPAL);
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
	}
}