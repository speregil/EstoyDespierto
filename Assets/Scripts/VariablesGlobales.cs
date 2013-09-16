using UnityEngine;
using System.Collections;

public class VariablesGlobales : MonoBehaviour {
	
	// Control de eventos
	public static bool primeraVez = true;
	
	//Flags de personalidad
	public static bool racional = false;
	public static bool artistico = false;
	
	public static Texture2D cursorOver;
	
	public NodoGrafo ultimoEstado;
	public EstadosNivel estados;
	public Texture2D texturaCursor;
	
	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		estados = new EstadosNivel();
		cursorOver = texturaCursor;
	}
	
	void Start(){
	}
	
	public void establecerUltimoEstado(NodoGrafo nuevo){
		ultimoEstado = nuevo;	
	}
	
	public NodoGrafo darUltimoEstado(){
		return ultimoEstado;	
	}
	
	public EstadosNivel darEstados(){
		return estados;	
	}
}