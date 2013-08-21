using UnityEngine;
using System.Collections;

public class AdminNivel : MonoBehaviour {
	
	private TextoDisplay textos;
	
	void Start () {
		textos = (TextoDisplay)GetComponent(typeof(TextoDisplay));
		textos.empezarTexto(TextosNivel.TEXTO_PRUEBA);
	}
	
	void Update () {
	
	}
	
	public void EventSwitch(string comando){
		
		if(comando.Equals("prueba")){
			textos.empezarTexto(TextosNivel.TEXTO_INTERACTOR);
		}
	}
	
	public void EventDialog(int resultado){
		
	}
}
