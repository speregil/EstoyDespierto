using UnityEngine;
using System.Collections;

public class IEventos : MonoBehaviour {

	// Interfaz que comunica los Interactors con todos los scripts Manager# que
	// implementen estos métodos

	public void Switch(string objName){
		SendMessage("EventSwitch", objName);
	}

	public void DialogSwitch(int obj){
		SendMessage("EventDialog", obj);
	}
	
	public void EstadoTrigger(string objEstado){
		SendMessage("EventEstado", objEstado);
	}	
}
