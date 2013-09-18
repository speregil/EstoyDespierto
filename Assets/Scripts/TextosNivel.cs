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
	public const int TEXTO_CAMA_NINO = 8;
	public const int TEXTO_PUERTA_NINO = 9;
	public const int TEXTO_PUERTA_SOLO = 10;
	public const int TEXTO_CORREDOR_1_NO_REJA = 11;
	public const int TEXTO_CORREDOR_ALFOMBRA = 12;
	public const int TEXTO_CORREDOR_PARED = 13;
	public const int TEXTO_CORREDOR_1_SI_REJA = 14;
	public const int TEXTO_CORREDOR_2_INTRO = 15;
	public const int TEXTO_CORREDOR_PUERTA = 16;
	public const int TEXTO_CORREDOR_LAMPARA = 17;
	public const int TEXTO_FRENTE_ESPEJO = 18;
	public const int TEXTO_ESPEJO = 19;
	public const int TEXTO_REJA = 20;
	public const int TEXTO_PUERTA_GEMELAS = 21;
	public const int TEXTO_PUERTA_COCINA = 35;
	public const int TEXTO_GEMELAS_COMPLETO = 36;
	
	// CUARTO DE LAS GEMELAS
	public const int TEXTO_GEMELAS_INTR0 = 22;
	public const int TEXTO_GEMELAS_PUERTA_SIN_JUEGO = 23;
	public const int TEXTO_GEMELAS_PUERTA_SIN_APROBACION = 24;
	public const int TEXTO_GEMELAS_PUERTA_CON_APROBACION = 25;
	public const int TEXTO_GEMELAS_INTRO_FRENTE = 26;
	public const int TEXTO_GEMELAS_REINA = 27;
	public const int TEXTO_GEMELAS_SIN_REINA = 28;
	public const int TEXTO_GEMELAS_BUFON = 29;
	public const int TEXTO_GEMELAS_SIN_BUFON = 30;
	public const int TEXTO_GEMELAS_DERECHA = 31;
	public const int TEXTO_GEMELAS_IZQUIERDA = 32;
	public const int TEXTO_GEMELAS_GANO_IZQUIERDA = 33;
	public const int TEXTO_GEMELAS_GANO_DERECHA = 34;
	
	// COCINA
	public const int TEXTO_COCINA_INTRO = 37;
	public const int TEXTO_COCINA_CENTRO = 38;
	public const int TEXTO_COCINA_JOVEN_INTRO = 39;
	public const int TEXTO_COCINA_OLLA_SI_INTRO = 40;
	public const int TEXTO_COCINA_OLLA_NO_INTRO = 41;
	public const int TEXTO_COCINA_JOVEN_SOPA = 42;
	public const int TEXTO_COCINA_LIBRO = 43;
	public const int TEXTO_COCINA_LAVADORA_SI_INTRO = 44;
	public const int TEXTO_COCINA_LAVADORA_NO_INTRO = 45;
	public const int TEXTO_COCINA_SERVILLETA = 46;
	public const int TEXTO_COCINA_LOCKER_SI_INTRO = 47;
	public const int TEXTO_COCINA_LOCKER_NO_INTRO = 48;
	
	/* 
	 * CONSTANTES RESULTADOS DE LOS DIALOGOS
	 */
	//NIVEL PRINCIPAL
	public const int RESULTADO_INTRO = 0;
	public const int RESULTADO_CAMA_GEMELAS = 1;
	public const int RESULTADO_GEMELAS_SE_FUERON = 2;
	public const int RESULTADO_NINO_SE_FUE = 3;
	public const int RESULTADO_CAMA_SOLO = 4;
	public const int RESULTADO_PUERTA_GEMELAS = 5;
	public const int RESULTADO_PUERTA_COCINA = 9;
	
	// CUARTO DE LAS GEMELAS
	public const int RESULTADO_APROPACION = 6;
	public const int RESULTADO_HABLAR_CUARTO = 7;
	public const int RESULTADO_INICIO_JUEGO1 = 8;
	
	// COCINA
	public const int RESULTADO_INTRO_JOVEN = 10;
	
	
	
