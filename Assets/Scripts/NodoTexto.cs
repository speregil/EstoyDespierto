using UnityEngine;
using System.Collections;

public class NodoTexto : MonoBehaviour {
	
// ================================================================================
// Atributos
// ================================================================================

	private ArrayList texto;
	private  int indiceActual; 
	private NodoTexto hijo1;
	private NodoTexto hijo2;
		
//En caso de ser el ultimo nodo tiene un resultado de la conversacion
	private int resultado = -1;
		
//Constantes para manejar los resultados
	public static int OPCION_1 = 1;
	public static int OPCION_2 = 2;

// ================================================================================
// Constructores
// ================================================================================

	public NodoTexto(ArrayList nTexto){
		texto = nTexto;
		indiceActual = 0;
	}

	public NodoTexto(ArrayList nTexto, int nResultado){
		resultado = nResultado;
		texto = nTexto;
		indiceActual = 0;
	}

// ================================================================================
// Metodos
// ================================================================================

	public bool tieneHijos(){
		if(!hijo1 && !hijo2){
			return false;
		}else 
		return true;
	}

	public bool estaTerminado(){
		if(indiceActual >= texto.Count){
			return true;
		}
		else{
			return false;
		}
	}

// ================================================================================
// Getters y Setters
// ================================================================================
	public NodoTexto getHijo1(){
		return hijo1;
	}

	public void setHijo1(NodoTexto nodo){
		hijo1 = nodo;
	}

	public void setHijo2(NodoTexto nodo){
		hijo2 = nodo;
	}

	public NodoTexto getHijo2(){
		return hijo2;
	}

	public string getTextoLinea(){
  		string respuesta = (string)texto[indiceActual];
 		indiceActual ++ ;
		return respuesta;
	}

	public int getResultado(){
		return resultado;
	}
}