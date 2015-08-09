using UnityEngine;
using System.Collections;

public class PathClickDetection : MonoBehaviour {

	private LevelManager levelManager;
	private bool used;
	
	void Start () {
		used = false;
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
	}
	
	
	void OnMouseOver(){
		if (!used && Input.GetMouseButtonDown (0)) {
			used = levelManager.interaccionPath(transform.position);
			
		}
	}
	
}