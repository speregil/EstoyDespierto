using UnityEngine;
using System.Collections;

public class TextosNivel : MonoBehaviour {

	private NodoTexto[] listaTextos = new NodoTexto[100];
	
	public const int TEXTO_PRUEBA = 0;
	public const int TEXTO_INTERACTOR = 1;
	
	public TextosNivel(){
		InicializarTextosNivelPrincipal();		
	}
	
	public NodoTexto darTexto(int indice){
		return listaTextos[indice];	
	}
	
	public void InicializarTextosNivelPrincipal(){
		// Texto de prueba
		/*ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Esto es una texto de prueba";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Y esto tambíen es una prueba de texto";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_PRUEBA] = nuevoTexto;
		//nuevaLista.Clear();
		
		//Texto para el interactor
		nuevaLinea = "Me pinchaste y eso dolio";
		nuevaLista.Add(nuevaLinea);
		nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_INTERACTOR] = nuevoTexto;
		nuevaLista.Clear();*/
		textoPrueba();
		textoInteractor();
	}
	
	private void textoPrueba(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Esto es una texto de prueba";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Y esto tambíen es una prueba de texto";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_PRUEBA] = nuevoTexto;
	}
	
	private void textoInteractor(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Me pinchaste y eso dolio";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_INTERACTOR] = nuevoTexto;
	}
}
