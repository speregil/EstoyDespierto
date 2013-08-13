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
		GrafoPrincipal = new Grafo(2);
		
		NodoGrafo estado0 = new NodoGrafo(0,"",new Vector3(3,0,0));
		GrafoPrincipal.agregarEstado(estado0);
		
		NodoGrafo estado1 = new NodoGrafo(1,"",new Vector3(0,1,5));
		GrafoPrincipal.agregarEstado(estado1);
		
		GrafoPrincipal.asignarDelantero(estado0.darEstado(), estado1.darEstado());
	}
}

