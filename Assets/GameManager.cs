using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/*
	 * 0 -> nada 
	 * 1 -> arquero
	 * ...
	 * 
	 */
	private int selected;
	public GameObject torre;
	
	// Use this for initialization
	void Start () {
		selected = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool interaccionBloque(Vector3 pos){
		print ("se ha hecho click en un bloque");
		print (selected);
		
		bool res = false;
		//DETECTAR SI CONSTRUIR O NO
		switch (selected) {
			//Construir torre de arqueros
		case 1:
			Instantiate (torre, pos + new Vector3(0f,0.3f,0f) , torre.transform.rotation);
			selected = 0;
			res = true;
			break;
		
			//No se que me ha llegado -> ignore
		default: break;
		}
		
		return res;
		
		
	}

	public void setSelected(int id){
		selected = id;
	}
}
