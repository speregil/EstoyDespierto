using UnityEngine;
using System.Collections;

public class VariablesGlobales : MonoBehaviour {
	
	public static bool primeraVez = true;
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