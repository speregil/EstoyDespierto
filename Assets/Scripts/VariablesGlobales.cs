using UnityEngine;
using System.Collections;

public class VariablesGlobales : MonoBehaviour {
	
	public NodoGrafo ultimoEstado;
	
	void Awake(){
		DontDestroyOnLoad(transform.gameObject);	
	}
	void Start(){
	}
	
	public void establecerUltimoEstado(NodoGrafo nuevo){
		ultimoEstado = nuevo;	
	}
	
	public NodoGrafo darUltimoEstado(){
		return ultimoEstado;	
	}
}