//==============================================================================================================
// Constructores
//==============================================================================================================
	
	
	public TextosNivel(){
		InicializarTextosNivelPrincipal();
		InicializarTextosNivelGemelas();
		InicializarTextosNivelCocina();
	}
	
	public void InicializarTextosNivelPrincipal(){
		textoIntroCama();
		textoIntroVerGemelas();
		textoCamaGemelaDerecha();
		textoCamaGemelaIzquierda();
		textoMuebleCuartoSiNino();
		textoMuebleCuartoNoNino();
		textoCamaGemelasSeVan();
		textoCamaNino();
		textoPuertaNino();
		textoPuertaSolo();
		textoCorredor1NoReja();
		textoCorredorAlfombra();
		textoCorredorPared();
		textoCorredor1SiReja();
		textoCorredor2Intro();
		textoCorredorPuerta();
		textoCorredorLampara();
		textoFrenteEspejo();
		textoEspejo();
		textoReja();
		textoPuertaGemelas();
		textoGemelasIntroFrente();
		textoPuertaCocina();
		textoGemelasCompleto();
	}
	
	public void InicializarTextosNivelGemelas(){
		textoGemelasIntro();
		textoGemelasPuertaSinJuego();
		textoGemelasPuertaSinAprobacion();
		textoGemelasPuertaConAprobacion();
		textoGemelasIntroFrente();
		textoGemelasReina();
		textoGemelasSinReina();
		textoGemelasBufon();
		textoGemelasSinBufon();
		textoGemelasDerecha();
		textoGemelasIzquierda();
		textoGemelasGanoDerecha();
		textoGemelasGanoIzquierda();
	}
	
	public void InicializarTextosNivelCocina(){
		textoCocinaIntro();
		textoCocinaCentro();
		textoCocinaJovenIntro();
		textoCocinaOllaSiIntro();
		textoCocinaOllaNoIntro();
		textoCocinaJovenSopa();
		textoCocinaLibro();
		textoCocinaLavadoraSiIntro();
		textoCocinaLavadoraNoIntro();
		textoCocinaServilleta();
		textoCocinaLockerSiIntro();
		textoCocinaLockerNoIntro();
	}

//===============================================================================================================
// Metodos Auxiliares
//===============================================================================================================

	public NodoTexto darTexto(int indice){
		return listaTextos[indice];	
	}

