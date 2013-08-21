using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {

//================================================================================================
// Atributos
//================================================================================================
	
	//flag para controlar la acción con el objeto
	private bool control = true;
	
	private IEventos interfaz;
	
	//Determina el comando de acción del evento
	public string comando;
	//Conexión con el administrador del nivel
	public GameObject admin;

//================================================================================================
// Metodos
//================================================================================================

	void Awake(){
		interfaz = (IEventos)admin.GetComponent(typeof(IEventos));	
	}
	
	public void encender(){
		control = true;
	}

	public void apagar(){
		control = false;
	}

	public void OnMouseEnter(){
			//TODO Iluminar el objeto
			print ("SOBRE UN INTERACTOR");
	}

	public void OnMouseExit(){
		//TODO Deseleccionar el objeto
		print ("SALIO DE UN INTERACTOR");
	}

	public void OnMouseDown(){	
		if(control){
			print("Click!!!!!");
			interfaz.Switch(comando);
		}
	}
}