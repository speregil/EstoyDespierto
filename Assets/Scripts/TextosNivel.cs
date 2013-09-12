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
	
	// CUARTO DE LAS GEMELAS
	public const int RESULTADO_APROPACION = 6;
	public const int RESULTADO_REINA = 7;
	public const int RESULTADO_BUFON = 8;
	public const int RESULTADO_INICIO_JUEGO1 = 9;
	
	
//==============================================================================================================
// Constructores
//==============================================================================================================
	
	
	public TextosNivel(){
		InicializarTextosNivelPrincipal();
		InicializarTextosNivelGemelas();
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
		string nuevaLinea = "Oigo unos pasitos apagados, unas risitas contenidas, luego algo se sube muy despacio a la cama\n" +
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
		nuevaLinea = "Y aunque se supone que creo seguir dormido, ahora eso no me preocupa, hay una cuestion más\n" +
			"grave en mis manos ahora ¿Qué papel quiero ser en el juego?";
		nuevaLista.Add(nuevaLinea);
		NodoTexto nuevoTexto = new NodoTexto(nuevaLista);
		// Opcion 1
		nuevaLista = new ArrayList();
		nuevaLinea = "La Reina";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Digo que quiero ser la reina, aunque no sé qué diferencia hay entre ser eso o ser bufón.\n" +
			"La niña de la moña derecha corre hacia la esquina del cuarto, agarra un banquito pequeño,\n" +
			"lo trae, se para en él, se arregla el vestido, hincha el pecho, se aclara la garganta  y\n" +
			"sube el mentón:";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Atención todo el mundo que habla el rey\n"+
			"Siéntese el peón, el herrero y hasta el buey\n"+
			"Y que nadie lo mantenga en secreto\n"+
			"Que este es mi primer decreto";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "La niña pasa la vista por toda la habitación, pensando en su primer decreto. Algo se le viene\n" +
			"a la cabeza, pues su expresión cambia: “Quiero ver un baile, pero no se puede hacer nada en\n" +
			"este desorden ¡El rey decreta que se limpie el cuarto, y que se guarde todo en el armario!”.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Al parecer es trabajo de la reina ordenar, y algo en mi interior se alegra de que me permitan\n" +
			"hacerlo. Me preocupa más ordenar el cuarto que no saber por qué me preocupa.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto opcion1 = new NodoTexto(nuevaLista, RESULTADO_REINA);
		nuevoTexto.setHijo1(opcion1);
		// Opcion 2
		nuevaLista = new ArrayList();
		nuevaLinea = "El Bufón";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Digo que quiero ser el bufón, aunque no sé qué diferencia hay entre ser eso o ser reina. La\n" +
			"niña de la moña derecha corre hacia la esquina del cuarto, agarra un banquito pequeño, lo trae,\n" +
			"se para en él, se arregla el vestido, hincha el pecho, se aclara la garganta  y sube el mentón:";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Atención todo el mundo que habla el rey\n"+
			"Siéntese el peón, el herrero y hasta el buey\n"+
			"Y que nadie lo mantenga en secreto\n"+
			"Que este es mi primer decreto";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "La niña mira hacia el techo, pensando cual va a ser su primer decreto. Cuando lo tiene en\n" +
			"la cabeza,se sonríe con malicia y me mira: “El rey decreta que en el tapete de danzas se le\n" +
			"muestre un baile exótico”. La de la moña izquierda suelta una risa ahogada, y ambas se quedan\n" +
			"mirándome, esperando que yo haga algo.";
		nuevaLista.Add(nuevaLinea);
		nuevaLinea = "Al parecer es trabajo del bufón bailar, y algo en mi interior se alegra de que me permitan\n" +
			"hacerlo. Se me ocurren mil cosas, que no sé de donde salen o por qué las conozco. Pero ahora\n" +
			"quiero bailar, no averiguar por qué se hacerlo.";
		nuevaLista.Add(nuevaLinea);
		NodoTexto opcion2 = new NodoTexto(nuevaLista, RESULTADO_BUFON);
		nuevoTexto.setHijo2(opcion2);
		listaTextos[TEXTO_GEMELAS_INTRO_FRENTE] = nuevoTexto;
	}
	
	/*
	 * ESTADO 2-4: TAPETE
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
			"y de mi cabeza no saco el porqué de esos sentimientos, solo sale un estribillo tonto:\n" +
			"“Ordena rápido o no lo ordenes, no sales de aquí hasta que acabes”.";
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
}