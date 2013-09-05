using UnityEngine;
using System.Collections;

public class Parpado2 : MonoBehaviour {

	private float posCerrado;
	private float posAbierto;
	private float posActual;
	
	private bool abrir = false;
	private bool cerrar = false;
	
	// Use this for initialization
	void Start () {
		posCerrado = transform.position.y;
		posAbierto = posCerrado - 0.5f;
		posActual = posCerrado;
	}
	
	// Update is called once per frame
	void Update () {
		if(abrir){
			if(posActual != posAbierto){
				posActual -= 0.01f;
				Vector3 temp = transform.localPosition;
				temp.y -= 0.01f;
				transform.localPosition = temp;
			}
			else{
				abrir = false;	
			}
		}
		else if(cerrar){
			if(posActual != posCerrado){
				posActual += 0.01f;
				Vector3 temp = transform.localPosition;
				temp.y += 0.01f;
				transform.localPosition = temp;
			}
			else{
				cerrar = false;	
			}	
		}
	}
	
	public void Abrir(){
		abrir = true;
	}
	
	public void Cerrar(){
		cerrar = true;	
	}
}
