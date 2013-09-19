using UnityEngine;
using System.Collections;

public class AdminCocina : MonoBehaviour {

	//Objetos
	private GameObject Global;
	private Parpado1 parpado1;
	private Parpado2 parpado2;
	private TextoDisplay textos;
	private MovimientoDisplay movimiento;
	private VariablesGlobales globales;
	private Minijuego2 mini;
	
	private GameObject libro;
	private GameObject servilleta;
	private GameObject botella;
	private GameObject sopa;
	//Flags particulares
	private bool introJoven = false;
	private bool olla = false;
	private bool iniciarMinijuego = false;
	private bool terminarMinijuego = false;
	private bool aprobacion = false;
	private int contMesa = 0;
	
	//=================================================================================================
	// inicializacion
	//=================================================================================================
	
	void Awake(){
		
	}
	
	void Start () {
		//Inicializa las relaciones con los scripts de control
		mini = (Minijuego2)GetComponent(typeof(Minijuego2));
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
		movimiento.cambiarGrafo(EstadosNivel.COCINA);
		movimiento.irAEstado(movimiento.darEstadoActual());
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
		
		//Administracion de objetos particulares a este nivel
		libro = GameObject.Find("Libro");
		libro.renderer.enabled = false;
		libro.collider.enabled = false;
		
		servilleta = GameObject.Find("Servilleta");
		servilleta.renderer.enabled = false;
		servilleta.collider.enabled = false;
		
		botella = GameObject.Find("Botella");
		botella.renderer.enabled = false;
		botella.collider.enabled = false;
		
		sopa = GameObject.Find("Sopa");
		sopa.renderer.enabled = false;
		sopa.collider.enabled = false;
		//Modifica variables globales
		parpado1.Abrir();
		parpado2.Abrir();
		VariablesGlobales.primeraVez = false;
		textos.empezarTexto(TextosNivel.TEXTO_COCINA_INTRO);
	}
	
	// ============================================================================================
	// Eventos
	//=============================================================================================
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		if(comando.Equals("Joven")){
			if(!introJoven){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_JOVEN_INTRO);
				introJoven = true;
			}
			else if(olla){
				if(terminarMinijuego){
					textos.empezarTexto(TextosNivel.TEXTO_COCINA_JOVEN_FIN);
					sopa.renderer.enabled = true;
					sopa.collider.enabled = true;
				}
				else{
					textos.empezarTexto(TextosNivel.TEXTO_COCINA_JOVEN_SOPA);
				}
			}
		}
		
		else if(comando.Equals("Olla")){
			if(introJoven){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_OLLA_SI_INTRO);
				olla = true;
				libro.renderer.enabled = true;
				libro.collider.enabled = true;
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_OLLA_NO_INTRO);
			}
		}
		
		else if(comando.Equals("Libro")){
			textos.empezarTexto(TextosNivel.TEXTO_COCINA_LIBRO);
			Interactor i = (Interactor)libro.GetComponent(typeof(Interactor));
			i.apagar();
		}
		
		else if(comando.Equals("Lavadora")){
			if(introJoven){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_LAVADORA_SI_INTRO);
				olla = true;
				servilleta.renderer.enabled = true;
				servilleta.collider.enabled = true;
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_LAVADORA_NO_INTRO);
			}
		}
		
		else if(comando.Equals("Servilleta")){
			textos.empezarTexto(TextosNivel.TEXTO_COCINA_SERVILLETA);
			Interactor i = (Interactor)libro.GetComponent(typeof(Interactor));
			i.apagar();
		}
		
		else if(comando.Equals("Locker")){
			if(introJoven){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_LOCKER_SI_INTRO);
				olla = true;
				botella.renderer.enabled = true;
				botella.collider.enabled = true;
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_LOCKER_NO_INTRO);
			}
		}
		
		else if(comando.Equals("Botella")){
			textos.empezarTexto(TextosNivel.TEXTO_COCINA_BOTELLA);
			Interactor i = (Interactor)libro.GetComponent(typeof(Interactor));
			i.apagar();
		}
		
		else if(comando.Equals("Nevera")){
			if(iniciarMinijuego){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_MINIJUEGO);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_NEVERA);	
			}
		}
		
		else if(comando.Equals("Sopa")){
			aprobacion = true;
			if(VariablesGlobales.extrovertido){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_SOPA_EXTRO);
			}
			else if(VariablesGlobales.introvertido){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_SOPA_INTROV);	
			}
		}
		
		else if(comando.Equals("Puerta")){
			if(aprobacion){
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_PUERTA_FIN);
			}
			else{
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_PUERTA_NO_FIN);	
			}
		}
	}
	
	public void EventDialog(int resultado){
		if(resultado == TextosNivel.RESULTADO_MESA){
			contMesa++;
			if(contMesa >= 3){
				iniciarMinijuego = true;
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_JOVEN_MINIJUEGO);
			}
		}
		
		else if(resultado == TextosNivel.RESULTADO_MINIJUEGO){
			Interactor i = (Interactor)GameObject.Find("Refrigerator").GetComponent(typeof(Interactor));
			i.apagar();
			terminarMinijuego = true;
			mini.activar();
		}
		
		else if(resultado == TextosNivel.RESULTADO_FIN){
			movimiento.desactivar();
			Application.LoadLevel("Principal");
		}
		
	}
	
	public void EventEstado (string comando){
		
		if(comando.Equals("Centro")){
			if(!introJoven)
				textos.empezarTexto(TextosNivel.TEXTO_COCINA_CENTRO);	
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
