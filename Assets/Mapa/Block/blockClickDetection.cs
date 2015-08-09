using UnityEngine;
using System.Collections;

public class blockClickDetection : MonoBehaviour {
	
	public LevelManager lm;
	private bool used;

	void Start () {
		used = false;
	}


	void OnMouseOver(){
		if (!used && Input.GetMouseButtonDown (0)) {
			used = lm.interaccionBloque(transform.position);

		}
	}

}
