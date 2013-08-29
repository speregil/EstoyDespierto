using UnityEngine;
using System.Collections;

public class Grafo
{
	//--------------------------------------------------------------------
	// Atributos
	//--------------------------------------------------------------------
	
	int estadoActual;
	public NodoGrafo[]  grafo;
	
	//--------------------------------------------------------------------
	// Constructor
	//--------------------------------------------------------------------
	
	public Grafo(int numNodos){
		grafo = new NodoGrafo[numNodos];
		estadoActual = 0;
	}
	
	//--------------------------------------------------------------------
	// Metodos
	//--------------------------------------------------------------------
	
	public NodoGrafo darEstadoActual(){
		return grafo[estadoActual];	
	}
	/**
	 * Agrega un estado sin sucesores
	 * */
	public void agregarEstado(NodoGrafo nodo)
	{
		int nuevoEstado = nodo.darEstado();
		if(grafo[nuevoEstado] == null){
			grafo[nuevoEstado] = nodo;	
		}
		else{
			Debug.Log ("El nodo intentar entrar a un estado ya ocupado. Nodo # " + nuevoEstado);	
		}
	}
	/**
	 * Asigna un sucesor a la derecha
	 * */
	public void asignarDerecho(int estadoOrigen, int estadoDestino)
	{
		grafo[estadoOrigen].asignarDerecho(grafo[estadoDestino]);
		grafo[estadoDestino].asignarIzquierdo(grafo[estadoOrigen]);
	}
	/**
	 * Asigna un sucesor a la izquierda
	 * */
	public void asignarIzquierdo(int estadoOrigen, int estadoDestino)
	{
		grafo[estadoOrigen].asignarIzquierdo(grafo[estadoDestino]);
		grafo[estadoDestino].asignarDerecho(grafo[estadoOrigen]);
	}
	/**
	 * Asigna un sucesor a la delantera
	 * */
	public void asignarDelantero(int estadoOrigen, int estadoDestino)
	{
		grafo[estadoOrigen].asignarDelantero(grafo[estadoDestino]);
		grafo[estadoDestino].asignarAnterior(grafo[estadoOrigen]);
	}
	
	public void cambiarEstado(NodoGrafo nuevoEstado){
		estadoActual = nuevoEstado.darEstado();	
	}
}

