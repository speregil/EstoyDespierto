using UnityEngine;
using System.Collections;

public class TextosNivel : MonoBehaviour {

	private NodoTexto[] listaTextos = new NodoTexto[100];
	
	public static int TEXTO_PRUEBA = 0;
	
	public TextosNivel(){
		InicializarTextosNivelPrincipal();		
	}
	
	public NodoTexto darTexto(int indice){
		return listaTextos[indice];	
	}
	
	public void InicializarTextosNivelPrincipal(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Esto es una texto de prueba";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Y esto tambíen es una prueba de texto";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_PRUEBA] = nuevoTexto;
	}
}
