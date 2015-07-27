using UnityEngine;
using System.Collections;

public class rangeBehaviour : MonoBehaviour {

	// Use this for initialization
	private Projector projector;

	//Por defecto el proyector esta apagado
	void Start () {
		projector = this.GetComponentInChildren<Projector> ();
		projector.enabled = false;
	}

	//Enciende y apaga el proyector del area de ataque al poner el raton encima
	void OnMouseEnter () {
		projector.enabled = true;
	}

	void OnMouseExit(){
		projector.enabled = false;

	}

}
