using UnityEngine;
using System.Collections;

public class EstadosNivel
{
	//-----------------------------------------------------------
	// Atributos
	//-----------------------------------------------------------
	
	private Grafo GrafoActual;
	private Grafo GrafoPrincipal;
	private Grafo GrafoGemelas;
	public NodoGrafo estadoActual;
	
	public const int PRINCIPAL = 0;
	public const int GEMELAS = 1;
	
	//-----------------------------------------------------------
	// Constructor
	//-----------------------------------------------------------
	
	public EstadosNivel(){
		inicializarGrafoPrincipal();
		inicializarGrafoGemelas();
		/*GrafoActual = GrafoPrincipal;
		estadoActual = GrafoActual.darEstadoActual();*/
	}
	
	//-----------------------------------------------------------
	// Metodos Auxiliares
	//-----------------------------------------------------------
	
	public NodoGrafo darEstadoActual(){
		Debug.Log("El estado actual es: " + estadoActual);
		return estadoActual;	
	}
	
	public void cambiarEstadoActual(NodoGrafo nuevoEstado){
		GrafoActual.cambiarEstado(nuevoEstado);
		estadoActual = GrafoActual.darEstadoActual();
	}
	
	public void cambiarGrafoActual(int idGrafo){
		switch(idGrafo){
			case(PRINCIPAL)	:
				GrafoActual = GrafoPrincipal;
				estadoActual = GrafoActual.darEstadoActual();
			Debug.Log("Grafo: " + GrafoActual + " Estado Actual: " + estadoActual);
			break;
			
			case(GEMELAS) :
				GrafoActual = GrafoGemelas;
				estadoActual = GrafoActual.darEstadoActual();
			break;
		}
	}
	
	//--------------------------------------------------------------
	// Grafo Principal
	//--------------------------------------------------------------
	
	public void inicializarGrafoPrincipal(){
		GrafoPrincipal = new Grafo(100);
		
		NodoGrafo estado0 = new NodoGrafo(0,"",new Vector3(3,0,0),0.0f);
		GrafoPrincipal.agregarEstado(estado0);
		
		NodoGrafo estado1 = new NodoGrafo(1,"",new Vector3(0,0,5),0.0f);
		GrafoPrincipal.agregarEstado(estado1);
		
		NodoGrafo estado2 = new NodoGrafo(2,"",new Vector3(0,0,5),-90.0f);
		GrafoPrincipal.agregarEstado(estado2);
		
		NodoGrafo estado3 = new NodoGrafo(3,"",new Vector3(0,0,13),0.0f);
		GrafoPrincipal.agregarEstado(estado3);
		
		NodoGrafo estado4 = new NodoGrafo(4,"",new Vector3(0,0,13),-90.0f);
		GrafoPrincipal.agregarEstado(estado4);
		
		NodoGrafo estado5 = new NodoGrafo(5,"",new Vector3(0,0,13),90.0f);
		GrafoPrincipal.agregarEstado(estado5);
		
		NodoGrafo estado6 = new NodoGrafo(6,"",new Vector3(0,0,25),0.0f);
		GrafoPrincipal.agregarEstado(estado6);
		
		NodoGrafo estado7 = new NodoGrafo(7,"",new Vector3(0,0,25),-90.0f);
		GrafoPrincipal.agregarEstado(estado7);
		
		NodoGrafo estado8 = new NodoGrafo(8,"",new Vector3(0,0,25),90.0f);
		GrafoPrincipal.agregarEstado(estado8);
		
		NodoGrafo estado9 = new NodoGrafo(9,"",new Vector3(0,0,34),0.0f);
		GrafoPrincipal.agregarEstado(estado9);
		
		NodoGrafo estado10 = new NodoGrafo(10,"",new Vector3(0,0,34),90.0f);
		GrafoPrincipal.agregarEstado(estado10);
		
		GrafoPrincipal.asignarDelantero(estado0.darEstado(), estado1.darEstado());
		GrafoPrincipal.asignarIzquierdo(estado1.darEstado(), estado2.darEstado());
		GrafoPrincipal.asignarDelantero(estado1.darEstado(), estado3.darEstado());
		GrafoPrincipal.asignarIzquierdo(estado3.darEstado(), estado4.darEstado());
		GrafoPrincipal.asignarDerecho(estado3.darEstado(), estado5.darEstado());
		GrafoPrincipal.asignarDelantero(estado3.darEstado(), estado6.darEstado());
		GrafoPrincipal.asignarIzquierdo(estado6.darEstado(), estado7.darEstado());
		GrafoPrincipal.asignarDerecho(estado6.darEstado(), estado8.darEstado());
		GrafoPrincipal.asignarDelantero(estado6.darEstado(), estado9.darEstado());
		GrafoPrincipal.asignarDerecho(estado9.darEstado(), estado10.darEstado());
	}
	
	//-------------------------------------------------------------------------------------
	// Grafo Habitación Gemelas
	//-------------------------------------------------------------------------------------
	
	public void inicializarGrafoGemelas(){
		GrafoGemelas = new Grafo(100);
		
		NodoGrafo estado0 = new NodoGrafo(0,"",new Vector3(5,0,-3),0.0f);
		GrafoGemelas.agregarEstado(estado0);
		
		NodoGrafo estado1 = new NodoGrafo(1,"",new Vector3(6,0,-1),0.0f);
		GrafoGemelas.agregarEstado(estado1);
		
		NodoGrafo estado2 = new NodoGrafo(2,"",new Vector3(6,0,1),0.0f);
		GrafoGemelas.agregarEstado(estado2);
		
		NodoGrafo estado3 = new NodoGrafo(3,"",new Vector3(6,0,-1),90.0f);
		GrafoGemelas.agregarEstado(estado3);
		
		NodoGrafo estado4 = new NodoGrafo(4,"",new Vector3(6,0,-1),-90.0f);
		GrafoGemelas.agregarEstado(estado4);
		
		NodoGrafo estado5 = new NodoGrafo(5,"",new Vector3(4,0,-2),-90.0f);
		GrafoGemelas.agregarEstado(estado5);
		
		NodoGrafo estado6 = new NodoGrafo(6,"",new Vector3(6,0,-1),-180.0f);
		GrafoGemelas.agregarEstado(estado6);
		
		GrafoGemelas.asignarDelantero(estado0.darEstado(), estado1.darEstado());
		GrafoGemelas.asignarIzquierdo(estado1.darEstado(), estado4.darEstado());
		GrafoGemelas.asignarDerecho(estado1.darEstado(), estado3.darEstado());
		GrafoGemelas.asignarDelantero(estado4.darEstado(), estado5.darEstado());
		GrafoGemelas.asignarDelantero(estado1.darEstado(), estado2.darEstado());
		GrafoGemelas.asignarIzquierdo(estado4.darEstado(), estado6.darEstado());
	}
}