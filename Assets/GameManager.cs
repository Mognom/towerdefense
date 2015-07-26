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
	public GameObject arqueros, ballesta, pinchos, lava, mortero;
	
	// Use this for initialization
	void Start () {
		selected = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool interaccionBloque(Vector3 pos){
		
		bool res = false;
		//DETECTAR SI CONSTRUIR O NO
		switch (selected) {

		//Construir torre de arqueros
		case 1:
			Instantiate (arqueros, pos + new Vector3(0f,0.3f,0f) , arqueros.transform.rotation);
			selected = 0;
			res = true;
			break;
		
		case 2:
			Instantiate (ballesta, pos + new Vector3(0f,0.3f,0f) , ballesta.transform.rotation);
			selected = 0;
			res = true;
			break;
		
		case 5:
			Instantiate (mortero, pos + new Vector3(0f,0.3f,0f) , mortero.transform.rotation);
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
