using UnityEngine;
using System.Collections;

public class VariablesGlobales : MonoBehaviour {
	
	public static bool primeraVez = true;
	public NodoGrafo ultimoEstado;
	public EstadosNivel estados;
	
	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		estados = new EstadosNivel();
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