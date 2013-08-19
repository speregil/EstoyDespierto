using UnityEngine;
using System.Collections;

public class EstadosNivel
{
	//-----------------------------------------------------------
	// Atributos
	//-----------------------------------------------------------
	
	private Grafo GrafoPrincipal;
	public NodoGrafo estadoActual;
	
	//-----------------------------------------------------------
	// Constructor
	//-----------------------------------------------------------
	
	public EstadosNivel(){
		inicializarGrafoPrincipal();
		estadoActual = GrafoPrincipal.darEstadoActual();
	}
	
	//-----------------------------------------------------------
	// Metodos
	//-----------------------------------------------------------
	
	public NodoGrafo darEstadoActual(){
		return estadoActual;	
	}
	
	public void cambiarEstadoActual(NodoGrafo nuevoEstado){
		GrafoPrincipal.cambiarEstado(nuevoEstado);
		estadoActual = GrafoPrincipal.darEstadoActual(); 	
	}
	
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
}

