using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	//==================================================================================================
	// Atributos
	//==================================================================================================
	
	//Objetos
	public Texture2D titulo;
	public GUISkin skin;
	private Parpado1 parpado1;
	private Parpado2 parpado2;
	private Rect ventana;
	private bool Ventana = false;
	private string creditos;
		
	//=================================================================================================
	// inicializacion
	//=================================================================================================
	
	void Awake(){
		ventana = new Rect(Screen.width/6,(Screen.height/4), Screen.width/2+250,(Screen.height/2));
		creditos = "Equipo de programación:\n" +
			"Sebastián Gil Parga\n" +
			"Armando José Saenz\n\n" +
			"Un agradecimiento muy especial a Leonardo Pinzón,\n" +
			"por colaborarnos con el arte.";
		parpado1 = (Parpado1)GameObject.Find("Parpado1").GetComponent(typeof(Parpado1));
		parpado2 = (Parpado2)GameObject.Find("Parpado2").GetComponent(typeof(Parpado2));
	}
	
	void Start () {
		StartCoroutine(Parpadear());
	}
	
	// ============================================================================================
	// Metodos
	//=============================================================================================
	
	void OnGUI(){
		GUI.skin = skin;
		GUI.Label (new Rect (Screen.width/2 - (titulo.width/2),0, Screen.width, Screen.height), titulo);
		
		if(!Ventana){
			if(GUI.Button(new Rect (Screen.width/2 - 64, Screen.height/2, 128, 35), "INICIAR")){
				Application.LoadLevel("Principal");
			}
		
			if(GUI.Button(new Rect (Screen.width/2 - 64, Screen.height/2+ (35*2), 128, 35), "CREDITOS")){
				//
				
				Ventana = true;
			}
		}
		else{
			ventana = GUI.Window(0,ventana , WindowFunction,"CREDITOS");
			
		}
	}
	
	void WindowFunction (int windowID) {

		GUI.Label (new Rect (10, 30, ventana.width - 20, ventana.height - 30), creditos);
		if(GUI.Button(new Rect (ventana.width/2 - 64, ventana.height/2+ (35*2), 128, 35), "VOLVER")){
				//
				
				Ventana = false;
			}
	}
	
	private IEnumerator Parpadear(){
		while(true){
			parpado1.Cerrar();
			parpado2.Cerrar();
			yield return new WaitForSeconds(2);
			parpado1.Abrir();
			parpado2.Abrir();
			yield return new WaitForSeconds(2);
		}
	}
}