//==============================================================================================================
// Textos
//==============================================================================================================
	
	/*
	 * ESCENA 1: CUARTO Y CORREDOR
	 */
	
	/*
	 * ESTADO 1-1: EN LA CAMA
	 * SUB-ESTADO: OJOS CERRADOS
	 * INTRO
	 */
	private void textoIntroCama(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Tengo uno de esos sueños extraños en que uno intenta entender algo que no tiene sentido.\n" +
			"Me repito constantemente que debo usar los botones en pantalla para avanzar, que adelanto los\n" +
			"textos e interactuó con los objetos con click, y que eventualmente tendré que usar el teclado.\n\n"+
			"Nada tiene sentido, ni importancia, pues todo cambia de un momento a otro. Hay algo distinto\n" +
			"en mis sueños.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Oigo unos pasitos apagados, unas risitas contenidas, luego algo se sube muy despacio a la cama\n" +
		 	"y unas manitas empiezan a tocarme la mejilla.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "- ¿Estas despierto? – dice una vocecita mientras que una mano helada sube lentamente hasta\n" +
			"llegar al ojo, y antes que yo mismo me responda si estoy despierto o no, ella lo abre con los\n" +
			"dedos.";
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
		string nuevaLinea = "Veo la niña ante mí, siento el peso de su cuerpo sobre mi pecho, el toque helado de su\n" +
			"mano en el rostro, todavía no sé si estoy despierto. Otra mano helada coge mi brazo y\n" +
			"lo saca de la cama, halándolo con insistencia.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Miro al lado y veo a la misma niña: los mismos ojos oscuros, la misma boca risueña, la piel igual\n" +
			"de fría, el mismo pelo delgado y pálido.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Vuelvo a ver a la que está en mi pecho. no se ha movido de ahí, ni siquiera ha parpadeado, y\n" +
			"veo que es ella misma, la misma moña roja en la izquierda ¿O acaso en la derecha?";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_INTRO_VER_GEMELAS] = nuevoTexto;
	}
	
	private void textoCamaGemelaIzquierda(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "- Tal vez no estás muerto, solo cansado. Cansa estar tanto tiempo en el mismo sitio. Si te\n" +
			"paras y sales, verás que es mucho mejor afuera.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_CAMA_GEMELAS);
		listaTextos[TEXTO_CAMA_GEMELA_IZQUIERDA] = nuevoTexto;
	}
	
	private void textoCamaGemelaDerecha(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "- No estarás muerto ¿o sí? – dice la niña, o una de las niñas, la de la moña en la derecha\n" +
			"– porque si estás muerto ¿Para qué te despertaste entonces?";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_CAMA_GEMELAS);
		listaTextos[TEXTO_CAMA_GEMELA_DERECHA] = nuevoTexto;
	}
	
	private void textoCamaGemelasSeVan(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Las niñas están paradas al frente mío, se sonríen, se miran con picardía, se cogen de las manos\n" +
			"y salen corriendo por la puerta.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_GEMELAS_SE_FUERON);
		listaTextos[TEXTO_CAMA_GEMELAS_SE_VAN] = nuevoTexto;
	}
	
	/*
	 * SUB-ESTADO: SOLO EN LA CAMA
	 */
	private void textoCamaNino(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Una puerta.\n\nEsa puerta nunca había estado ahí. Y si había estado ahí, nunca había " +
			"estado abierta, o si estaba\n" +
			"abierta,  la luz nunca había estado encendida. Da igual, no recuerdo haber estado nunca en este\n" +
			"lugar, ni siquiera sé si estoy despierto.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_CAMA_SOLO);
		listaTextos[TEXTO_CAMA_NINO] = nuevoTexto;
	}
	
	/*
	 * ESTADO 1-2: FRENTE A LA PUERTA
	 * SUB-ESTADO: CON EL NIÑO
	 */
	private void textoPuertaNino(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Es entonces que lo veo, escondido detrás de la puerta, su sombra entrando tímidamente al\n" +
			"cuarto. Nuestros ojos se cruzan por un instante, y eso me basta para querer hablar con ese\n" +
			"niño que me espía detrás de la puerta.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "No sé por qué me urge tanto, tal vez sea porque todavía estoy algo dormido, y no pienso bien,\n" +
			"pero me ronda en la cabeza la idea de que tengo que decirle algo importante.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_NINO_SE_FUE);
		listaTextos[TEXTO_PUERTA_NINO] = nuevoTexto;
	}
	
	/*
	 * SUB-ESTADO: SOLO EN LA PUERTA
	 */
	private void textoPuertaSolo(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Quiero llamar al niño, decirle que entre, que sus amiguitas ya hicieron la travesura y me\n" +
			"despertaron, pero al verse descubierto se asusta y solo huye.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_PUERTA_SOLO] = nuevoTexto;
	}
	
	/*
	 * ESTADO 1-3: FRENTE AL MUEBLE
	 */
	 
	 private void textoMuebleCuartoSiNino(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "El frio me acuchilla el vientre y me corta las venas. Deseo volver a la cama para buscar el\n" +
			"calor de las cobijas, pero no, me inquieta demasiado el niño, tiene que oír lo que le tengo que\n" +
			"decir, y yo también, pues todavía no sé lo que es.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_MUEBLE_CUARTO_SI_NINO] = nuevoTexto;
	}
	
	 private void textoMuebleCuartoNoNino(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Y ahí estoy, de pie. Resulta que estoy descalzo, que la baldosa del piso está helada y no hay\n " +
			"alfombra en ningún lado. Los pies se me adormecen, el frio se me sube a la cabeza, me cuesta\n" +
			"dar cualquier paso.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_MUEBLE_CUARTO_NO_NINO] = nuevoTexto;
	}
	
	/*
	 * ESTADO 1-4: CORREDOR 1
	 */
	
	private void textoCorredor1NoReja(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Con el primer paso, otro lo sigue con rapidez. Estoy parado al otro lado de la puerta, y al mirar\n" +
			"atrás, no me cabe en la cabeza como deseaba tanto estar ahí, entre sombras y un frío casi\n" +
			"palpable. La cama se ve pequeña, las sabanas duras y roídas. Cierro la puerta con fuerza,\n" +
			"ahora no soporto ver la cama, estoy muy cómodo donde estoy parado, aunque todavía piense\n" +
			"que sigo acostado y arropado, que todavía no he despertado.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CORREDOR_1_NO_REJA] = nuevoTexto;
	}
	
	private void textoCorredorAlfombra(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Mis pensamientos se centran en una sola cosa, pues no logro entender dónde estoy. No solo la\n" +
			"alfombra es cálida, lo es también el aire, la luz, el ambiente en general. Estoy en un pasillo\n" +
			"común y corriente, y sin embargo es extraño, hay algo que no cuadra en él, que me deja una\n" +
			"duda rondando en la cabeza.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CORREDOR_ALFOMBRA] = nuevoTexto;
	}
	
	private void textoCorredorPared(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "¿Qué es lo que me molesta? Es lo largo, lo recto del pasillo. Veo hacia el frente y el camino se\n" +
			"extiende, varios metros de esa alfombra roja, de esa pared color perla, de esa cenefa dorada.\n\n" +
			"¿Y estas puertas? Hay una tras otra, varias puertas de madera, todas cerradas, todas igual de\n" +
			"grandes y atemorizantes.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CORREDOR_PARED] = nuevoTexto;
	}
	
	private void textoCorredor1SiReja(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Corrí- Quiero estar otra vez en la cama, quiero arroparme otra vez con las sabanas. Pero he\n" +
			"cerrado la puerta, y ahora, por más que halo, empujo y golpeo, no logro abrirla otra vez.\n" +
			"Eso es bueno, porque, arrodillado en el suelo y apoyado contra la puerta, recuerdo que esa\n" +
			"cama es dura y el piso muy frio. Estoy mejor aquí, así no sea real, el pasillo en realidad\n" +
			"no es tan largo, ni el espejo tan grande.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CORREDOR_1_SI_REJA] = nuevoTexto;
	}
	
	private void textoPuertaGemelas(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Creo estar por fin a gusto, el rostro sobre la puerta y las rodillas hundidas en la alfombra,\n" +
			"cuando oigo de nuevo las risas, y vuelve a mí la urgencia de hablarle a ese niño, y ahora que\n" +
			"lo pienso, necesito hablar también con las niñas, pues nunca se disculparon por despertarme,\n" +
			"o por no despertarme completamente.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_PUERTA_GEMELAS);
		listaTextos[TEXTO_PUERTA_GEMELAS] = nuevoTexto;
	}
	
	private void textoGemelasCompleto(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "He tenido suficiente diversión con las niñas, y suficientes recuerdos, y suficiente culpa.\n" +
			"Debo buscar más cosas, hay más puertas en este pasillo.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_COMPLETO] = nuevoTexto;
	}
	
	/*
	 * ESTADO 1-5: CORREDOR 2
	 */ 
	private void textoCorredor2Intro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Cruzo por el frente de cada puerta casi corriendo, como si no quisiera que se abrieran en el\n" +
			"preciso momento en el que yo estoy ahí.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CORREDOR_2_INTRO] = nuevoTexto;
	}
	
	private void textoCorredorPuerta(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Estas puertas me devoran, quieren arrastrarme dentro y mostrarme su contenido. Temo abrirlas y\n" +
			"encontrar algo ahi, algo que no entienda, o que no recuerde, o que ya olvidé. De cualquier forma, algo, y ahora\n" +
			"no quiero encontrarme con nada.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CORREDOR_PUERTA] = nuevoTexto;
	}
	
	private void textoCorredorLampara(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "¿Qué es lo que me molesta? Son las dos hileras de lámparas, de esos bombillos ridículos que\n" +
			"imitan velas, de los brazos plateados, uno después del otro en cada pared, adornando el espacio\n" +
			"vacío entre las puertas.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_CORREDOR_LAMPARA] = nuevoTexto;
	}
	
	private void textoPuertaCocina(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Ya había notado que en este pasillo la luz y los colores me hipnotizan, me tranquilizan, pero\n" +
			"justo al pasar al lado de esta puerta siento con facilidad que ahora mi nariz también entra a este\n" +
			"juego de sobrecargar mi mente con sensaciones. Es un olor dulce que no hace sino despertar\n" +
			"recuerdos en mi cabeza, de esos recuerdos que solo se pueden oler. Es mi nariz la que\n" +
			"me obliga a entrar.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_PUERTA_COCINA);
		listaTextos[TEXTO_PUERTA_COCINA] = nuevoTexto;
	}
	
	/*
	 * ESTADO 1-6 ESPEJO
	 */
	
	private void textoFrenteEspejo(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Llego al final del pasillo ¿Cuántas puertas crucé? Volteo a ver y no hay más de cuatro, dos a\n" +
			"cada lado, la puerta de la habitación al fondo. El pasillo no es tan grande, las puertas no son\n" +
			"tan imponentes.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_FRENTE_ESPEJO] = nuevoTexto;
	}
	
	private void textoEspejo(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "¿Qué es, entonces, lo que me molesta? Es el espejo, si, el espejo que estaba al frente mío,\n" +
			"y que ahora tengo directamente arriba. Está muy arriba. Mis ojos no llegan ni al marco, estiro la\n" +
			"mano y apenas si puedo tocarlo. Es un espejo enorme, está muy arriba ¿O seré yo el que es\n " +
			"mas pequeño y estoy muy abajo? Eso es precisamente lo que me molesta, que no lo sé.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_ESPEJO] = nuevoTexto;
	}
	
	private void textoReja(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "También está la reja, justo al lado, solo a unos pasos. Es de un metal negro brillante,\n" +
			"hay un candado enorme cerrándolo, unas escaleras oscuras al otro lado, y arriba, otra puerta,\n" +
			"también cerrada, parece luz lo que se escurre por debajo.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "No es esta luz amarilla y caliente que me rodea. Es más blanca, más fría, mucho más real.\n" +
			"Más real que este pasillo con sus detallitos molestos que me hacen dar cuenta que no puedo\n" +
			"estar despierto, y que no debería estar ahí parado, sino en la cama, donde debería estar\n" +
			"la gente que duerme.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_REJA] = nuevoTexto;
	}
	
	
	/*
	 * ESCENA 2: CUARTO DE LAS GEMELAS
	 */
	
	/*
	 * ESTADO 2-1: INTRO
	 */
	
	 private void textoGemelasIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Me reciben dos moñas, una al lado izquierdo de la cabeza y otra al lado derecho. Me reciben\n" +
			"también dos sonrisas, enormes, brillantes y sin algunos dientes, las sonrisas más grandes que he\n" +
			"visto, como si verme fuera lo mejor que les hubiera pasado.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Es ridículo, pues no sabría a quién podría parecerle yo una buena noticia. No sé por qué\n" +
			"pienso en eso,solo se me vino a la mente, y no puedo pensar por qué lo pensé, pues las\n" +
			"gemelas ya están al frente mío, una en cada mano, y me meten al cuarto a la fuerza.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		
		listaTextos[TEXTO_GEMELAS_INTR0] = nuevoTexto;
	}
	
	/*
	 * ESTADO 2-3: FRENTE A LAS GEMELAS
	 */
	private void textoGemelasIntroFrente(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "- Ven, ven – dice con emoción la de la moña derecha – o te quedaras de nuevo dormido\n" +
			"ahí parado.\n\n"+
			"- Lo mejor para despertarse es jugar – dice ahora la de la izquierda, y me jalonea el brazo\n" +
			"para que me siente en el tapete, en medio de la habitación – Ahora si podemos jugar a lo que\n" +
			"el rey manda, ya somos tres.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "-  Bien, pero esta vez yo no seré el rey. Siempre me toca el bufón, y no me gusta ese papel.\n"+
			"La de la moña en la izquierda se ríe con gana, con verdadera felicidad en su voz. – Bien, bien,\n" +
			"yo seré la reina y nuestro amigo será el bufón.\n\n"+
			"- ¡No seas tan maleducada! Deja que él elija.\n\n"+
			"- Está bien, pero empecemos ya, o se quedará dormido otra vez.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Se supone que debo responder algo, pero no sé qué diferencia hay entre ser el bufón o la reina\n" +
			"¿Y si me explicaran mejor en qué consiste el juego?\n\n"+ 
			"El rey se da cuenta de mi indecisión, y comienza a inquietarse. – No hay de otra – dice – Si no\n" +
			"empezamos de una vez, nunca lo haremos. Tendremos que descubrir qué eres mientras jugamos,\n" +
			"ya se me ocurrió el primer decreto.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "El rey corre hacia la esquina del cuarto, agarra un banquito pequeño, lo trae, se para en él,\n" +
			"se arregla el vestido, hincha el pecho, se aclara la garganta  y sube el mentón:\n\n"+ 
			"Atención todo el mundo que habla el rey\n"+
			"Siéntese el peón, el herrero y hasta el buey\n"+
			"Y que nadie lo mantenga en secreto\n"+
			"Que este es mi primer decreto";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "La niña pasa la vista por toda la habitación, pensando en su primer decreto. Algo se le viene a\n" +
			"la cabeza, pues su expresión cambia: “Quiero ver un baile, pero no se puede hacer nada en este\n" +
			"desorden ¡El rey decreta que se limpie el cuarto, y que se guarde todo en el armario!”.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_HABLAR_CUARTO);
		nuevaLinea = "Las niñas me miran expectantes, esperan que yo haga algo, y al parecer ese algo tiene que ver\n" +
			"con ser la reina o ser el bufón. Todavía no entiendo el juego muy bien, de por si no he entendido\n" +
			"nada desde que me desperté.";
		nuevaLista.Add(nuevaLinea);
		listaTextos[TEXTO_GEMELAS_INTRO_FRENTE] = nuevoTexto;
	}
	
	private void textoGemelasDerecha(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "El Rey me mira impaciente, pues espera que su orden se cumpla en el acto. Temo desilusionarlo,\n" +
			"ya sea porque es el rey o porque solo es una niña, así que me dispongo a cumplir lo que\n" +
			"decretó.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_DERECHA] = nuevoTexto;
	}
	
	private void textoGemelasIzquierda(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "La niña de la moña izquierda me mira todavía con ojos enormes, profundos. Son ojos alegres\n" +
			"y esperanzados. Esos ojos no hacen más que perturbarme, pues sé que esa mirada llena de\n" +
			"alegría está dirigida a mí, y yo no me siento capaz de corresponder tantos buenos\n" +
			"sentimientos.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_IZQUIERDA] = nuevoTexto;
	}
	
	private void textoGemelasGanoIzquierda(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Atención todo el mundo\n"+
			"No debe hablar ni el mudo\n"+
			"El trabajo decretado ha sido hecho\n"+
			"Y el rey ha quedado satisfecho";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "La niña ríe, salta, grita. Trata de imitar mis movimientos alocados al intentar ordenar el cuarto.\n" +
			"El papel de reina le queda, sabe divertirse, sabe apreciar las cosas. Es una lástima que le\n" +
			"falte dedicación. Debe ser por eso que no es un buen rey. No me molestaría volver a jugar\n" +
			"con ella, pero sé que eso tiene que esperar. ";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "El niño me lo ha dicho. No es que haya hablado con él, pues no lo he visto desde que salí del\n" +
			"cuarto, pero él me recuerda que debería estar haciendo otras cosas, no solo divertirme, y que\n" +
			"por divertirme ya he perdido mucho tiempo. Claro está, no sé qué es eso otro que debería estar\n" +
			"haciendo, y no puedo evitar sentirme un fracaso cada vez que pienso en el niño.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_GANO_IZQUIERDA] = nuevoTexto;
	}
	
	private void textoGemelasGanoDerecha(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Atención todo el mundo\n"+
			"No debe hablar ni el mudo\n"+
			"El trabajo decretado ha sido hecho\n"+
			"Y el rey ha quedado satisfecho";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "La niña se queda cayada, pues sabe que no tiene que decir más. Su sonrisa habla por sí\n" +
			"sola. El papel de rey le queda, sabe lo que hay que hacer, y como hacerlo. No me molestaría\n" +
			"volver a jugar con ella, pero sé que eso tiene que esperar.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "El niño me lo ha dicho. No es que haya hablado con él, pues no lo he visto desde que salí del\n " +
			"cuarto, pero él me recuerda que tengo prisa. Si no me apuro en aprender todo lo que tengo\n" +
			"que aprender, no tendré éxito.  Claro está, no sé qué se supone que estudio, ni en que debo\n" +
			"tener éxito, y no puedo evitar sentirme un fracaso cada vez que pienso en el niño.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_GANO_DERECHA] = nuevoTexto;
	}
	
	/*
	 ** ESTADO 2-4: TAPETE
	 */
	
	private void textoGemelasBufon(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Mi escenario no es más que un tapete. Creo que es suficiente y adecuado, pero no\n" +
			"puedo evitar sentirme nervioso ¿Les agradará? ¿Lo aceptarán?"; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "No bailo ante cualquiera, es un rey y una reina que esperan que su bufón los entretenga,\n" +
			"o por lo menos así tengo que creerlo si quiero hacer todo bien. No entiendo ese afán por que\n" +
			"todo salga bien, porque me acepten, porque les guste.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Saco una analogía tonta, no sé de donde: “Bailar es como ordenar palabras, salen letras de\n" +
			"todos lados, y tú solo tienes que darles sentido”. Es en verdad una analogía muy tonta.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_INICIO_JUEGO1);
		listaTextos[TEXTO_GEMELAS_BUFON] = nuevoTexto;
	}
	
	private void textoGemelasSinBufon(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Ese tapete rodeado de libros para colorear y juguetes me recuerda algo, pero no se qué.\n" +
			"No importa mucho, porque el espejo y la reja también me hicieron acordar de algo. El pasillo\n" +
			"me acuerda de algo."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "El niño, por sobre todo lo demás, es el que más cosas me hace recordar. Si en verdad estuviera\n" +
			"despierto, sabría qué es lo que se supone que recuerdo.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_SIN_BUFON] = nuevoTexto;
	}
	
	/*
	 * ESTADO 2-6: ARMARIO
	 */
	private void textoGemelasReina(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Me doy cuenta que en efecto hay un desorden monumental. Juguetes, libros y ropa casi\n" +
			"cubren el suelo con otro tapete, las camas están destendidas, las cobijas revueltas y enredadas,\n" +
			"las cortinas no están amarradas y el closet parece una jungla de sacos y chaquetas."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Nada está en su sitio, y no parece haber sitio para todo. El desorden me molesta, me inquieta,\n" +
			"y de mi cabeza no saco el porqué de esos sentimientos. Se me ocurre una analogía tonta, no sé de donde:\n" +
			"“Ordenar ropa es como ordenar palabras, salen letras de todos lados, y tú solo tienes que darles sentido”.\n" +
			"Es en verdad una analogía muy tonta.”.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_INICIO_JUEGO1);
		listaTextos[TEXTO_GEMELAS_REINA] = nuevoTexto;
	}
	
	private void textoGemelasSinReina(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Este cuarto no se parece al anterior, tampoco se parece a lo que he visto de la casa.\n" +
			"Es cálido, pero no me siento incómodo. Tampoco tengo sueño, y creo que por fin estoy\n" +
			"despierto."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Pero igual, también creo que no lo estoy, porque para ser el cuarto de unas niñas, hay muchas\n" +
			"cosas que me preocupan. No se cuales, solo sé que están ahí, como ese armario, que es tan\n" +
			"grande, o tan viejo, o tal vez solo sea que en su interior todo está muy desordenado.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_SIN_REINA] = nuevoTexto;
	}
	
	/*
	 * ESTADO 2-7: PUERTA
	 */
	private void textoGemelasPuertaSinJuego(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Algo en el ambiente me pone nervioso, me oprime. La idea de salir me ronda la cabeza, pues\n" +
			"el pasillo es menos apabullante que esta habitación. Pero las niñas me miran\n" +
			"desde el otro lado, me esperan con ansías ¿Por qué? No creo ser así de especial..";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_PUERTA_SIN_JUEGO] = nuevoTexto;
	}
	
	private void textoGemelasPuertaSinAprobacion(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "De alguna u otra manera, he logrado hacer lo que el rey me pide ¿Si habrá sido de su agrado?\n" +
			"¿Si habré cumplido sus expectativas? La duda me acosa, tengo que hablar con ella.\n" +
			"Los nervios no se me van, ni cuando me acuerdo que solo es un juego entre niñas.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_GEMELAS_PUERTA_SIN_APROBACION] = nuevoTexto;
	}
	
	private void textoGemelasPuertaConAprobacion(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Creo que es todo lo que puedo hacer aquí, y salgo, no con una respuesta, sino con una idea.\n" +
			"No es una idea buena, pues ahora me pesa la memoria, y la necesidad de hablar con ese\n" +
			"niño se convierte en una obsesión."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Hay muchas preguntas en mi cabeza. Una de esas me causa más curiosidad que las otras:\n" +
			"¿No eran dos las niñas que me despertaron?";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_APROPACION);
		listaTextos[TEXTO_GEMELAS_PUERTA_CON_APROBACION] = nuevoTexto;
	}
	
	
	/**
	 * ESCENA 3: COCINA
	 * ESTADO 3-1: INTRO
	 */
	
	private void textoCocinaIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "No me sorprende encontrarme en una cocina al otro lado de la puerta. El lugar entero grita\n" +
			"comodidad. No la comodidad de sentarse en una silla confortable o en una cama cálida.\n" +
			"Es la comodidad de estar en un lugar conocido, un lugar familiar. "; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Es una idea ridícula, pues nunca había estado aquí.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_INTRO] = nuevoTexto;
	}
	
	/*
	 * ESTADO 3-3: CENTRO
	 */
	
	private void textoCocinaCentro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Hay alguien más aquí conmigo. No es un desconocido, aunque no tengo idea de quién es. Es un joven,\n" +
			"un muchacho que solo hace muy poco dejó de ser niño."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Mira con aburrimiento la estufa, donde una enorme olla se calienta con una pequeña llama azul\n" +
			"mientras una columna de humo esparce por todo el lugar el aroma ácido que me atrajo.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_CENTRO] = nuevoTexto;
	}
	
	private void textoCocinaJovenIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "El muchacho da por sentado que yo existo, como si me conociera de toda la vida. Aunque trato de\n" +
			"hacerme notar, mi presencia no lo inmuta en lo más mínimo."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Me veo obligado a ser más directo, y le hablo. Nada importante, pues no tengo nada interesante que\n" +
			"decir, solo un “hola”, y un “¿Qué haces?” a lo que el muchacho solo contesta con “sopa”.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista, RESULTADO_INTRO_JOVEN);
		listaTextos[TEXTO_COCINA_JOVEN_INTRO] = nuevoTexto;
	}
	
	private void textoCocinaJovenSopa(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Hay algo que le preocupa al muchacho. Su expresión aburrida me cuenta muchas cosas, o por lo\n" +
			"menos me da a entender que hay muchas cosas alrededor de este chico y su sopa que podría estar\n" +
			"diciéndome y no lo hace. "; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "De verdad creo que es importante saber en qué piensa, saber qué es lo que no me dice ¿Por qué?\n" +
			"No lo sé, quizás sea porque la sopa si me ha abierto el apetito.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_JOVEN_SOPA] = nuevoTexto;
	}
	
	private void textoCocinaLibro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "- No es que me preocupe como hacer la sopa – dice el muchacho de repente – Porque sé\n" +
			"hacer una sopa. El problema es servirla en el lugar adecuado, y con lo necesario, ese es el\n" +
			"problema. Alguien más tiene que decirme qué hacer ahí."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "El muchacho quiere decir algo más, pero no lo deja salir. Creo saber qué es, porque es obvio.\n" +
			"No hay nadie más ahí ¿A quién le pregunta entonces? ¿A mí? ";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Pues no lo ha hecho, seguramente porque no estoy ahí, sino dormido, o porque intuye que yo no\n" +
			"sé nada sobre sopas, o porque todavía no quiere hablarme, y esa conversación se la soltó al\n" +
			"viento. Yo haría lo mismo que ese muchacho en su lugar ¿O no?";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_LIBRO] = nuevoTexto;
	}
	
	private void textoCocinaServilleta(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "- Todo el mundo tiene sus preferencias, y sus gustos, y sus manías. Es difícil servir una\n" +
			"buena cena si todo el mundo es así ¿Cómo sabré a quien ponerle cuchara y a quien tenedor?\n" +
			"¿A quién le gusta esta salsa o la otra? ¿Medio o tres cuartos? Me gusta hacer sopa, pero\n" +
			"servirla es terrible."; 
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Comprendo al muchacho perfectamente. En parte porque tampoco me agrada servir la cena, y\n" +
			"también porque encuentro a la gente difícil de manejar. Por lo menos a las personas que me he\n" +
			"encontrado hasta el momento, como este muchacho.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_SERVILLETA] = nuevoTexto;
	}
	
	/*
	 * ESTADO 3-4: ESTUFA
	 */
	
	private void textoCocinaOllaSiIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "En efecto, en la olla solo hay sopa, pero además del olor picante que despide, no puedo dar con sus\n" +
			"ingredientes. ¿Detecto ajo? ¿Algo de cilantro? No me gruñe el estómago, sino la cabeza, y no es\n" +
			"sobre la sopa, sino sobre el muchacho."; 
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_OLLA_SI_INTRO] = nuevoTexto;
	}
	
	private void textoCocinaOllaNoIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Hay algo cocinándose en esta olla, algo que despide un aroma dulce y cautivador. Relaciono el olor\n" +
			"con personas, tal vez con gente a la que conocía y con la que solía hablar, o con la que tal vez\n" +
			"nunca hablé. No lo sé, el olor no me cuenta muchas cosas, solo fragmentos."; 
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_OLLA_NO_INTRO] = nuevoTexto;
	}
	
	/*
	 * ESTADO 3-6: LAVADORA
	 */
	
	private void textoCocinaLavadoraSiIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "La lavadora se ha retirado de la sinfonía de sonidos del lugar, y se queda esperando que alguien la\n" +
			"despoje de su contenido. Cuando miro dentro, no puedo pasar por alto una hermoso juego de\n" +
			"individuales recién lavado ¿Será que el muchacho espera comer con alguien? Pienso en\n" +
			"muchas personas, y por último en mí ¿Trata de decirme algo el muchacho?"; 
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_LAVADORA_SI_INTRO] = nuevoTexto;
	}
	
	private void textoCocinaLavadoraNoIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "De alguna manera el sonido de la lavadora es eclipsado por el burbujeo de la olla, y el olor a\n" +
			"detergente se mezcla con el aire salado que el humo de la sopa ha creado."; 
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_LAVADORA_NO_INTRO] = nuevoTexto;
	}
	
	/*
	 * ESTADO 3-7: LOCKERS
	 */
	
	private void textoCocinaLockerSiIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Al ver tantos y tan distintos utensilios, entiendo por qué el muchacho insiste en darle la\n" +
			"espalda a estos armarios. Le recuerdan que tiene que decidir, y hacerlo sabiamente. No puede servir\n" +
			"a unos igual que a otros, ni puede hacer distinciones cuando se supone que todos sean iguales.\n" +
			"Pensarlo me indispone, o quizás solo sea que la sopa ya va oliendo a rancio."; 
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_LOCKER_SI_INTRO] = nuevoTexto;
	}
	
	private void textoCocinaLockerNoIntro(){
		ArrayList nuevaLista = new ArrayList();
		string nuevaLinea = "Hay en este armario utensilios para cada ocasión: Fiestas, cena familiar, desayunos, incluso\n" +
			"implementos solo para el servicio. Por lo visto esta cocina ha visto un sinfín de personas\n" +
			"y un sin fin de estilos."; 
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		listaTextos[TEXTO_COCINA_LOCKER_NO_INTRO] = nuevoTexto;
	}
}