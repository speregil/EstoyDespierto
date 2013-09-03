using UnityEngine;
using System.Collections;

public class TextosNivel{

	private NodoTexto[] listaTextos = new NodoTexto[100];
	
//==============================================================================================================
// Atributos y constantes
//==============================================================================================================
	
	// Constantes de los textos
	public const int TEXTO_INTRO_CAMA = 0;
	public const int TEXTO_INTRO_VER_GEMELAS = 1;
	
	// Constantes de los resultados de dialogo
	public const int RESULTADO_INTRO = 0;
	
//==============================================================================================================
// Constructores
//==============================================================================================================
	
	
	public TextosNivel(){
		InicializarTextosNivelPrincipal();		
	}
	
	public NodoTexto darTexto(int indice){
		return listaTextos[indice];	
	}
	
	public void InicializarTextosNivelPrincipal(){
		textoIntroCama();
		textoIntroVerGemelas();
	}

//==============================================================================================================
// Textos
//==============================================================================================================
	
	/*
	 * ESCENA 1: CUARTO Y CORREDOR
	 */
	
	/*
	 * ESTADO 1: EN LA CAMA
	 * SUB-ESTADO: OJOS CERRADOS
	 * INTRO
	 */
	private void textoIntroCama(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Oigo unos pasitos apagados, unas risitas contenidas, luego algo se sube muy " +
			"despacio a la cama y unas manitas empiezan a tocarme la mejilla.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "- ¿Estas despierto? – dice una vocecita mientras que una mano helada sube lentamente hasta " +
			"llegar al ojo, y antes que yo mismo me responda si estoy despierto o no, ella lo abre con los dedos.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_INTRO);
		listaTextos[TEXTO_INTRO_CAMA] = nuevoTexto;
	}
	
	/*
	 * SUB-ESTADO: CON LAS GEMELAS
	 * INTRO
	 */
	private void textoIntroVerGemelas(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Veo la niña ante mí, siento el peso de su cuerpo sobre mi pecho, el toque helado de " +
			"su mano en el rostro, todavía no sé si estoy despierto. Otra mano helada coge mi brazo y lo saca de " +
			"la cama, halándolo con insistencia.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Miro al lado y veo a la misma niña: los mismos ojos oscuros, la misma boca risueña, la " +
			"piel igual de fría, el mismo pelo delgado y pálido.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Vuelvo a ver a la que está en mi pecho. no se ha movido de ahí, ni siquiera ha parpadeado, " +
			"y veo que es ella misma, la misma moña roja en la izquierda ¿O acaso en la derecha?";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_INTRO_VER_GEMELAS] = nuevoTexto;
	}
}