using UnityEngine;
using System.Collections;

public class Grafo : MonoBehaviour
{
	int estadoActual;
	public NodoGrafo[]  grafo = new NodoGrafo[100];
	// Use this for initialization
	void Start ()
	{
		estadoActual = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	/**
	 * Agrega un estado sin sucesores
	 * */
	void agregarEstado(NodoGrafo nodo)
	{
		grafo[estadoActual] = nodo;
		nodo.asignarEstado(estadoActual);
		estadoActual++;
	}
	/**
	 * Asigna un sucesor a la derecha
	 * */
	void asignarDerecho(int estadoOrigen, int estadoDestino)
	{
		grafo[estadoOrigen].asignarDerecho(grafo[estadoDestino]);
		grafo[estadoDestino].asignarIzquierdo(grafo[estadoOrigen]);
	}
	/**
	 * Asigna un sucesor a la izquierda
	 * */
	void asignarIzquierdo(int estadoOrigen, int estadoDestino)
	{
		grafo[estadoOrigen].asignarIzquierdo(grafo[estadoDestino]);
		grafo[estadoDestino].asignarDerecho(grafo[estadoOrigen]);
	}
	/**
	 * Asigna un sucesor a la delantera
	 * */
	void asignarDelantero(int estadoOrigen, int estadoDestino)
	{
		grafo[estadoOrigen].asignarDelantero(grafo[estadoDestino]);
		grafo[estadoDestino].asignarAnterior(grafo[estadoOrigen]);
	}
}

