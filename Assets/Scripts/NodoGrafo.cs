using UnityEngine;
using System.Collections;

public class NodoGrafo : MonoBehaviour
{
	//------------------------------------------------------------------------
	// Atributos
	//------------------------------------------------------------------------
	
	private NodoGrafo adelante;
	private NodoGrafo derecha;
	private NodoGrafo izquierda;
	private NodoGrafo atras;
	private string dialogo;
	private Vector3 posicion;
	private int estado;
	
	//------------------------------------------------------------------------
	// Constructor
	//------------------------------------------------------------------------
	
	public NodoGrafo(int nEstado, string nDialogo, Vector3 nPosicion){
		estado = nEstado;
		dialogo = nDialogo;
		posicion = nPosicion;
	}
	
	//-----------------------------------------------------------------------
	// Getters
	//-----------------------------------------------------------------------
	
	/*
	 * Regresa el estado del nodo
	 * */
	public int darEstado()
	{
		return estado;	
	}
	/*
	 * dar posicion del estado
	 * */
	public Vector3 darPosicion()
	{
		return posicion;
	}
	/*
	 * da dialogo del estado
	 * */
	public string darDialogo()
	{
		return dialogo;
	}
	
	/*
	 * Da el nodo de adelante
	 * */
	public NodoGrafo darAdelante()
	{
		return adelante;	
	}
	/*
	 * Da el nodo de atras
	 * */
	public NodoGrafo darAtras()
	{
		return atras;	
	}
	/*
	 * Da el nodo derecho
	 * */
	public NodoGrafo darDerecha()
	{
		return derecha;	
	}
	/*
	 * Da el nodo izquierdo
	 * */
	public NodoGrafo darIzquierda()
	{
		return izquierda;	
	}
	
	//---------------------------------------------------------------------------
	// Setters
	//---------------------------------------------------------------------------
	
	/*
	 * Modifica el estado del nodo
	 * */
	public void asignarEstado(int est)
	{
		estado = est;	
	}
	/*
	 * Asigna un sucesor derecho directamente
	 * */
	public void asignarDerecho(NodoGrafo nodoDerecho)
	{
		derecha = nodoDerecho;
	}
	/*
	 * Asigna un sucesor Izquierdo directamente
	 * */
	public void asignarIzquierdo(NodoGrafo nodoIzquierdo)
	{
		izquierda = nodoIzquierdo;
	}
	/*
	 * Asigna un sucesor delantero directamente
	 * */
	public void asignarDelantero(NodoGrafo nodoDelantero)
	{
		adelante = nodoDelantero;
	}
	/* 
	 * Asigna un predecesor al nodo
	 * */
	public void asignarAnterior(NodoGrafo nodoAnterior)
	{
		atras = nodoAnterior;
	}
	/*
	 * Asigna un vector al estado
	 * */
	public void agregarPosicion(Vector3 position)
	{
		posicion = position;
	}
	/*
	 * Asigna un dialogo al estado
	 * */
	public void agregarDialogo(string dialog)
	{
		dialogo = dialog;
	}
}

