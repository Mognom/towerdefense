using UnityEngine;
using System.Collections;

public class blockClickDetection : MonoBehaviour {
	
	public LevelManager levelManager;
	private bool used;

	void Start () {
		used = false;
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
	}


	void OnMouseOver(){
		if (!used && Input.GetMouseButtonDown (0)) {
			used = levelManager.interaccionBloque(transform.position);

		}
	}

}
