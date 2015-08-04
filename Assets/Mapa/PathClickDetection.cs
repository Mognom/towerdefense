using UnityEngine;
using System.Collections;

public class PathClickDetection : MonoBehaviour {

	public GameManager gm;
	private bool used;
	
	void Start () {
		used = false;
	}
	
	
	void OnMouseOver(){
		if (!used && Input.GetMouseButtonDown (0)) {
			used = gm.interaccionPath(transform.position);
			
		}
	}
	
}