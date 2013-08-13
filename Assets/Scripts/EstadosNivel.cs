using UnityEngine;
using System.Collections;

public class EstadosNivel : MonoBehaviour
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
		
		NodoGrafo estado0 = new NodoGrafo(0,"",new Vector3(3,0,0),0);
		GrafoPrincipal.agregarEstado(estado0);
		
		NodoGrafo estado1 = new NodoGrafo(1,"",new Vector3(0,0,5),0);
		GrafoPrincipal.agregarEstado(estado1);
		
		NodoGrafo estado2 = new NodoGrafo(2,"",new Vector3(1,0,5),-90.0f);
		GrafoPrincipal.agregarEstado(estado2);
		
		GrafoPrincipal.asignarDelantero(estado0.darEstado(), estado1.darEstado());
		GrafoPrincipal.asignarIzquierdo(estado1.darEstado(), estado2.darEstado());
	}
}

