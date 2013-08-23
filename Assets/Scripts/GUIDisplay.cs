using UnityEngine;
using System.Collections;

public class GUIDisplay : MonoBehaviour {
	
	public Texture2D iconoFlecha;
	public float angulo = 0.0f;
	public Grafo grafo;
	int flecha= 0;
	private GUIStyle q;
	private GUIStyle w;
	private GUIStyle e;
	private GUIStyle i;
	private GUIStyle o;
	private GUIStyle p;
	private GUIStyle space;
	
	void Start()
	{
		q = new GUIStyle();
		w = new GUIStyle();
		e = new GUIStyle();
		i = new GUIStyle();
		o = new GUIStyle();
		p = new GUIStyle();
		space = new GUIStyle();
	}
	void Update ()
	{
	 	if (flecha == 1 )
		{
			transform.position = Vector3.Lerp (transform.position,new Vector3(3.5f,0.8f,1.0f), Time.deltaTime);
			angulo = Mathf.LerpAngle(0.0f,-90.0f,Time.time*0.2f);
			transform.eulerAngles = new Vector3(0.0f,angulo,0.0f);
		}
		else if (flecha == 2 ) 
		{
			
		}
		else if (flecha == 3 ) 
		{
			
		}
		else if (flecha == 4 ) 
		{
			
		}
		//q
		if(Input.GetKey(KeyCode.Q))
		{
			q.normal.background = iconoFlecha;
		}
		else
		{
			q.normal.background = null;
		}
		//w
		if(Input.GetKey(KeyCode.W))
		{
			w.normal.background = iconoFlecha;
		}
		else
		{
			w.normal.background = null;
		}
		//e
		if(Input.GetKey(KeyCode.E))
		{
			e.normal.background = iconoFlecha;
		}
		else
		{
			e.normal.background = null;
		}
		//i
		if(Input.GetKey(KeyCode.I))
		{
			i.normal.background = iconoFlecha;
		}
		else
		{
			i.normal.background = null;
		}
		//o
		if(Input.GetKey(KeyCode.O))
		{
			o.normal.background = iconoFlecha;
		}
		else
		{
			o.normal.background = null;
		}
		//p
		if(Input.GetKey(KeyCode.P))
		{
			p.normal.background = iconoFlecha;
		}
		else
		{
			p.normal.background = null;
		}
		//space
		if(Input.GetKey(KeyCode.Space))
		{
			space.normal.background = iconoFlecha;
		}
		else
		{
			space.normal.background = null;
		}
	}
	void OnGUI () {

		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de arriba
		if(GUI.Button(new Rect((Screen.width/2)-40,40,80,20), iconoFlecha)) {
			//Camera.main.velocity = new Vector3(0,1,0);
			//Camera.main.transform.forward = Vector3.Lerp(Camera.main.transform.forward, new Vector3(0.0f,1.0f,0.0f), 5.0f * Time.deltaTime);
			//Camera.main.transform.Translate(new Vector3(0.0f,1.0f,0.0f));
			//transform.position = new Vector3(0,1,0);
			//transform.position = Vector3.Lerp (transform.position,new Vector3(0,0,1), Time.deltaTime);
			flecha = 1;
		}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la izquierda
		if(GUI.Button(new Rect(20,(Screen.height/2),20,80), iconoFlecha)) {
			
		}
		//Condicional en el que se crea y se ordena que hacer cuando se oprime la flecha de la derecha
		if(GUI.Button(new Rect((Screen.width-40),(Screen.height/2),20,80), iconoFlecha)) {
			
		}
		GUI.Button(new Rect((Screen.width/4),(Screen.height*3/4),20,20), "Q", q);
			//q.width = 25;
			//q.normal.background = iconoFlecha;
		GUI.Button(new Rect((Screen.width/4+20),(Screen.height*3/4),20,20), "W", w);
			
		
		GUI.Button(new Rect((Screen.width/4+40),(Screen.height*3/4),20,20), "E", e);
		
		GUI.Button(new Rect((Screen.width*3/4),(Screen.height*3/4),20,20), "I", i);
		
		GUI.Button(new Rect((Screen.width*3/4+20),(Screen.height*3/4),20,20), "O", o);
		
		GUI.Button(new Rect((Screen.width*3/4+40),(Screen.height*3/4),20,20), "P", p);
		
		GUI.Button(new Rect((Screen.width/2),(Screen.height*7/8),60,20), "Space", space);
		
	}
}
