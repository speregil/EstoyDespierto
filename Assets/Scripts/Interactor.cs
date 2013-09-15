using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {

//================================================================================================
// Atributos
//================================================================================================
	
	//flag para controlar la acción con el objeto
	private bool control = true;
	
	private IEventos interfaz;
	
	private MovimientoDisplay movimiento;
	
	private Texture2D cursor;
	
	// Conexion con al administrador global del juego
	private GameObject globales;
	
	//Determina el comando de acción del evento
	public string comando;
	
	// Determian el ID del estado donde se puede activar este interactor
	public int estadoBase;
	
	//Conexión con el administrador del nivel
	public GameObject admin;

//================================================================================================
// Metodos
//================================================================================================

	void Awake(){
		interfaz = (IEventos)admin.GetComponent(typeof(IEventos));
	}
	
	void Start(){
		globales = GameObject.Find("Global");
		movimiento = (MovimientoDisplay)globales.GetComponent(typeof(MovimientoDisplay));
		cursor = VariablesGlobales.cursorOver;
	}
	
	public void encender(){
		control = true;
	}

	public void apagar(){
		control = false;
	}

	public void OnMouseEnter(){
		if(OnEstado()){
			Debug.Log("Enter");
			Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
		}
	}

	public void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
	}

	public void OnMouseDown(){	
		if(control && OnEstado()){
			interfaz.Switch(comando);
		}
	}
	
	public bool OnEstado(){
		NodoGrafo estadoActual = movimiento.darEstadoActual();
		if(estadoActual.darEstado() == estadoBase){
			return true;
		}
		return false;
	}
}