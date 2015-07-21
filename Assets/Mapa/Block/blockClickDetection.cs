using UnityEngine;
using System.Collections;

public class blockClickDetection : MonoBehaviour {
	
	private GameManager gm;
	private bool used;

	void Start () {
		gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

		used = false;
	}


	void OnMouseOver(){
		if (!used && Input.GetMouseButtonDown (0)) {
			used = !gm.interaccionBloque(transform.position);

		}
	}

}
