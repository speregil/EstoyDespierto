using UnityEngine;
using System.Collections;

public class TextosNivel{

	private NodoTexto[] listaTextos = new NodoTexto[100];
	
//==============================================================================================================
// Atributos y constantes
//==============================================================================================================
	
	/*
	 * CONSTANTES DE LOS TEXTOS
	 */
	// NIVEL PRINCIPAL
	public const int TEXTO_INTRO_CAMA = 0;
	public const int TEXTO_INTRO_VER_GEMELAS = 1;
	public const int TEXTO_CAMA_GEMELA_IZQUIERDA = 2;
	public const int TEXTO_CAMA_GEMELA_DERECHA = 3;
	public const int TEXTO_MUEBLE_CUARTO_SI_NINO = 4;
	public const int TEXTO_MUEBLE_CUARTO_NO_NINO = 5;
	public const int TEXTO_CAMA_GEMELAS_SE_VAN = 6;
	public const int TEXTO_CAMA_PUERTA = 7;
	
	/* 
	 * CONSTANTES RESULTADOS DE LOS DIALOGOS
	 */
	//NIVEL PRINCIPAL
	public const int RESULTADO_INTRO = 0;
	public const int RESULTADO_CAMA_GEMELAS = 1;
	
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
		textoCamaGemelaDerecha();
		textoCamaGemelaIzquierda();
		textoMuebleCuartoSiNino();
		textoMuebleCuartoNoNino();
		textoCamaGemelasSeVan();
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
	
	private void textoCamaGemelaIzquierda(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "- Tal vez no estás muerto, solo cansado. Cansa estar tanto tiempo en el mismo " +
			"sitio. Si te paras y sales, verás que es mucho mejor afuera.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_CAMA_GEMELAS);
		listaTextos[TEXTO_CAMA_GEMELA_IZQUIERDA] = nuevoTexto;
	}
	
	private void textoCamaGemelaDerecha(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "- No estarás muerto ¿o sí? – dice la niña, o una de las niñas, la de la moña en la " +
			"derecha – porque si estás muerto ¿Para qué te despertaste entonces?";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_CAMA_GEMELAS);
		listaTextos[TEXTO_CAMA_GEMELA_DERECHA] = nuevoTexto;
	}
	
	private void textoCamaGemelasSeVan(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Las niñas están paradas al frente mío, se sonríen, se miran con picardía, se " +
			"cogen de las manos y salen corriendo por la puerta.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CAMA_GEMELAS_SE_VAN] = nuevoTexto;
	}
	
	/*
	 * ESTADO 3: FRENTE AL MUEBLE
	 */
	 
	 private void textoMuebleCuartoSiNino(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "El frio me acuchilla el vientre y me corta las venas. Deseo volver a la cama para " +
			"buscar el calor de las cobijas, pero no, me inquieta demasiado el niño, tiene que oír lo que le " +
			"tengo que decir, y yo también, pues todavía no sé lo que es.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_MUEBLE_CUARTO_SI_NINO] = nuevoTexto;
	}
	
	 private void textoMuebleCuartoNoNino(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Y ahí estoy, de pie. Resulta que estoy descalzo, que la baldosa del piso está " +
			"helada y no hay alfombra en ningún lado. Los pies se me adormecen, el frio se me sube a la cabeza, " +
			"me cuesta dar cualquier paso.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_MUEBLE_CUARTO_NO_NINO] = nuevoTexto;
	}
}